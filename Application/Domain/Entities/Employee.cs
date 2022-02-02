
namespace DEMO.Application.Domain.Entities
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public int? DepartmentId { get; set; }
        public bool IsActive { get; set; }
        public Department Department { get; set; }
    }
}
