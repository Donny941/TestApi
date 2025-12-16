namespace TestApi.Models.Entity
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public StudentProfile? Profile { get; set; }
    }
}
