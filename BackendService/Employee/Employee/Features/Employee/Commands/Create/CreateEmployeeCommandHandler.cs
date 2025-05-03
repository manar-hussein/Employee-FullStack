using Employee.Contracts.Employee.Responses;
using Employee.Helper.CustomMapper;
using Employee.Repository;
using Mapster;
using MediatR;

namespace Employee.Features.Employee.Commands.Create
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {
        private readonly EmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = request.Adapt<Models.Employee>();
            employee = await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveAsync();
            var employeeResponse = employee.ToEmployeeResponse();
            return employeeResponse;
        }
    }
}
