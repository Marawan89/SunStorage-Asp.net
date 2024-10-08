using Template.Services.Shared;
using System;
using System.Linq;
using Template.Services;

namespace Template.Infrastructure
{
    public class DataGenerator
    {
        public static void InitializeUsers(TemplateDbContext context)
        {
            if (context.Users.Any())
            {
                return;   // Data was already seeded
            }

            context.Users.AddRange(
                new User
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    Email = "andrea@sunstorage.it",
                    Password = "M0Cuk9OsrcS/rTLGf5SY6DUPqU2rGc1wwV2IL88GVGo=", // SHA-256 of text "Prova"
                    FirstName = "Andrea",
                    LastName = "Bianchi",
                    NickName = "Admin"
                },
                new User
                {
                    Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), // Forced to specific Guid for tests
                    Email = "marawan@sunstorage.it",
                    Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Test"
                    FirstName = "Marawan",
                    LastName = "Emad",
                    NickName = "AdminFull"
                });

            context.SaveChanges();
        }

        public static void InitializeDevices(TemplateDbContext context)
        {
            if (context.Devices.Any())
            {
                return;   // Data was already seeded
            }

            context.Devices.AddRange(
                new Device
                {
                    Id = Guid.NewGuid(),
                    SerialNumber = "SN123454654546",
                    DeviceTypeName = "Laptop",
                    Status = "Free",
                    WarrantyStartDate = DateTime.Now.AddYears(-1),
                    WarrantyEndDate = DateTime.Now.AddYears(1),
                    Model = "ThinkPad X1",
                    DiskType = "SSD",
                    DiskSize = "512",
                    RamSize = "16",
                    ProcessorType = "Intel i7"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    SerialNumber = "SN678905456444",
                    DeviceTypeName = "Phone",
                    Status = "Dismissed",
                    WarrantyStartDate = DateTime.Now.AddYears(-2),
                    WarrantyEndDate = DateTime.Now.AddMonths(-6),
                    Model = "iPhone 13",
                    DiskSize = "128"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    SerialNumber = "SN8975644531456",
                    DeviceTypeName = "Desktop-Pc",
                    Status = "Under repair",
                    WarrantyStartDate = DateTime.Now.AddYears(-2),
                    WarrantyEndDate = DateTime.Now.AddYears(3),
                    Model = "Mini-pc Dell",
                    DiskType = "SSD",
                    DiskSize = "512",
                    RamSize = "8",
                    ProcessorType = "Intel i5"
                }
            );

            context.SaveChanges();
        }
    }
}
