using EmpApplication.Data.Repository;
using EmpApplication.Models;

namespace EmpApplication.BusinessLogic
{
    public class StudentBL
    {
        private readonly IStudentDAL _studentDAL;

        public StudentBL(StudentDAL studentDAL)
        {
            this._studentDAL = studentDAL;
        }

        public List<Student> getStudents()
        {
            return _studentDAL.getAllStudents().ToList();
        }

        public Student ? getStudentById(int? id)
        {
            return id > 0 ? _studentDAL.getById(id) : null; 
        }

        public void createStu(Student student)
        {
            if(student != null)
            {
                _studentDAL.createStu(student);
            }
        }

        public void updateStu(Student student, int? id)
        {
            if(student != null)
            {
                _studentDAL.updateStu(student , id);
            }
        }

        public void removeStu(int? id)
        {
            if(id >0)
            {
                _studentDAL.deleteStu(id);
            }
        }
    }
}
