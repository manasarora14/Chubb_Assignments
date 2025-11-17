using CQRSMediatrDemo.Data;
using CQRSMediatrDemo.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatrDemo.Requests.GetAllStudents
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
    {
        private readonly AppDbContext _context;

        public GetAllStudentsHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            // AsNoTracking for read-only performance
            return await _context.Students.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
