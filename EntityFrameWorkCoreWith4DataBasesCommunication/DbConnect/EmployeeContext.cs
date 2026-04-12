using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using Microsoft.EntityFrameworkCore;//need to import this package.
namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.DbConnect
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }
        //you need to register model class into DbSet<>placeholder section.
        public DbSet<Employee> Employees { get; set; }
    }
}
