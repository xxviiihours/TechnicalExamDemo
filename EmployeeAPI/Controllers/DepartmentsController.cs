using DEMO.EmployeeAPI.Core.Departments.Commands;
using DEMO.EmployeeAPI.Core.Departments.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Controllers
{
    public class DepartmentsController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] GetDepartmentsRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateDepartmentRequest request)
        {
            if (request == null)
                return BadRequest();

            return Result(await Mediator.Send(request));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] UpdateDepartmentRequest request)
        {
            if(request == null)
                return BadRequest();
            if (id <= 0)
                return BadRequest();
            if (id != request.Id)
                return BadRequest();

            return Result(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(await Mediator.Send(new DeleteDepartmentRequest { Id = id }));
        }
    }
}
