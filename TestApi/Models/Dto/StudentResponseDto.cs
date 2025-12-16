namespace TestApi.Models.Dto
{
    public class StudentResponseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string? ProfileFirstName { get; set; }
        public string? ProfileLastName { get; set; }
    }
}
