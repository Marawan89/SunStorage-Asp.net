using System;

namespace Template.Services.Shared
{
    public class Device
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceTypeName { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }

        public string AssignedNome { get; set; }
        public string AssignedCognome { get; set; }
        public string AssignedEmail { get; set; }
    }
}
