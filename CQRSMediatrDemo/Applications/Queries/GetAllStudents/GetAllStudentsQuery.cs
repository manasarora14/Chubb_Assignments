using CQRSMediatrDemo.Models;
using MediatR;

namespace CQRSMediatrDemo.Requests.GetAllStudents
{
    public record GetAllStudentsQuery() : IRequest<IEnumerable<Student>>;
}
