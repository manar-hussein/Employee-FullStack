using Employee.Contracts.Employee.Responses;

namespace Employee.Helper.CustomMapper
{
    public static class Mapper
    {
        public static EmployeeResponse ToEmployeeResponse(this Models.Employee employee)
        {
            return new EmployeeResponse
            {
                Id = employee.Id,
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position
            };
        }
    }
}
