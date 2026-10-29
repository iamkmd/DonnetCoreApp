using EmpApplication.BusinessLogic;
using EmpApplication.Models;
using Microsoft.AspNetCore.Mvc;


//In this Controller I have used the 
//Attribute Routing

namespace EmpApplication.Controllers
{
    //Defined The Route controller so It doesn't need any 
    //Prefix
    [Route("Student")]
    public class StudentController : Controller
    {
        //Dependecy Injection throght Construction
        //Dependency Injection of StudentBusinees layer

        private readonly StudentBL studentBL;

        public StudentController(StudentBL stuBL)
        {
            studentBL = stuBL;
        }

       
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View(studentBL.getStudents().ToList());

        }

        [HttpGet("Details/{id?}")]
        public IActionResult Details(int? id)
        {
            if(id == null | id == 0)
            {
                return NotFound();

            }

            Student student = studentBL.getStudentById(id);
            if(student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Student stu)
        {
            if(ModelState.IsValid)
            {
                studentBL.createStu(stu);
                return RedirectToAction("Index");
            }

            return View(stu);
        }


        [HttpGet("Edit/{id?}")]
        public IActionResult  Edit(int? id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            Student student = studentBL.getStudentById(id);
            if(student == null)
            {
                return NotFound();
            }

            return View(student);
        }


        [HttpPost("Edit/{id?}")]
        public IActionResult Edit(Student s, int? id)
        {
            if(s.id !=id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                studentBL.updateStu(s, id);
                return RedirectToAction("Index");
                
            }

            return View(s);


        }

        [HttpGet("Delete")]
        public  IActionResult Delete(int? id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            Student st = studentBL.getStudentById(id);

            if(st == null)
            {
                return NotFound();
            }

            return View(st);
        }

        [HttpPost("Delete/{id?}")]
        public IActionResult DeleteCon(int? id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            studentBL.removeStu(id);
            return RedirectToAction("Index");
        }
    }
}
