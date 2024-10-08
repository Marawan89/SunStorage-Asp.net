using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using Template.Services.Shared;
using Template.Services;
using Template.Web.Areas.Admin.Users;
using Template.Web.Areas;

namespace Template.Web.Areas.Admin.Users
{
    [Area("Admin")]
    public partial class UsersController : AuthenticatedBaseController
    {
        private readonly TemplateDbContext _context;

        public UsersController(TemplateDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IActionResult> Index(string searchTerm, string deviceTypeFilter,
            string deviceStatusFilter, string deviceWarrantyFilter, int currentPage = 1)
        {
            var query = _context.Devices.AsQueryable();

            // Applicare i filtri
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(d => d.SerialNumber.Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(deviceTypeFilter))
            {
                query = query.Where(d => d.DeviceTypeName == deviceTypeFilter);
            }

            if (!string.IsNullOrEmpty(deviceStatusFilter))
            {
                query = query.Where(d => d.Status == deviceStatusFilter);
            }

            if (!string.IsNullOrEmpty(deviceWarrantyFilter))
            {
                var today = DateTime.Today;
                switch (deviceWarrantyFilter)
                {
                    case "Valid":
                        query = query.Where(d => d.WarrantyEndDate >= today);
                        break;
                    case "Expired":
                        query = query.Where(d => d.WarrantyEndDate < today);
                        break;
                }
            }

            var pageSize = 5;
            var totalDevices = await query.CountAsync();
            var devices = await query
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Converti Device in DeviceViewModel
            var deviceViewModels = devices.Select(d => new DeviceViewModel
            {
                Id = d.Id,
                SerialNumber = d.SerialNumber,
                DeviceTypeName = d.DeviceTypeName,
                Status = d.Status,
                WarrantyStartDate = d.WarrantyStartDate,
                WarrantyEndDate = d.WarrantyEndDate,
                Model = d.Model,
                DiskType = d.DiskType,
                DiskSize = d.DiskSize,
                RamSize = d.RamSize,
                ProcessorType = d.ProcessorType
            }).ToList();

            var viewModel = new IndexViewModel
            {
                Devices = deviceViewModels,
                DeviceTypeOptions = await _context.Devices.Select(d => d.DeviceTypeName).Distinct().ToListAsync(),
                DeviceStatusOptions = await _context.Devices.Select(d => d.Status).Distinct().ToListAsync(),
                TotalPages = (int)Math.Ceiling(totalDevices / (double)pageSize),
                SearchTerm = searchTerm,
                DeviceTypeFilter = deviceTypeFilter,
                DeviceStatusFilter = deviceStatusFilter,
                DeviceWarrantyFilter = deviceWarrantyFilter,
                CurrentPage = currentPage
            };

            return View(viewModel);
        }

        [HttpGet]
        [ActionName("AddDevice")]
        public virtual IActionResult AddDeviceForm()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> AddDevice(AddDeviceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var device = new Device
            {
                Id = Guid.NewGuid(),
                SerialNumber = model.SerialNumber,
                DeviceTypeName = model.DeviceTypeName,
                Status = "Active",
                WarrantyStartDate = model.WarrantyStartDate,
                WarrantyEndDate = model.WarrantyEndDate,
                Model = model.Model,
                DiskType = model.DiskType,
                DiskSize = model.DiskSize,
                RamSize = model.RamSize,
                ProcessorType = model.ProcessorType
            };

            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public virtual async Task<IActionResult> ChangeDeviceStatus(Guid id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device != null)
            {
                device.Status = device.Status == "Active" ? "Inactive" : "Active";
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public virtual async Task<IActionResult> DeleteDevice(Guid id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device != null)
            {
                _context.Devices.Remove(device);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
