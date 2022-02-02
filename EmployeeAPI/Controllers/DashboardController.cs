using DEMO.EmployeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("status")]
        public async Task<ActionResult> GetEmployeeStatus()
        {
            var result = await _dashboardService.GetTotalStatus();
            return Ok(result);
        }
    }
}
