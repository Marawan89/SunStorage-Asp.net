using System;
using System.Collections.Generic;

namespace Template.Web.Areas.Admin.Users
{
    public class DeviceViewModel
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceTypeName { get; set; }
        public string Status { get; set; }
        public DeviceWarranty DeviceWarranty { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public string Model { get; set; }
        public string DiskType { get; set; }
        public string DiskSize { get; set; }
        public string RamSize { get; set; }
        public string ProcessorType { get; set; }
    }

    public class IndexViewModel
    {
        public List<DeviceViewModel> Devices { get; set; }
        public List<string> DeviceTypeOptions { get; set; }
        public List<string> DeviceStatusOptions { get; set; }
        public string SearchTerm { get; set; }
        public string DeviceTypeFilter { get; set; }
        public string DeviceStatusFilter { get; set; }
        public string DeviceWarrantyFilter { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
    }

    public class DeviceWarranty
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
