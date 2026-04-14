using EntityFrameWorkCore_CodeFirst_4DBCommunication.DbConnect;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //In entityFramework core datasource is our context class.
        //in entityframework core we are using linq queries.

        private readonly EmployeeContext _employeeContext;
        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task<int> AddEmployes(Employee empdetail)
        {
            //TO implement ASYNCHRONOUS PROGRAMING USE ASYNC AND AWAIT KEWYORDS ALONG WITH TASK
            //AddAsync(Object)=>It will insert record into  resepective modelclass table.
            await _employeeContext.Employees.AddAsync(empdetail);
            
            _employeeContext.SaveChanges();//
            //SaveChanges() method used to save the data permenetly into table purpose used.
            //SaveChanges() is similar to sqlserver commit.commit means perminetly save the data into database.
            return 1;
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
            //to get the one record based on id we can go with firstorderaultasync () with where condition.
            //sqlquery is:select * from employee where empid=2;
           Employee empObj=await _employeeContext.Employees.Where(a=>a.empid ==empid).FirstOrDefaultAsync();
            if (empObj != null)
            {
                _employeeContext.Employees.Remove(empObj);
                _employeeContext.SaveChanges();
                return true;
            }
            return false;

        }

        public async Task<Employee> GetEmployeeById(int empid)
        {//here return type is Employee it will except employee class object.
            var rm = await _employeeContext.Employees.Where(e => e.empid == empid).FirstOrDefaultAsync();

            if (rm == null)
            {
                return null;
            }
            else
                return rm;
        }

        public async Task<List<Employee>> GetEmployees()
        {//ToList() method is used to fetch the total data from the table
            var result =await  _employeeContext.Employees.ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<bool> UpdateEmploye(Employee empdetail)
        {
            _employeeContext.Employees.Update(empdetail);
            await  _employeeContext.SaveChangesAsync();
            return true;
        }
    }
}
