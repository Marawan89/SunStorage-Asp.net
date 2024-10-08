using Microsoft.EntityFrameworkCore;
using Template.Services.Shared;
using Template.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Template.Services
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext()
        {
        }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
            DataGenerator.InitializeUsers(this);
            DataGenerator.InitializeDevices(this);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SerialNumber).IsRequired();
                entity.Property(e => e.DeviceTypeName).IsRequired();
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
