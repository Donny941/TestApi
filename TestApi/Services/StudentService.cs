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

        private static StudentResponseDto ConvertResponse(Student student)
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
            .Where(s => !s.IsDeleted)
            .Include(s => s.Profile)
            .AsNoTracking()
            .ToListAsync();

            var result = new List<StudentResponseDto>();
            foreach (Student student in students)
            {
                result.Add(ConvertResponse(student));
            }

            return result;
        }

        private static Student ConvertStud(StudentCreateRequestDto dto)
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
            var student = ConvertStud(dto);
            await _AppDbContext.Student.AddAsync(student);
            return await SaveAsync();
        }

        public async Task<StudentResponseDto> UpdateAsync(Guid id, StudentUpdateRequestDto dto)
        {
            var student = await _AppDbContext.Student
                                .Include(s => s.Profile)
                                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                return null;
            }

            student.Name = dto.Name;
            student.LastName = dto.LastName;
            student.Email = dto.Email;

            await SaveAsync();

            return ConvertResponse(student);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var student = await _AppDbContext.Student
                                .Include(s => s.Profile)
                                .FirstOrDefaultAsync(s => s.Id == id);


            if (student == null)
            {
                return false;
            }

            student.IsDeleted = true;

            await SaveAsync();

            return true;
        }
    }
}
