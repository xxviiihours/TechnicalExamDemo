using AutoMapper;
using AutoMapper.QueryableExtensions;
using DEMO.Application.Common.Models;
using DEMO.Application.Shared.Dtos;
using DEMO.EmployeeAPI.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Core.Departments.Queries
{
    public class GetDepartmentsRequest : IRequest<BaseResponse<List<DepartmentDto>>>
    {
        public string Query { get; set; }
    }
    public class GetDepartmentsRequestHandler : IRequestHandler<GetDepartmentsRequest, BaseResponse<List<DepartmentDto>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetDepartmentsRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<DepartmentDto>>> Handle(GetDepartmentsRequest request, CancellationToken cancellationToken)
        {
            var query = _context.Departments
                .AsNoTracking();

            if (!string.IsNullOrEmpty(request.Query))
            {
                query = query.Where(p => p.Name.Contains(request.Query));
            }

            var result = await query
                .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new BaseResponse<List<DepartmentDto>>(result);
        }
    }
}
