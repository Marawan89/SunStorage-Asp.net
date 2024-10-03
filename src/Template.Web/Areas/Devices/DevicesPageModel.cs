using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Template.Web.Areas.Devices
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public DevicesViewModel DevicesVM { get; set; }

        public void OnGet(string searchTerm, string deviceTypeFilter, string deviceStatusFilter, string deviceWarrantyFilter, int? page)
        {
            // Load all devices from a repository or database (dummy data here)
            DevicesVM = new DevicesViewModel
            {
                AllDevices = GetDevicesFromDatabase()
            };

            // Set filters
            DevicesVM.SearchTerm = searchTerm;
            DevicesVM.DeviceTypeFilter = deviceTypeFilter;
            DevicesVM.DeviceStatusFilter = deviceStatusFilter;
            DevicesVM.DeviceWarrantyFilter = deviceWarrantyFilter;
            DevicesVM.CurrentPage = page ?? 1;

            // Apply filters
            DevicesVM.ApplyFilters();
        }

        private List<DeviceViewModel> GetDevicesFromDatabase()
        {
            // Simulated data fetching
            return new List<DeviceViewModel>
            {
                new DeviceViewModel { Id = 1, SerialNumber = "ABC123", DeviceTypeName = "Laptop", Status = "Active", WarrantyStatus = "Valid" },
                new DeviceViewModel { Id = 2, SerialNumber = "XYZ456", DeviceTypeName = "Phone", Status = "Inactive", WarrantyStatus = "Expired" },
                // More dummy devices
            };
        }
    }
}
