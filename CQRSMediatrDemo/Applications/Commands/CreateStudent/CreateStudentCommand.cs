using MediatR;

namespace CQRSMediatrDemo.Commands.CreateStudent
{
    // Command data — request to create a student. Returns created student's Id.
    public record CreateStudentCommand(string FirstName, string LastName, string Email, DateTime DateOfBirth) : IRequest<int>;
}
