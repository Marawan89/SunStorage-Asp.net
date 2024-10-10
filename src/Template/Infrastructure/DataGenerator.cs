using System;
using Template.Services.Shared;
using Template.Services;
using System.Linq;

public class DataGenerator
{
    public static void InitializeDevices(TemplateDbContext context)
    {
        if (context.Users.Any())
        {
            return;   // Data was already seeded
        }

        context.Users.AddRange(
            new User
            {
                Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                Email = "marawan@sunstorage.it",
                Password = "M0Cuk9OsrcS/rTLGf5SY6DUPqU2rGc1wwV2IL88GVGo=", // SHA-256 of text "Prova"
                FirstName = "Marawan",
                LastName = "Emad",
                NickName = "Marawan"
            },
            new User
            {
                Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), // Forced to specific Guid for tests
                Email = "andrea@sunstorage.it",
                Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Test"
                FirstName = "Andrea",
                LastName = "Bianchi",
                NickName = "Andre"
            });
        context.SaveChanges();

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
                DeviceTypeName = "Desktop-PC",
                Status = "Under repair",
                WarrantyStartDate = DateTime.Now.AddYears(-2),
                WarrantyEndDate = DateTime.Now.AddYears(3)
            }
        };

        context.Devices.AddRange(devices);
        context.SaveChanges();
    }
}
