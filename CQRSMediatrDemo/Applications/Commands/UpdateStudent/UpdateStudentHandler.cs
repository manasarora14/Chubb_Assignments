using CQRSMediatrDemo.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatrDemo.Commands.UpdateStudent
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(new object[] { request.Id }, cancellationToken);
            if (student == null) return false;

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Email = request.Email;
            student.DateOfBirth = request.DateOfBirth;

            _context.Students.Update(student);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
