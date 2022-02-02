using DEMO.Application.Common.Exceptions;
using DEMO.Application.Common.Models;
using DEMO.Application.Domain.Entities;
using DEMO.EmployeeAPI.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Core.Departments.Commands
{
    public class DeleteDepartmentRequest : IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDepartmentRequestHandler :
        IRequestHandler<DeleteDepartmentRequest, BaseResponse<int>>
    {

        private readonly ApplicationDbContext _context;

        public DeleteDepartmentRequestHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse<int>> Handle(DeleteDepartmentRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Departments.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Department), request.Id);

            _context.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponse<int>(request.Id);

        }
    }
}
