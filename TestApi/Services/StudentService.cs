using Microsoft.EntityFrameworkCore;
using TestApi.Services;
using TestApi.Models.Entity;

namespace TestApi.Services
{
    public class StudentService : ServiceBase
    {

        public StudentService(AppDbContext studentDbContext) : base(studentDbContext)
        {

        }
        public async Task<List<Student>> GetAll()
        {
            return await _AppDbContext.Student.AsNoTracking().ToListAsync();
        }

        public async Task<bool> CreateAsync(Student student)
        {
            await _AppDbContext.Student.AddAsync(student);
            return await SaveAsync();
        }
    }
}
