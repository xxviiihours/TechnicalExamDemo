using AutoMapper;
using DEMO.Application.Common.Exceptions;
using DEMO.Application.Common.Mappings;
using DEMO.Application.Common.Models;
using DEMO.Application.Domain.Entities;
using DEMO.EmployeeAPI.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Core.Employees.Commands
{
    public class UpdateEmployeeRequest : 
        IRequest<BaseResponse<Employee>>,
        IMapFrom<Employee>
    {
        public long Id { get; set; }
        public EmployeeVm Employee { get; set; }
    }

    public class UpdateEmployeeRequestHandler : IRequestHandler<UpdateEmployeeRequest, BaseResponse<Employee>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateEmployeeRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Employee>> Handle(
            UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employees.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Employee), request.Id);

            _mapper.Map(request.Employee, entity);

            await _context.SaveChangesAsync();

            return new BaseResponse<Employee>(entity);
        }
    }
}
