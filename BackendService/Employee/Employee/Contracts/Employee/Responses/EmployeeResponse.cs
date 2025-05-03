namespace Employee.Contracts.Employee.Responses
{
    public record EmployeeResponse
    {
        public required int Id { get; init; }
        public required string FirstName { get; init; } = null!;
        public required string LastName { get; init; } = null!;
        public required string Email { get; init; } = null!;
        public required string Position { get; init; } = null!;
    }
}
