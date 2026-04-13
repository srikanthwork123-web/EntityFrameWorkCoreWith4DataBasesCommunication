namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos
{
    public class EmployeeDto
    {//[key] attribute not required here.data transfer purpose we will use]
        public int empid { get; set; }
        public string empname { get; set; }
        public int empsalary { get; set; }
    }
}
