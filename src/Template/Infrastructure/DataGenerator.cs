using System;
using Template.Services.Shared;
using Template.Services;
using System.Linq;

public class DataGenerator
{
    public static void InitializeDevices(TemplateDbContext context)
    {
        if (context.Devices.Any())
        {
            return;   // Data was already seeded
        }

        var devices = new[]
        {
            new Device
            {
                Id = Guid.NewGuid(),
                SerialNumber = "SN123454654546",
                DeviceTypeName = "Laptop",
                Status = "Free",
                WarrantyStartDate = DateTime.Now.AddYears(-1),
                WarrantyEndDate = DateTime.Now.AddYears(1)
            },
            new Device
            {
                Id = Guid.NewGuid(),
                SerialNumber = "SN678905456444",
                DeviceTypeName = "Phone",
                Status = "Dismissed",
                WarrantyStartDate = DateTime.Now.AddYears(-2),
                WarrantyEndDate = DateTime.Now.AddMonths(-6)
            },
            new Device
            {
                Id = Guid.NewGuid(),
                SerialNumber = "SN8975644531456",
                DeviceTypeName = "Desktop-Pc",
                Status = "Under repair",
                WarrantyStartDate = DateTime.Now.AddYears(-2),
                WarrantyEndDate = DateTime.Now.AddYears(3)
            }
        };

        context.Devices.AddRange(devices);
        context.SaveChanges();
    }
}
