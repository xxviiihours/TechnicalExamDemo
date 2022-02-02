using DEMO.Application.Common.Mappings;
using DEMO.Application.Domain.Entities;

namespace DEMO.EmployeeAPI.Core.Departments.Commands
{
    public class DepartmentVm : IMapFrom<Department>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
