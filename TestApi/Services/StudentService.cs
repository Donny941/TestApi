using Microsoft.EntityFrameworkCore;
using TestApi.Models.Dto;
using TestApi.Models.Entity;
using TestApi.Services;

namespace TestApi.Services
{
    public class StudentService : ServiceBase
    {

        public StudentService(AppDbContext studentDbContext) : base(studentDbContext)
        {

        }

        private static StudentResponseDto Convert(Student student)
        {
            StudentResponseDto stud = new StudentResponseDto()
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Email = student.Email,
                ProfileFirstName = student.Profile?.FirstName,
                ProfileLastName = student.Profile?.LastName
            };
            return stud;
        }

        public async Task<List<StudentResponseDto>> GetAll()
        {
            var students = await _AppDbContext.Student
            .Include(s => s.Profile)
            .AsNoTracking()
            .ToListAsync();

            var result = new List<StudentResponseDto>();
            foreach (Student student in students)
            {
                result.Add(Convert(student));
            }

            return result;
        }

        private static Student Convert(StudentCreateRequestDto dto)
        {
            Student stud = new Student()
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Email = dto.Email,
            };
            return stud;
        }

        public async Task<bool> CreateAsync(StudentCreateRequestDto dto)
        {
            var student = Convert(dto);
            await _AppDbContext.Student.AddAsync(student);
            return await SaveAsync();
        }
    }
}
