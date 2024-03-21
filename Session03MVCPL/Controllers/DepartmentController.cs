using Microsoft.AspNetCore.Mvc;
using Session03MVCBLL.Interfaces;
using Session03MVCBLL.Repositories;
using Session03MVCEDAL.Data;

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
            return View();
        }
    }
}
