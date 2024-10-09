using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using Template.Services.Shared;
using Template.Services;
using Microsoft.Extensions.Logging;

namespace Template.Web.Areas.Admin.Users
{
    [Area("Admin")]
    public partial class UsersController : AuthenticatedBaseController
    {
        private readonly TemplateDbContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(TemplateDbContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async virtual Task<IActionResult> Index(string searchTerm, string deviceTypeFilter,
            string deviceStatusFilter, string deviceWarrantyFilter, int currentPage = 1)
        {
            try
            {
                var query = _context.Devices.AsQueryable();

                var totalCount = await query.CountAsync();
                _logger.LogInformation($"Total devices in database: {totalCount}");

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
                    .OrderByDescending(d => d.CreatedAt) // Ordina per data di creazione in modo decrescente
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();


                if (devices.Any())
                {
                    var firstDevice = devices.First();
                    _logger.LogInformation($"Sample device - SerialNumber: {firstDevice.SerialNumber}, Type: {firstDevice.DeviceTypeName}");
                }

                // Converti Device in DeviceViewModel
                var deviceViewModels = devices.Select(d => new DeviceViewModel
                {
                    Id = d.Id,
                    SerialNumber = d.SerialNumber,
                    DeviceTypeName = d.DeviceTypeName,
                    Status = d.Status,
                    WarrantyStartDate = d.WarrantyStartDate,
                    WarrantyEndDate = d.WarrantyEndDate,
                    DeviceWarranty = new DeviceWarranty
                    {
                        StartDate = d.WarrantyStartDate,
                        EndDate = d.WarrantyEndDate
                    }
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
            catch (Exception ex)
            {
                _logger.LogError($"Error in Index action: {ex.Message}");
                throw;
            }
        }

        [HttpGet]
        [ActionName("AddDevice")]
        public virtual IActionResult AddDeviceForm()
        {
            return View();
        }

        [HttpPost]
        public async virtual Task<IActionResult> AddDevice(AddDeviceViewModel model)
        {
            try
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
                    WarrantyStartDate = model.WarrantyStartDate.Value,
                    WarrantyEndDate = model.WarrantyEndDate.Value,
                    Status = "Free"
                };

                _context.Devices.Add(device);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Device added successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding device: {ex.Message}");
                ModelState.AddModelError("", "An error occurred while saving the device.");
                return View(model);
            }
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
