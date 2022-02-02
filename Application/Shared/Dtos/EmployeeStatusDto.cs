using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DEMO.Application.Shared.Dtos
{
    [Keyless]
    public class EmployeeStatusDto
    {
        public int TotalInactive { get; set; }
        public int TotalActive { get; set; }
    }
}
