 using EmpApplication.Data.Repository;
using EmpApplication.Models;

namespace EmpApplication.BusinessLogic
{
    public class EmpBL
    {
        //Dependency Injection Of EmployeeDAL class
        private readonly IEmployeeDAL _employeeDAL;

        public EmpBL(EmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        public List<Employee> getEmployees()
        {
            return _employeeDAL.GetAllEmployees().ToList();
        }

        public Employee ? getEmpById(int id)
        {
            return id > 0 ? _employeeDAL.GetById(id) : null;
           
        }

        public void createEmp(Employee e)
        {
            if(e != null)
            {
                _employeeDAL.CreateEmp(e);
            }
        }

        public void updateEmp(Employee e , int id)
        {
            if (e != null)
            {
                _employeeDAL.UpdateEmp(e , id);
            }

        }

        public void removeEmp(int id)
        {
            if(id > 0)
            {
                _employeeDAL.DeleteEmp(id);
            }
        }
        


    }
}
