using DEMO.Application.Shared.Dtos;
using DEMO.EmployeeAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Services
{
    public interface IDashboardService
    {
        Task<EmployeeStatusDto> GetTotalStatus();
    }
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeStatusDto> GetTotalStatus()
        {
            var result = await _context.EmployeeStatus
                .FromSqlRaw(@"SELECT 
	                    SUM(CASE WHEN isActive = 1 THEN 1 ELSE 0 END) as totalActive, 
	                    SUM(CASE WHEN isActive = 0 THEN 1 ELSE 0 END) as totalInactive
                    FROM Employee").FirstOrDefaultAsync();

            return result;
        }
    }
}
