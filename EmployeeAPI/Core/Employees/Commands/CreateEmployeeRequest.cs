using AutoMapper;
using DEMO.Application.Common.Mappings;
using DEMO.Application.Common.Models;
using DEMO.Application.Domain.Entities;
using DEMO.EmployeeAPI.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Core.Employees.Commands
{
    public class CreateEmployeeRequest : 
        IRequest<BaseResponse<CreateRecordResponse<long>>>,
        IMapFrom<Employee>
    {
        public EmployeeVm Employee { get; set; }
    }

    public class CreateEmployeeRequestHandler :
        IRequestHandler<CreateEmployeeRequest, BaseResponse<CreateRecordResponse<long>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateEmployeeRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateRecordResponse<long>>> Handle(
            CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Employee>(request.Employee);

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponse<CreateRecordResponse<long>>(
                new CreateRecordResponse<long>(entity.EmployeeId));
        }
    }
}
