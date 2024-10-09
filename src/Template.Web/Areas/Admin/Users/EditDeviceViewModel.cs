using System;

namespace Template.Web.Areas.Admin.Users
{
    public class EditDeviceViewModel
    {
        public Guid Id { get; set; } 
        public string SerialNumber { get; set; }
        public string DeviceTypeName { get; set; }
        public DateTime? WarrantyStartDate { get; set; } 
        public DateTime? WarrantyEndDate { get; set; }
        public string DeviceStatusName { get; set; }
    }
}
