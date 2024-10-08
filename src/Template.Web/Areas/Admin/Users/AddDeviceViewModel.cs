using System;
using Template.Web.Areas.Admin.Users;

namespace Template.Web.Areas.Admin.Users;

public class AddDeviceViewModel
{
    public string SerialNumber { get; set; }
    public string DeviceTypeName { get; set; }
    public string Status { get; set; } = "Active";
    public DateTime WarrantyStartDate { get; set; }
    public DateTime WarrantyEndDate { get; set; }

    // Campi dinamici
    public string Model { get; set; }
    public string DiskType { get; set; }
    public string DiskSize { get; set; }
    public string RamSize { get; set; }
    public string ProcessorType { get; set; }
}

