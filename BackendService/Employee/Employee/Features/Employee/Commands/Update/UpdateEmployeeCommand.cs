using Employee.Contracts.Employee.Requests;
using MediatR;

namespace Employee.Features.Employee.Commands.Update
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public UpdateEmployeeRequest UpdateEmployeeRequest { get; init; } = null!;
    }
}
