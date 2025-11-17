using MediatR;

namespace CQRSMediatrDemo.Commands.UpdateStudent
{
    // Update student; returns bool indicating success.
    public record UpdateStudentCommand(int Id, string FirstName, string LastName, string Email, DateTime DateOfBirth) : IRequest<bool>;
}
