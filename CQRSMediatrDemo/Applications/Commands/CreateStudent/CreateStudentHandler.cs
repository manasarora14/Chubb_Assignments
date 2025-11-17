using CQRSMediatrDemo.Data;
using CQRSMediatrDemo.Models;
using MediatR;

namespace CQRSMediatrDemo.Commands.CreateStudent
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);

            return student.Id;
        }
    }
}
