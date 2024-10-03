using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Template.Web.Areas.Devices; // Assicurati che questo spazio dei nomi corrisponda alla tua struttura del progetto

namespace Template.Web.Areas.Devices
{
    [Area("Devices")] // Specifica che questo controller appartiene all'area Devices
    public class DevicesController : Controller
    {
        // Simulazione di un metodo che recupera i dispositivi da un database
        private List<DeviceViewModel> LoadDevices()
        {
            // Qui dovresti implementare il caricamento dei dati dal tuo database.
            // Questo è solo un esempio statico.
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
                },
                // Aggiungi altri dispositivi qui...
            };
        }

        public IActionResult Index(int page = 1, string searchTerm = "", string deviceTypeFilter = "", string deviceStatusFilter = "", string deviceWarrantyFilter = "")
        {
            // Carica tutti i dispositivi
            var model = new DevicesViewModel
            {
                AllDevices = LoadDevices()
            };

            // Imposta i filtri
            model.SearchTerm = searchTerm;
            model.DeviceTypeFilter = deviceTypeFilter;
            model.DeviceStatusFilter = deviceStatusFilter;
            model.DeviceWarrantyFilter = deviceWarrantyFilter;

            // Applica i filtri
            model.ApplyFilters();

            // Imposta la paginazione
            model.CurrentPage = page;

            // Restituisce la vista con il modello
            return View(model);
        }

        // Metodo per la creazione di un nuovo dispositivo (da implementare)
        public IActionResult Create()
        {
            // Qui puoi restituire una vista per creare un nuovo dispositivo
            return View();
        }

        // Metodo per gestire la creazione di un nuovo dispositivo (POST)
        [HttpPost]
        public IActionResult Create(DeviceViewModel deviceViewModel)
        {
            if (ModelState.IsValid)
            {
                // Qui dovresti implementare la logica per salvare il nuovo dispositivo nel database

                // Redirect alla pagina Index dopo aver creato il dispositivo
                return RedirectToAction("Index");
            }

            // Se il modello non è valido, restituisci la vista di creazione
            return View(deviceViewModel);
        }

        // Metodo per visualizzare un dispositivo specifico
        public IActionResult Show(int id)
        {
            var device = LoadDevices().FirstOrDefault(d => d.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // Metodo per modificare un dispositivo (da implementare)
        public IActionResult Edit(int id)
        {
            var device = LoadDevices().FirstOrDefault(d => d.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // Metodo per gestire la modifica di un dispositivo (POST)
        [HttpPost]
        public IActionResult Edit(DeviceViewModel deviceViewModel)
        {
            if (ModelState.IsValid)
            {
                // Qui dovresti implementare la logica per aggiornare il dispositivo nel database

                // Redirect alla pagina Index dopo aver modificato il dispositivo
                return RedirectToAction("Index");
            }

            // Se il modello non è valido, restituisci la vista di modifica
            return View(deviceViewModel);
        }

        // Metodo per eliminare un dispositivo (da implementare)
        public IActionResult Delete(int id)
        {
            // Qui dovresti implementare la logica per eliminare il dispositivo dal database
            return RedirectToAction("Index");
        }
    }
}
