using AutoMapper;
using DEMO.Application.Common.Exceptions;
using DEMO.Application.Common.Mappings;
using DEMO.Application.Common.Models;
using DEMO.Application.Domain.Entities;
using DEMO.EmployeeAPI.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Core.Departments.Commands
{
    public class UpdateDepartmentRequest : 
        IRequest<BaseResponse<Department>>,
        IMapFrom<Department>
    {
        public int Id { get; set; }
        public DepartmentVm Department { get; set; }
    }

    public class UpdateDepartmentRequestHandler :
        IRequestHandler<UpdateDepartmentRequest,
            BaseResponse<Department>>
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateDepartmentRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Department>> Handle(
            UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Departments.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Department), request.Id);

            _mapper.Map(request.Department, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponse<Department>(entity);
        }
    }
}
