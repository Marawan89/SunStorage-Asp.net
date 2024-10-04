using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Template.Web.Areas.Admin.Users
{
    public partial class IndexModel : PageModel
    {
        [BindProperty]
        public IndexViewModel DevicesVM { get; set; }

        public virtual void OnGet(string searchTerm, string deviceTypeFilter, string deviceStatusFilter, string deviceWarrantyFilter, int? page)
        {
            // Load all devices from a repository or database (dummy data here)
            DevicesVM = new IndexViewModel
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

        private List<IndexViewModel> GetDevicesFromDatabase()
        {
            // Simulated data fetching
            return new List<IndexViewModel>
            {
                new IndexViewModel { Id = 1, SerialNumber = "ABC123", DeviceTypeName = "Laptop", Status = "Active", WarrantyStatus = "Valid" },
                new IndexViewModel { Id = 2, SerialNumber = "XYZ456", DeviceTypeName = "Phone", Status = "Inactive", WarrantyStatus = "Expired" },
                // More dummy devices
            };
        }
    }
}
