using System;
using System.Collections.Generic;

namespace Template.Web.Areas.Admin.Users
{
    public class DeviceAssignment
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DepartmentName { get; set; }
        public string Email { get; set; }
    }

    public class DeviceSpecific
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string InputLabel { get; set; }
    }

    public class DeviceWarranty
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class DeviceLog
    {
        public string LogType { get; set; }
        public string AdditionalNotes { get; set; }
        public DateTime EventDateTime { get; set; }
    }

    public class DeviceViewModel
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceTypeName { get; set; }
        public string Status { get; set; }
        public string QrCodeString { get; set; }
        public bool Show { get; set; }
        public List<DeviceSpecific> DeviceSpecifics { get; set; }
        public DeviceWarranty DeviceWarranty { get; set; }
        public List<DeviceLog> DeviceLogs { get; set; }
        public List<DeviceAssignment> DeviceAssignments { get; set; }
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
}
