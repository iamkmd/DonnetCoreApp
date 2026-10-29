using EmpApplication.Models;

namespace EmpApplication.Data.Repository
{
    public interface IStudentDAL
    {
        IEnumerable<Student> getAllStudents();

        Student? getById(int? id);

        void createStu(Student st);

        void updateStu(Student st , int? id);

        void deleteStu(int? id);






    }
}
