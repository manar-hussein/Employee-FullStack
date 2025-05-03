using Employee.Contracts.Employee.Responses;
using Employee.Helper.CustomMapper;
using Employee.Repository;
using MediatR;

namespace Employee.Features.Employee.Queries.GetById
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeResponse>
    {
        public int Id { get; init; }
    }

    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>
    {
        private readonly EmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            var employeeResponse = employee.ToEmployeeResponse();
            return employeeResponse;
        }
    }
}
