using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Template.Web.Areas.Admin.Users;

namespace Template.Web.Areas.Admin.Users
{
    [Area("Admin")]
    public partial class UsersController : AuthenticatedBaseController
    {
        private List<DeviceViewModel> devices;

        public UsersController()
        {
            devices = GetDevicesFromDatabase(); // Inizializziamo i dispositivi una sola volta
        }

        public virtual IActionResult Index(string searchTerm, string deviceTypeFilter, string deviceStatusFilter, int currentPage = 1)
        {
            var filteredDevices = devices.AsQueryable();

            // Applicare i filtri
            if (!string.IsNullOrEmpty(searchTerm))
            {
                filteredDevices = filteredDevices.Where(d => d.SerialNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(deviceTypeFilter))
            {
                filteredDevices = filteredDevices.Where(d => d.DeviceTypeName == deviceTypeFilter);
            }

            if (!string.IsNullOrEmpty(deviceStatusFilter))
            {
                filteredDevices = filteredDevices.Where(d => d.Status == deviceStatusFilter);
            }

            // Pagina dei risultati
            var pageSize = 5; // Numero di dispositivi per pagina
            var totalDevices = filteredDevices.Count();
            var devicesToShow = filteredDevices.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            var viewModel = new IndexViewModel
            {
                Devices = devicesToShow,
                DeviceTypeOptions = devices.Select(d => d.DeviceTypeName).Distinct().ToList(),
                DeviceStatusOptions = devices.Select(d => d.Status).Distinct().ToList(),
                TotalPages = (int)Math.Ceiling(totalDevices / (double)pageSize),
                SearchTerm = searchTerm,
                DeviceTypeFilter = deviceTypeFilter,
                DeviceStatusFilter = deviceStatusFilter,
                CurrentPage = currentPage
            };

            return View(viewModel);
        }

        // Visualizza la pagina per aggiungere un dispositivo
        public virtual IActionResult AddDevice()
        {
            return View(new AddDeviceViewModel());
        }

        [HttpPost]
        public virtual IActionResult AddDevice(AddDeviceViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Converti AddDeviceViewModel in DeviceViewModel
                var device = new DeviceViewModel
                {
                    SerialNumber = model.SerialNumber,
                    DeviceTypeName = model.DeviceTypeName,
                    Status = model.Status,
                    DeviceWarranty = model.DeviceWarranty
                };

                devices.Add(device); // Aggiunge il dispositivo alla lista
                return RedirectToAction("Index");
            }

            return View(model);
        }


        // Cambia lo stato del dispositivo
        [HttpPost]
        public virtual IActionResult ChangeDeviceStatus(int id)
        {
            var device = devices.FirstOrDefault(d => d.Id == id);
            if (device != null)
            {
                // Logica per cambiare lo stato del dispositivo
                device.Status = device.Status == "Active" ? "Inactive" : "Active";
            }
            return RedirectToAction("Index");
        }

        // Elimina il dispositivo
        [HttpPost]
        public virtual IActionResult DeleteDevice(int id)
        {
            var device = devices.FirstOrDefault(d => d.Id == id);
            if (device != null)
            {
                devices.Remove(device); // Rimuove il dispositivo dalla lista
            }
            return RedirectToAction("Index");
        }

        // Simulazione della logica di fetch dal database
        private List<DeviceViewModel> GetDevicesFromDatabase()
        {
            return new List<DeviceViewModel>
            {
                new DeviceViewModel
                {
                    Id = 1,
                    SerialNumber = "SN12345",
                    DeviceTypeName = "Laptop",
                    Status = "Active",
                    DeviceWarranty = new DeviceWarranty { StartDate = DateTime.Now.AddYears(-1), EndDate = DateTime.Now.AddYears(1) }
                },
                new DeviceViewModel
                {
                    Id = 2,
                    SerialNumber = "SN67890",
                    DeviceTypeName = "Phone",
                    Status = "Inactive",
                    DeviceWarranty = new DeviceWarranty { StartDate = DateTime.Now.AddYears(-2), EndDate = DateTime.Now.AddMonths(-6) }
                },
                new DeviceViewModel
                {
                    Id = 3,
                    SerialNumber = "SN64814",
                    DeviceTypeName = "Desktop-Pc",
                    Status = "Under Repair",
                    DeviceWarranty = new DeviceWarranty { StartDate = DateTime.Now.AddYears(-3), EndDate = DateTime.Now.AddMonths(2) }
                }
            };
        }
    }
}
