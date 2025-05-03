using Employee.Contracts.Employee.Responses;
using MediatR;

namespace Employee.Features.Employee.Commands.Create
{
    public class CreateEmployeeCommand : IRequest<EmployeeResponse>
    {
        public required string FirstName { get; init; } = null!;
        public required string LastName { get; init; } = null!;
        public required string Email { get; init; } = null!;
        public required string Position { get; init; } = null!;
    }
}
