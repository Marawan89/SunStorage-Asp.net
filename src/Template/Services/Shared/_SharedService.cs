namespace SunStorage.Services.Shared
{
    public partial class SharedService
    {
        SunStorageDbContext _dbContext;

        public SharedService(SunStorageDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
