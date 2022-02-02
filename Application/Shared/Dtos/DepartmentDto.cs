using DEMO.Application.Common.Mappings;
using DEMO.Application.Domain.Entities;

namespace DEMO.Application.Shared.Dtos
{
    public class DepartmentDto : IMapFrom<Department>
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
