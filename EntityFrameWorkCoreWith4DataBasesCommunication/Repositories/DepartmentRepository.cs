using EntityFrameWorkCore_CodeFirst_4DBCommunication.DbConnect;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DepartmentContext _departmentcontext;

        public DepartmentRepository(DepartmentContext departmentcontext)
        {
            _departmentcontext = departmentcontext;
        }
        public async Task<int> AddDepartment(Department departmentdetail)
        {//add the record by using addasync() method 
            await _departmentcontext.departments.AddAsync(departmentdetail);
            _departmentcontext.SaveChanges();//it will commit/save the data perminently in table
            return 1;
        }

        public async Task<bool> DeleteDepartmentById(int departmentid)
        {
            var result = await _departmentcontext.departments.Where(a => a.DepartmentId == departmentid).FirstOrDefaultAsync();
            if (result == null)
            {

                return false;
            }
            else
            {//Remove() metho is used to remove the data.
                _departmentcontext.departments.Remove(result);
                _departmentcontext.SaveChanges();
                return true;
            }
        }

        public async Task<Department> GetDepartmentById(int departmentid)
        {
            var result = await _departmentcontext.departments.Where(a => a.DepartmentId == departmentid).FirstOrDefaultAsync();
            if (result == null)
            {//if result having no data i am returning null here.null means nothing.
                return null;
            }
            else
            {
                return result;
            }
        }

        public async  Task<List<Department>> GetDepartments()
        {
            var result = await _departmentcontext.departments.ToListAsync();
            if(result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<bool> UpdateDepartment(Department departmentdetail)
        {
            _departmentcontext.departments.Update(departmentdetail);
            await _departmentcontext.SaveChangesAsync();
            return true;
        }
    }
}
