using TestApi.Models.Entity;
using TestApi.Models.Entity;

namespace TestApi.Services
{
    public class ServiceBase
    {
        protected readonly AppDbContext _AppDbContext;

        protected ServiceBase(AppDbContext AppDbContext)
        {
            _AppDbContext = AppDbContext;
        }

        protected async Task<bool> SaveAsync()
        {
            bool result = false;

            try
            {
                result = await _AppDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
