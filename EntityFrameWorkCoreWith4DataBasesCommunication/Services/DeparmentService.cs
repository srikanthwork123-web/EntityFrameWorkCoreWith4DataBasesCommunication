using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;


namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Services
{
    public class DeparmentService : IDeparmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeparmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<int> AddDepartments(DepartmentDto deptdetail)
        {
            //In future this code was replaced by automapper conncept.
            Department dept = new Department();
            dept.DepartmentId = deptdetail.DepartmentId;
            dept.DepartmentName = deptdetail.DepartmentName;
            dept.DepartmentLocation = deptdetail.DepartmentLocation;
            dept.EmployeeName = deptdetail.EmployeeName;    
            var res = await _departmentRepository.AddDepartment(dept);
            return res;
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            await _departmentRepository.DeleteDepartmentById(deptid);
            return true;
        }

        public async Task<DepartmentDto> GetDepartmentById(int deptid)
        {
            var res = await _departmentRepository.GetDepartmentById(deptid);
            DepartmentDto deptdto = new DepartmentDto();
            deptdto.DepartmentId = res.DepartmentId;
            deptdto.DepartmentName = res.DepartmentName;
            deptdto.DepartmentLocation = res.DepartmentLocation;
            deptdto.EmployeeName= res.EmployeeName;
            return deptdto;
        }

        public async Task<List<DepartmentDto>> GetDepartments()
        {
            List<DepartmentDto> lstdeptdto = new List<DepartmentDto>();
            var res = await _departmentRepository.GetDepartments();
            foreach (Department dept in res)
            {
                DepartmentDto deptDto = new DepartmentDto();
                deptDto.DepartmentId = dept.DepartmentId;
                deptDto.DepartmentName = dept.DepartmentName;
                deptDto.DepartmentLocation = dept.DepartmentLocation;
                deptDto.EmployeeName = dept.EmployeeName;
                lstdeptdto.Add(deptDto);

            }
            return lstdeptdto;
        }

        public async Task<bool> UpdateDepartment(DepartmentDto deptdetail)
        {
            Department dept = new Department();
            dept.DepartmentId = deptdetail.DepartmentId;
            dept.DepartmentName = deptdetail.DepartmentName;
            dept.DepartmentLocation = deptdetail.DepartmentLocation;
            dept.EmployeeName= deptdetail.EmployeeName;
            await _departmentRepository.UpdateDepartment(dept);
            return true;
        }
    }
}
