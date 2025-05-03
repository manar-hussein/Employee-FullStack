using Employee.Repository;
using Mapster;
using MediatR;

namespace Employee.Features.Employee.Commands.Update
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly EmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.UpdateEmployeeRequest.Id);
            request.UpdateEmployeeRequest.Adapt(employee);
            var result = await _employeeRepository.UpdateAsync(employee);
            await _employeeRepository.SaveAsync();
            return result;
        }
    }
}
