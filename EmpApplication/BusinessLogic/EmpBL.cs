using EmpApplication.Data.Repository;
using EmpApplication.Models;

namespace EmpApplication.BusinessLogic
{
    public class EmpBL
    {
        //Dependency Injection Of EmployeeDAL class
        private readonly EmployeeDAL employeeDAL;

        public EmpBL(EmployeeDAL employeeDAL)
        {
            this.employeeDAL = employeeDAL;
        }

        public List<Employee> getEmployees()
        {
            return employeeDAL.GetAllEmployees().ToList();
        }

        public Employee ? getEmpById(int id)
        {
            return id > 0 ? employeeDAL.GetById(id) : null;
           
        }

        public void createEmp(Employee e)
        {
            if(e != null)
            {
                employeeDAL.CreateEmp(e);
            }
        }

        public void updateEmp(Employee e)
        {
            if (e != null)
            {
                employeeDAL.UpdateEmp(e);
            }

        }

        public void removeEmp(int id)
        {
            if(id > 0)
            {
                employeeDAL.DeleteEmp(id);
            }
        }
        


    }
}
