using CQRSMediatrDemo.Data;
using MediatR;

namespace CQRSMediatrDemo.Commands.DeleteStudent
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FindAsync(new object[] { request.Id }, cancellationToken);
            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
