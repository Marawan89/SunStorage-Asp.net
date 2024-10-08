using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Services.Shared
{
    public class Device
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceTypeName { get; set; }
        public string Status { get; set; } = "Free";
        public DateTime WarrantyStartDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
        public string Model { get; set; }
        public string DiskType { get; set; }
        public string DiskSize { get; set; }
        public string RamSize { get; set; }
        public string ProcessorType { get; set; }
    }
}
