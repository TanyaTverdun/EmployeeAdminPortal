namespace EmployeeAdminPortal.Employees.GetEmployeeById.Dtos
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
