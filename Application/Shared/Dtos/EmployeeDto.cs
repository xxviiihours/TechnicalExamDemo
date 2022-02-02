using DEMO.Application.Common.Mappings;
using DEMO.Application.Domain.Entities;

namespace DEMO.Application.Shared.Dtos
{
    public class EmployeeDto : IMapFrom<Employee>
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public int? DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }
        public bool IsActive { get; set; }
    }
}
