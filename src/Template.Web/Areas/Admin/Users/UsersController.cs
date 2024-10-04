using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Services.Shared;

namespace Template.Web.Areas.Admin.Users
{
    [Area("Admin")]
    public partial class UsersController : Controller
    {
        // Simulazione di un metodo che recupera i dispositivi da un database
        private List<DeviceViewModel> LoadDevices()
        {
            // Caricamento statico per esempio
            return new List<DeviceViewModel>
            {
                new DeviceViewModel
                {
                    Id = 1,
                    SerialNumber = "SN001",
                    DeviceTypeName = "Laptop",
                    Status = "Active",
                    WarrantyStatus = "Valid",
                    DeviceSpecifics = new List<DeviceSpecific>(),
                    DeviceLogs = new List<DeviceLog>(),
                    DeviceAssignments = new List<DeviceAssignment>(),
                    DeviceWarranty = new DeviceWarranty
                    {
                        StartDate = DateTime.Now.AddYears(-1),
                        EndDate = DateTime.Now.AddYears(1)
                    }
                },
                new DeviceViewModel
                {
                    Id = 2,
                    SerialNumber = "SN002",
                    DeviceTypeName = "Tablet",
                    Status = "Inactive",
                    WarrantyStatus = "Expired",
                    DeviceSpecifics = new List<DeviceSpecific>(),
                    DeviceLogs = new List<DeviceLog>(),
                    DeviceAssignments = new List<DeviceAssignment>(),
                    DeviceWarranty = new DeviceWarranty
                    {
                        StartDate = DateTime.Now.AddYears(-2),
                        EndDate = DateTime.Now.AddYears(-1)
                    }
                }
            };
        }

        // Azione Index per dispositivi
        public virtual IActionResult Index(int page = 1, string searchTerm = "", string deviceTypeFilter = "", string deviceStatusFilter = "", string deviceWarrantyFilter = "")
        {
            var model = new IndexViewModel
            {
                AllDevices = LoadDevices(),
                SearchTerm = searchTerm,
                DeviceTypeFilter = deviceTypeFilter,
                DeviceStatusFilter = deviceStatusFilter,
                DeviceWarrantyFilter = deviceWarrantyFilter
            };

            model.ApplyFilters();
            model.CurrentPage = page;
            model.FilteredDevices = model.FilteredDevices.Skip((page - 1) * model.DevicesPerPage).Take(model.DevicesPerPage).ToList();

            return View(model);
        }

        [HttpGet]
        public virtual IActionResult Index(IndexViewModel model)
        {
            return View(model);
        }

        // Azioni CRUD per dispositivi
        public virtual IActionResult CreateDevice()
        {
            return View();
        }

        [HttpPost]
        public virtual IActionResult CreateDevice(IndexViewModel indexViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(indexViewModel);
        }

        public virtual IActionResult ShowDevice(int id)
        {
            var device = LoadDevices().FirstOrDefault(d => d.Id == id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        public virtual IActionResult EditDevice(int id)
        {
            var device = LoadDevices().FirstOrDefault(d => d.Id == id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        [HttpPost]
        public virtual IActionResult EditDevice(IndexViewModel indexViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(indexViewModel);
        }

        public virtual IActionResult DeleteDevice(int id)
        {
            return RedirectToAction("Index");
        }

        // Azioni per utenti

        public virtual IActionResult IndexUsers()
        {
            return View();
        }

        public virtual IActionResult DetailsUser(int id)
        {
            // Codice per mostrare i dettagli dell'utente con id specifico
            return View();
        }

        public virtual IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public virtual IActionResult EditUser(int id)
        {
            return View();
        }

        // Metodo Delete per utenti
        public virtual IActionResult DeleteUser(int id)
        {
            // Codice per eliminare un utente con id specifico
            return RedirectToAction("IndexUsers");
        }
    }
}
