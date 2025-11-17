namespace CQRSMediatrDemo.Models
{
    public class Student
    {
        public int Id { get; set; }                 // primary key
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
    }
}
