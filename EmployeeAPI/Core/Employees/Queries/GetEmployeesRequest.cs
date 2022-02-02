using AutoMapper;
using AutoMapper.QueryableExtensions;
using DEMO.Application.Common.Models;
using DEMO.Application.Shared.Dtos;
using DEMO.EmployeeAPI.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Core.Employees.Queries
{
    public class GetEmployeesRequest : 
        IRequest<BaseResponse<List<EmployeeDto>>>
    {
        public string Query { get; set; }
    }

    public class GetEmployeesRequestHandler : 
        IRequestHandler<GetEmployeesRequest, BaseResponse<List<EmployeeDto>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEmployeesRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<EmployeeDto>>> Handle(
            GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var query = _context.Employees
                .Include(p=>p.Department)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(request.Query))
            {
                query = query.Where(p => 
                    p.FirstName.Contains(request.Query) || 
                    p.MiddleName.Contains(request.Query) ||
                    p.LastName.Contains(request.Query) ||
                    p.Department.Name.Contains(request.Query));
            }

            var result = await query
                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new BaseResponse<List<EmployeeDto>>(result);
        }
    }
}
