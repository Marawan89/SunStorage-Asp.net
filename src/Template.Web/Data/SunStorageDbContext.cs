using Microsoft.EntityFrameworkCore;
using System;

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
            .WithMany()
            .HasForeignKey(da => da.DeviceId);

        modelBuilder.Entity<DeviceAssignment>()
            .HasOne(da => da.User)
            .WithMany()
            .HasForeignKey(da => da.UserId);

        modelBuilder.Entity<DeviceLog>()
            .HasOne(dl => dl.Device)
            .WithMany()
            .HasForeignKey(dl => dl.DeviceId);

        modelBuilder.Entity<Device>()
            .HasOne(d => d.DeviceType)
            .WithMany()
            .HasForeignKey(d => d.DeviceTypeId);

        modelBuilder.Entity<DeviceSpecific>()
            .HasOne(ds => ds.Device)
            .WithMany()
            .HasForeignKey(ds => ds.DeviceId);

        modelBuilder.Entity<DeviceSpecificInput>()
            .HasOne(dsi => dsi.DeviceType)
            .WithMany()
            .HasForeignKey(dsi => dsi.DeviceTypeId);

        modelBuilder.Entity<DeviceWarranty>()
            .HasOne(dw => dw.Device)
            .WithMany()
            .HasForeignKey(dw => dw.DeviceId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Department)
            .WithMany()
            .HasForeignKey(u => u.DepartmentId);
    }

    public SunStorageDbContext(DbContextOptions<SunStorageDbContext> options) : base(options) { }
}

// Models (sostituisci questi con i tuoi modelli)
public class Department { public int Id { get; set; } public string Name { get; set; } }
public class DeviceAssignment { public int Id { get; set; } public int? DeviceId { get; set; } public int? UserId { get; set; } public DateTime AssignDateTime { get; set; } public Device Device { get; set; } public User User { get; set; } }
public class DeviceLog { public int Id { get; set; } public int? DeviceId { get; set; } public string LogType { get; set; } public string AdditionalNotes { get; set; } public DateTime EventDateTime { get; set; } public Device Device { get; set; } }
public class Device { public int Id { get; set; } public int? DeviceTypeId { get; set; } public string Sn { get; set; } public string QrCodeString { get; set; } public string Status { get; set; } public DeviceType DeviceType { get; set; } }
public class DeviceSpecific { public int Id { get; set; } public int? DeviceId { get; set; } public string Value { get; set; } public int DeviceSpecificInputId { get; set; } public Device Device { get; set; } }
public class DeviceSpecificInput { public int Id { get; set; } public int DeviceTypeId { get; set; } public string InputName { get; set; } public string InputLabel { get; set; } public string InputType { get; set; } public string InputValues { get; set; } public string InputPlaceholder { get; set; } public DeviceType DeviceType { get; set; } }
public class DeviceType { public int Id { get; set; } public string Name { get; set; } }
public class DeviceWarranty { public int Id { get; set; } public int? DeviceId { get; set; } public DateTime? StartDate { get; set; } public DateTime? EndDate { get; set; } public Device Device { get; set; } }
public class User { public int Id { get; set; } public int? DepartmentId { get; set; } public string Name { get; set; } public string Surname { get; set; } public string Email { get; set; } public Department Department { get; set; } }
