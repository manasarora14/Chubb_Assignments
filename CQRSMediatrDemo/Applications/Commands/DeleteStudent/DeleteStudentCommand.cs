using MediatR;

namespace CQRSMediatrDemo.Commands.DeleteStudent
{
    public record DeleteStudentCommand(int Id) : IRequest<bool>;
}
