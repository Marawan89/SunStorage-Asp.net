using Template.Web.Areas.Admin.Users;

namespace Template.Web.Areas.Admin.Users;

public class AddDeviceViewModel
{
    public string SerialNumber { get; set; }
    public string DeviceTypeName { get; set; }
    public string Status { get; set; }
    public DeviceWarranty DeviceWarranty { get; set; }
}
