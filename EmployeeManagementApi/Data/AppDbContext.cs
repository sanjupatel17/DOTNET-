using Microsoft.EntityFrameworkCore;
using EmployeeManagementApi.Models;  // 👈 VERY IMPORTANT

namespace EmployeeManagementApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
