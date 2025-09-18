using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Extensions
{
    public static class EmployeeExtentions
    {
        public static void CopyFrom(this Employee employee, Employee copyFrom)
        {
            employee.Name = copyFrom.Name;
            employee.Email = copyFrom.Email;
            employee.Phone = copyFrom.Phone;
            employee.Salary = copyFrom.Salary;
        }
    }
}
