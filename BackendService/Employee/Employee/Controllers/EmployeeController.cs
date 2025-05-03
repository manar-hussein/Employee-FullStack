using Employee.Contracts.Employee.Requests;
using Employee.Features.Employee.Commands.Create;
using Employee.Features.Employee.Commands.Delete;
using Employee.Features.Employee.Commands.Update;
using Employee.Features.Employee.Queries.GetAll;
using Employee.Features.Employee.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("Employees")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int index, int size)
        {
            var employees = await _mediator.Send(new GetAllEmployeesQuery { Index = index, Size = size });
            return Ok(employees);
        }

        [Route("Employees/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });
            if (employee is null)
                return NotFound(employee);
            return Ok(employee);
        }

        [Route("Employees")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand employeeRequest)
        {
            var employee = await _mediator.Send(employeeRequest);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [Route("Employees/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateEmployeeRequest employee)
        {
            var updated = await _mediator.Send(new UpdateEmployeeCommand { UpdateEmployeeRequest = employee });
            if (!updated)
                return NotFound();
            return Ok(employee);
        }

        [Route("Employees/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _mediator.Send(new DeleteEmployeeCommand { Id = id });
            if (!deleted)
                return NotFound();
            return Ok();
        }

    }
}
