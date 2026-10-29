using EmpApplication.BusinessLogic;
using EmpApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpApplication.Controllers
{
    public class EmployeeController : Controller
    {

        //Depedency Injection through Construction 
        //Dependency Injection of EmployeeBusiness Layer
        private readonly EmpBL empBusinessLayer;

        public EmployeeController(EmpBL empBL)
        {
            empBusinessLayer = empBL;
        }


        public IActionResult Index()
        {
            return View(empBusinessLayer.getEmployees().ToList());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Employee emp = empBusinessLayer.getEmpById(id);
            if(emp== null)
            {
                return NotFound();
            }

            return View(emp);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if(ModelState.IsValid)
            {
                empBusinessLayer.createEmp(emp);
               return RedirectToAction(nameof(Index));
            }
            return View(emp);

        }

        [HttpGet]
        public IActionResult Edit(int id)

        {
            if(id == null)
            {
                return NotFound();
            }

            Employee emp = empBusinessLayer.getEmpById(id);
            if(emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }


        [HttpPost]
        public IActionResult Edit(Employee emp, int id)
        {
            if(emp.EID != id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                empBusinessLayer.updateEmp(emp , id);
                return RedirectToAction(nameof(Index));

            }
            return View(emp);
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Employee emp = empBusinessLayer.getEmpById(id);

            if(emp == null)
            {
                return NotFound(id);
            }
            return View(emp);

           
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            empBusinessLayer.removeEmp(id);
            return RedirectToAction("Index");
        }
    }
}
