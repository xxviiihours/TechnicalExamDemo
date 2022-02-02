using AutoMapper;
using DEMO.Application.Common.Mappings;
using DEMO.Application.Common.Models;
using DEMO.Application.Domain.Entities;
using DEMO.EmployeeAPI.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Core.Departments.Commands
{
    public class CreateDepartmentRequest : 
        IRequest<BaseResponse<CreateRecordResponse<int>>>,
        IMapFrom<Department>
    {
        public DepartmentVm Department { get; set; }
    }

    public class CreateDepartmentRequestHandler : 
        IRequestHandler<CreateDepartmentRequest, 
            BaseResponse<CreateRecordResponse<int>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateDepartmentRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateRecordResponse<int>>> Handle(CreateDepartmentRequest request,
            CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Department>(request.Department);

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new BaseResponse<CreateRecordResponse<int>>(
                new CreateRecordResponse<int>(entity.DepartmentId));
        }
    }
}
