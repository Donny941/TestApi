namespace TestApi.Models.Dto
{
    public class StudentProfileUpdateRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FiscalCode { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
