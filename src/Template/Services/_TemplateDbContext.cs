using SunStorage.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SunStorage.Services.Shared;

namespace SunStorage.Services
{
    public class SunStorageDbContext : DbContext
    {
        public SunStorageDbContext()
        {
        }

        public SunStorageDbContext(DbContextOptions<SunStorageDbContext> options) : base(options)
        {
            DataGenerator.InitializeUsers(this);
        }

        public DbSet<User> Users { get; set; }
    }
}
