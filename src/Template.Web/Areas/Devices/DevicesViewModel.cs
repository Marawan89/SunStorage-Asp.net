using System;
using System.Collections.Generic;
using System.Linq;

namespace Template.Web.Areas.Devices
{
    public class DeviceViewModel
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceTypeName { get; set; }
        public string Status { get; set; }
        public string WarrantyStatus { get; set; }
        public List<DeviceSpecific> DeviceSpecifics { get; set; }
        public List<DeviceLog> DeviceLogs { get; set; }
        public List<DeviceAssignment> DeviceAssignments { get; set; }
        public DeviceWarranty DeviceWarranty { get; set; }
    }

    public class DevicesViewModel
    {
        public List<DeviceViewModel> AllDevices { get; set; } = new List<DeviceViewModel>();
        public List<DeviceViewModel> FilteredDevices { get; set; } = new List<DeviceViewModel>();
        public List<string> DeviceTypes { get; set; }
        public string SearchTerm { get; set; }
        public string DeviceTypeFilter { get; set; }
        public string DeviceStatusFilter { get; set; }
        public string DeviceWarrantyFilter { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int DevicesPerPage { get; set; } = 5;

        // Pagination helpers
        public int TotalPages => (int)Math.Ceiling((double)FilteredDevices.Count / DevicesPerPage);
        public int IndexOfFirstDevice => (CurrentPage - 1) * DevicesPerPage;
        public int IndexOfLastDevice => Math.Min(IndexOfFirstDevice + DevicesPerPage, FilteredDevices.Count);
        public List<DeviceViewModel> CurrentDevices => FilteredDevices.Skip(IndexOfFirstDevice).Take(DevicesPerPage).ToList();

        // Functions for filtering and pagination
        public void ApplyFilters()
        {
            FilteredDevices = AllDevices;

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                FilteredDevices = FilteredDevices
                    .Where(d => d.SerialNumber.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(DeviceTypeFilter))
            {
                FilteredDevices = FilteredDevices
                    .Where(d => d.DeviceTypeName.Equals(DeviceTypeFilter, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(DeviceStatusFilter))
            {
                FilteredDevices = FilteredDevices
                    .Where(d => d.Status.Equals(DeviceStatusFilter, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(DeviceWarrantyFilter))
            {
                FilteredDevices = FilteredDevices
                    .Where(d => d.WarrantyStatus.Equals(DeviceWarrantyFilter, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }

        // Reset all filters
        public void ResetFilters()
        {
            SearchTerm = string.Empty;
            DeviceTypeFilter = string.Empty;
            DeviceStatusFilter = string.Empty;
            DeviceWarrantyFilter = string.Empty;
            FilteredDevices = AllDevices;
        }
    }

    public class DeviceSpecific
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class DeviceLog
    {
        public string LogType { get; set; }
        public string AdditionalNotes { get; set; }
        public DateTime EventDateTime { get; set; }
    }

    public class DeviceAssignment
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DepartmentName { get; set; }
        public string Email { get; set; }
    }

    public class DeviceWarranty
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string GetWarrantyStatus()
        {
            if (EndDate >= DateTime.Now) return "Valid";
            return "Expired";
        }
    }
}
