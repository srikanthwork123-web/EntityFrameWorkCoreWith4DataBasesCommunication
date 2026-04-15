using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces
{
    public interface IDeparmentService
    {
        Task<List<DepartmentDto>> GetDepartments();
        Task<DepartmentDto> GetDepartmentById(int deptid);
        Task<int> AddDepartments(DepartmentDto deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(DepartmentDto deptdetail);
    }
}
