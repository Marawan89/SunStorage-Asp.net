using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Template.Web.Areas.Admin.Users;

namespace Template.Web.Areas.Admin.Users
{
    [Area("Admin")]
    public partial class UsersController : Controller
    {
        public virtual IActionResult Index()
        {
            // Simulazione di dati dal database
            var devices = GetDevicesFromDatabase();

            var viewModel = new IndexViewModel
            {
                Devices = devices,
                DeviceTypeOptions = devices.Select(d => d.DeviceTypeName).Distinct().ToList(),
                DeviceStatusOptions = devices.Select(d => d.Status).Distinct().ToList(),
                TotalPages = (int)Math.Ceiling(devices.Count / 5.0) // Supponiamo 5 dispositivi per pagina
            };

            return View(viewModel);
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
                }
                // Aggiungi altri dispositivi per la simulazione
            };
        }
    }
}
