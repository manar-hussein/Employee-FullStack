namespace Employee.Contracts.Employee.Requests
{
    public class UpdateEmployeeRequest
    {
        public int Id { get; init; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Position { get; set; } = null!;
    }
}
