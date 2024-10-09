using System;
using System.ComponentModel.DataAnnotations;

namespace Template.Web.Areas.Admin.Users
{
    public class AddDeviceViewModel
    {
        [Required(ErrorMessage = "Serial Number is required")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Device Type is required")]
        public string DeviceTypeName { get; set; }

        public string Model { get; set; }
        public string DiskType { get; set; }
        public string DiskSize { get; set; }
        public string RamSize { get; set; }
        public string ProcessorType { get; set; }

        [Required(ErrorMessage = "Warranty Start Date is required")]
        [DataType(DataType.Date)]
        public DateTime? WarrantyStartDate { get; set; }

        [Required(ErrorMessage = "Warranty End Date is required")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(AddDeviceViewModel), nameof(ValidateWarrantyEndDate))]
        public DateTime? WarrantyEndDate { get; set; }

        public static ValidationResult ValidateWarrantyEndDate(DateTime? endDate, ValidationContext context)
        {
            var instance = context.ObjectInstance as AddDeviceViewModel;
            if (instance?.WarrantyStartDate > endDate)
            {
                return new ValidationResult("Warranty End Date must be after Start Date");
            }
            return ValidationResult.Success;
        }
    }
}