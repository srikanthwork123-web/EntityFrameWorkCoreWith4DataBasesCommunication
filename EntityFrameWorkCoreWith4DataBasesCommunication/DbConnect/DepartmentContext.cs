using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.DbConnect
{
    public class DepartmentContext:DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options)
        {

        }
        //you need to register model class into DbSet<>placeholder section.
        public DbSet<Department> departments { get; set; }
        //All crud opertions related methods(like AdAsync(),update(),remove().....) comming from Dbset class.
        //DbContext class provides savechanges() method.to save the data permenently.
    }
}
