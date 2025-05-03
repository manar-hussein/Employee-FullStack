namespace Employee.Contracts.Employee.Responses
{
    public class EmployeesResponse
    {
        public IEnumerable<EmployeeResponse> Employees { get; init; } = Enumerable.Empty<EmployeeResponse>();
    }
}
