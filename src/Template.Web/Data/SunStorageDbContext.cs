using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class SunStorageDbContext : DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<DeviceAssignment> DeviceAssignments { get; set; }
    public DbSet<DeviceLog> DeviceLogs { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceSpecific> DeviceSpecifics { get; set; }
    public DbSet<DeviceSpecificInput> DeviceSpecificInputs { get; set; }
    public DbSet<DeviceType> DeviceTypes { get; set; }
    public DbSet<DeviceWarranty> DeviceWarranties { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("SunStorageDb");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurazione delle chiavi primarie
        modelBuilder.Entity<Department>().HasKey(d => d.Id);
        modelBuilder.Entity<DeviceAssignment>().HasKey(da => da.Id);
        modelBuilder.Entity<DeviceLog>().HasKey(dl => dl.Id);
        modelBuilder.Entity<Device>().HasKey(d => d.Id);
        modelBuilder.Entity<DeviceSpecific>().HasKey(ds => ds.Id);
        modelBuilder.Entity<DeviceSpecificInput>().HasKey(dsi => dsi.Id);
        modelBuilder.Entity<DeviceType>().HasKey(dt => dt.Id);
        modelBuilder.Entity<DeviceWarranty>().HasKey(dw => dw.Id);
        modelBuilder.Entity<User>().HasKey(u => u.Id);

        // Configurazione delle relazioni
        modelBuilder.Entity<DeviceAssignment>()
            .HasOne(da => da.Device)
            .WithMany(d => d.DeviceAssignments)
            .HasForeignKey(da => da.DeviceId);

        modelBuilder.Entity<DeviceAssignment>()
            .HasOne(da => da.User)
            .WithMany(u => u.DeviceAssignments)
            .HasForeignKey(da => da.UserId);

        modelBuilder.Entity<DeviceLog>()
            .HasOne(dl => dl.Device)
            .WithMany(d => d.DeviceLogs)
            .HasForeignKey(dl => dl.DeviceId);

        modelBuilder.Entity<DeviceSpecific>()
            .HasOne(ds => ds.Device)
            .WithMany(d => d.DeviceSpecifics)
            .HasForeignKey(ds => ds.DeviceId);

        modelBuilder.Entity<DeviceSpecific>()
            .HasOne(ds => ds.DeviceSpecificInput)
            .WithMany(dsi => dsi.DeviceSpecifics)
            .HasForeignKey(ds => ds.DeviceSpecificInputId);

        modelBuilder.Entity<Device>()
            .HasOne(d => d.DeviceType)
            .WithMany(dt => dt.Devices)
            .HasForeignKey(d => d.DeviceTypeId);

        modelBuilder.Entity<DeviceWarranty>()
            .HasOne(dw => dw.Device)
            .WithMany(d => d.DeviceWarranties)
            .HasForeignKey(dw => dw.DeviceId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Department)
            .WithMany(d => d.Users)
            .HasForeignKey(u => u.DepartmentId);

        // Seed Database con i dati forniti
        SeedDatabase(modelBuilder);
    }

    private void SeedDatabase(ModelBuilder modelBuilder)
    {
        // Seed Departments
        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "IT" },
            new Department { Id = 2, Name = "Marketing" },
            new Department { Id = 3, Name = "Amministrazione" }
        );

        // Seed DeviceTypes
        modelBuilder.Entity<DeviceType>().HasData(
            new DeviceType { Id = 1, Name = "Laptop" },
            new DeviceType { Id = 2, Name = "Telefoni" },
            new DeviceType { Id = 3, Name = "Desktop-PC" }
        );

        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, DepartmentId = 1, Name = "Max", Surname = "Marion", Email = "max@marion" },
            new User { Id = 2, DepartmentId = 1, Name = "Luca", Surname = "Baccarin", Email = "luca@baccarin" },
            new User { Id = 3, DepartmentId = 2, Name = "Michela", Surname = "Marz", Email = "michela@marz" },
            // Aggiungi tutti gli altri utenti...
            new User { Id = 25, DepartmentId = 1, Name = "marawan", Surname = "emad", Email = "marawan@emad.com" }
        );

        // Seed Devices
        modelBuilder.Entity<Device>().HasData(
            new Device { Id = 109, DeviceTypeId = 3, Sn = "56784567896578EDITEDCUIA", QrCodeString = "SunStorage_DeviceNumber233393", Status = "free" },
            new Device { Id = 110, DeviceTypeId = 2, Sn = "3275907395025EDITED", QrCodeString = "SunStorage_DeviceNumber727539", Status = "assigned" },
            // Aggiungi tutti gli altri dispositivi...
            new Device { Id = 121, DeviceTypeId = 2, Sn = "fhoihfiefengegqg", QrCodeString = "SunStorage_DeviceNumber271648", Status = "free" }
        );

        // Seed DeviceSpecificInputs
        modelBuilder.Entity<DeviceSpecificInput>().HasData(
            new DeviceSpecificInput { Id = 1, DeviceTypeId = 1, InputName = "LAPTOP_DISK_TYPE", InputLabel = "Disk type", InputType = "select", InputValues = "[\"SSD\",\"HDD\"]" },
            new DeviceSpecificInput { Id = 2, DeviceTypeId = 1, InputName = "LAPTOP_DISK_SIZE", InputLabel = "Disk Size (GB)", InputType = "select", InputValues = "[\"128\",\"256\",\"512\", \"1T\"]" },
            // Aggiungi tutti gli altri input...
            new DeviceSpecificInput { Id = 13, DeviceTypeId = 3, InputName = "DESKTOP_MONITOR_INCHES", InputLabel = "Monitor inches", InputType = "number" }
        );

        // Seed altri record come `DeviceAssignments`, `DeviceLogs`, `DeviceWarranties`, etc.
        // Esempio:
        modelBuilder.Entity<DeviceAssignment>().HasData(
            new DeviceAssignment { Id = 59, DeviceId = 110, UserId = 24, AssignDateTime = new DateTime(2024, 9, 10, 9, 43, 0) }
        );

        // Popola anche le altre entità come specificato nel file SQL.
    }
}

// Modelli (Entities)
public class Department { public int Id { get; set; } public string Name { get; set; } public ICollection<User> Users { get; set; } }
public class User { public int Id { get; set; } public int? DepartmentId { get; set; } public string Name { get; set; } public string Surname { get; set; } public string Email { get; set; } public Department Department { get; set; } public ICollection<DeviceAssignment> DeviceAssignments { get; set; } }
public class Device { public int Id { get; set; } public int? DeviceTypeId { get; set; } public string Sn { get; set; } public string QrCodeString { get; set; } public string Status { get; set; } public DeviceType DeviceType { get; set; } public ICollection<DeviceAssignment> DeviceAssignments { get; set; } public ICollection<DeviceLog> DeviceLogs { get; set; } public ICollection<DeviceSpecific> DeviceSpecifics { get; set; } public ICollection<DeviceWarranty> DeviceWarranties { get; set; } }
public class DeviceType { public int Id { get; set; } public string Name { get; set; } public ICollection<Device> Devices { get; set; } }
public class DeviceAssignment { public int Id { get; set; } public int? DeviceId { get; set; } public int? UserId { get; set; } public DateTime AssignDateTime { get; set; } public Device Device { get; set; } public User User { get; set; } }
public class DeviceLog { public int Id { get; set; } public int? DeviceId { get; set; } public string Message { get; set; } public DateTime LogDateTime { get; set; } public Device Device { get; set; } }
public class DeviceSpecific { public int Id { get; set; } public int? DeviceId { get; set; } public int? DeviceSpecificInputId { get; set; } public string Value { get; set; } public Device Device { get; set; } public DeviceSpecificInput DeviceSpecificInput { get; set; } }
public class DeviceSpecificInput { public int Id { get; set; } public int? DeviceTypeId { get; set; } public string InputName { get; set; } public string InputLabel { get; set; } public string InputType { get; set; } public string InputValues { get; set; } public DeviceType DeviceType { get; set; } public ICollection<DeviceSpecific> DeviceSpecifics { get; set; } }
public class DeviceWarranty { public int Id { get; set; } public int? DeviceId { get; set; } public string WarrantyLabel { get; set; } public string WarrantyValue { get; set; } public Device Device { get; set; } }
