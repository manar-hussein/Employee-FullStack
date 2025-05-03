using Employee.Repository;
using MediatR;

namespace Employee.Features.Employee.Commands.Delete
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int Id { get; init; }
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly EmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee is null)
                return false;
            await _employeeRepository.Delete(employee);
            await _employeeRepository.SaveAsync();
            return true;
        }
    }

}
