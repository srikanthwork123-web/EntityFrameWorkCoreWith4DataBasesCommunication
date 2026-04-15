using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        [Route("AddEmployee")]
        //Here modelbinder bind your request body data to your model class.
        public async Task<IActionResult> Post([FromBody] EmployeeDto empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {//if you are not pass any payload fom request body model binder will excute this if condition and  return 400badrequest error.
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _employeeService.AddEmployes(empdto);
                    return StatusCode(StatusCodes.Status201Created, empdata);
                }
            }
            catch (Exception ex)
            {//if you got any error we are using this statuscode:Status500InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpDelete]
        [Route("DeleteEmployeeByEmpid/{empid}")]
        public async Task<IActionResult> delete(int empid)
        {
            if (empid < 0)
            {//If input parameters are wrongly sent or empty, we will get 400 badrequest statuscode:Status400BadRequest
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var empdata = await _employeeService.DeleteEmployesById(empid);
                if (empdata == null)
                {//in db if you get empty data we need to retrun this statuscode:Status404NotFound
                    return StatusCode(StatusCodes.Status404NotFound, "empdata not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var empdata = await _employeeService.GetEmployees();
                if (empdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        [HttpGet]
        [Route("GetEmployeeByEmpid/{empid}")]
        public async Task<IActionResult> Get(int empid)
        {
            if (empid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var empdata = await _employeeService.GetEmployeeById(empid);
                return StatusCode(StatusCodes.Status200OK, empdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> put([FromBody] EmployeeDto empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _employeeService.UpdateEmploye(empdto);
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
    }
}
/*1.Can you please explain Entitty Frameworkcodefirst appraoch process?
========================================================================
 =>By using Codefirst approach we are generting the database and tables , based on entityclasses or model classes.
 Step1:=>To implement Codefirst Approach first install 3 packages
 1.microsoft.entityframeworkcore(8.0.0)-- this version is used for .Net 8.0[ex:if u use .net6.0 version ,u will use entityframeworkcore (6.0.0)]
 2.microsoft.entityframeworkcore.sqlserver(8.0.0)--[package is used to communicate with a sql server database]
 3.microsoft.entityframeworkcore.tools(8.0.0)--[package is used to excute the entityframework core commands in package manager console window]
======================
Step2:=>Next creare the connection string in appsettings.json
Step3:=>create the modelclasses/entity classes
Step4:=>these entity classes register in the context class by using dbset<modelclassname>
Step5:=>After that register your contextclassname in program.cs by using  builder.Services.AddDbContext<contextclassname>(place your connectionstring)
Step6:=>once you preapre these steps, after that we need to run 2 commands for generting the database.
1.ADD-MIGRATION Migrationname  --command used to generate the migration folder.[which contains meta data of entity clases]
2.UPDATE-DATABASE    --command is used to generate the database from developer side in .netcore
NOTE:if u r not using these commands,database not generated.
==================================


2.for example if you have more than one context file is available  how you will apply the migrtions.can you explain the process?
====================================================
####################Facing Issues with Multiple Context Files#################################
In your dotnet core project if you communicate with 3 databases ,you will get 3 Context files.if you want to update any context file you must specify context name.
iF you want to communicate with multiple databases in dotnet core project  we need to fallow these rules.
other wise you will face this below issue.

====================multiple context class updation error====
ERROR:More than one DbContext was found. Specify which one to use. 
Use the '-Context' parameter for PowerShell commands and the '--context' parameter for dotnet commands.
=======================To fix this above issue we fallowed below commands==============
=============iF you want to communicate with multiple databases in dotnet core project  we need to fallow these rules.
======syntax for code first approcah updations=======

Add-Migration MigrationName -Context ContextClassName
 
update-database -Context ContextClassName

Note:
1)Here Migration name you can give any migrationName.
2)Make sure you need to mention the context classname.other wise it will throw the above error.
 
===========Usageof CodeFirst approach updations=======
 
Add-Migration Project -Context EmployeeManagementContext
 
update-database -Context EmployeeManagementContext
==================================================


 */