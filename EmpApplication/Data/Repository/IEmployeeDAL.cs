using EmpApplication.Models;

namespace EmpApplication.Data.Repository
{
    public interface IEmployeeDAL
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee? GetById(int id);

        void CreateEmp(Employee e);
        void UpdateEmp(Employee e, int id);
        void DeleteEmp(int id);





    }
}
