using System.ComponentModel.DataAnnotations;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities
{
    public class Employee
    {
        [Key]
        public int empid { get; set; }
        public string empname { get; set; }
        public int empsalary { get; set; }
    }
}
