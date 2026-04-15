using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int departmentid);
        Task<int> AddDepartment(Department departmentdetail);
        Task<bool> DeleteDepartmentById(int departmentid);
        Task<bool> UpdateDepartment(Department departmentdetail);
    }
}
