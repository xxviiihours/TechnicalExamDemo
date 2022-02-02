using Audit.EntityFramework;
using DEMO.Application.Domain.Entities;
using DEMO.Application.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DEMO.EmployeeAPI.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        private static readonly DbContextHelper _helper = new();
        private readonly IHttpContextAccessor _contextAccessor;

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        public DbSet<EmployeeStatusDto> EmployeeStatus { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
            options, IHttpContextAccessor contextAccessor)
            : base(options)
        {
            _contextAccessor = contextAccessor;
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }

  
}
