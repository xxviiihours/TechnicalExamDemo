using DEMO.Application.Common.Mappings;
using DEMO.Application.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Core.Employees.Commands
{
    public class EmployeeVm : IMapFrom<Employee>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public int? DepartmentId { get; set; }
        public bool IsActive { get; set; }
    }
}
