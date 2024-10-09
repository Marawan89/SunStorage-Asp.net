using System;

namespace Template.Web.Areas.Admin.Users
{
    public class ViewDeviceViewModel
    {
        public string SerialNumber { get; set; }
        public string DeviceTypeName { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public string Status { get; set; }

        public string AssignedUserFirstName { get; set; }
        public string AssignedUserLastName { get; set; }
        public string AssignedUserEmail { get; set; }
    }


}
