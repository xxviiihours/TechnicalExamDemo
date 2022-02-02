using AutoMapper;
using DEMO.Application.Common.Exceptions;
using DEMO.Application.Common.Models;
using DEMO.Application.Domain.Entities;
using DEMO.EmployeeAPI.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Core.Employees.Commands
{
    public class DeleteEmployeeRequest : 
        IRequest<BaseResponse<long>>
    {
        public long Id { get; set; }
    }

    public class DeleteEmployeeRequestHandler : 
        IRequestHandler<DeleteEmployeeRequest, BaseResponse<long>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteEmployeeRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<long>> Handle(
            DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employees.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Employee), request.Id);

            _context.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponse<long>(request.Id);
        }
    }
}
