using DEMO.EmployeeAPI.Core.Employees.Commands;
using DEMO.EmployeeAPI.Core.Employees.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] GetEmployeesRequest request)
        {

            return Ok(await Mediator.Send(request));

        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateEmployeeRequest request)
        {
            if (request == null)
                return BadRequest();

            return Result(await Mediator.Send(request));

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(long id, [FromBody] UpdateEmployeeRequest request)
        {
            if (request == null)
                return BadRequest();
            if (id <= 0)
                return BadRequest();
            if (id != request.Id)
                return BadRequest();

            return Result(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(await Mediator.Send(new DeleteEmployeeRequest { Id = id }));
        }
    }
}
