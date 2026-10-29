using System.ComponentModel.DataAnnotations;

namespace EmpApplication.Models
{
    public class Employee
    {
        public int EID { get; set; }

        [Required (ErrorMessage = "Employee Name is Required")]
        public string Ename { get; set; }
        
        [Required (ErrorMessage ="Department Is Required")]
        public int DeptId { get; set; }

        [Required (ErrorMessage = "Salary is required")]
       public Decimal Salary { get; set; }

        [Required (ErrorMessage ="Date Of Joining is Required")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DOJ { get; set; }
    }
}
