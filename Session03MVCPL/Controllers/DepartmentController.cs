using Microsoft.AspNetCore.Mvc;
using Session03MVCBLL.Interfaces;
using Session03MVCBLL.Repositories;
using Session03MVCEDAL.Data;
using Session03MVCEDAL.Models;

namespace Session03MVCPL.Controllers
{
    // Inheritance : DepartmentController is  a Controller
    // Association : DepartmentController has a IDepartmentRepositories
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepositories _departmentRepo; // Null

        public DepartmentController(IDepartmentRepositories departmentRepo) // Ask CLR for Creating an Object From Class Implementing IDepartmentRepositories
        {
            _departmentRepo = departmentRepo;
        }
        public IActionResult Index()
        {
            var departments = _departmentRepo.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) // Server Side Vaildation
            {
                var count = _departmentRepo.Add(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

    }
}
