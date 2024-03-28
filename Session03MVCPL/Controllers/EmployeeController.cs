using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Session03MVCBLL.Interfaces;
using Session03MVCEDAL.Models;
using System;
using System.Linq;

namespace Session03MVCPL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepositories _EmployeeRepo; // Null
        public IWebHostEnvironment _ev { get; }
        public IDepartmentRepositories _departmentRepos { get; }

        public EmployeeController(IEmployeeRepositories EmployeeRepo, IWebHostEnvironment ev,IDepartmentRepositories _departmentsRepo) // Ask CLR for Creating an Object From Class Implementing IEmployeeRepositories
        {
            _EmployeeRepo = EmployeeRepo;
            _ev = ev;
            _departmentRepos = _departmentsRepo;
        }
        public IActionResult Index(string searchInput)
        {
            //// 1. ViewData
            //ViewData["Message"] = "Hello ViewData";

            //// 2. ViewBag
            //ViewBag.Message = "Hello ViewBag";
            var employees = Enumerable.Empty<Employee>();

            if (string.IsNullOrEmpty(searchInput))
                employees = _EmployeeRepo.GetAll();
            else
                employees = _EmployeeRepo.SearchByName(searchInput.ToLower());

            return View(employees);
        }
        //[HttpGet]
        public IActionResult Create()
        {
            //ViewData["Departments"] = _departmentRepos.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee Employee)
        {
            if (ModelState.IsValid) // Server Side Vaildation
            {
                var count = _EmployeeRepo.Add(Employee);

                // 3. TempData
                if (count > 0)
                    TempData["Message"] = "Employee is created Successfully";
                else
                    TempData["Message"] = " An Error Occured, Employee Not Created";

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        public IActionResult Details(int? Id, string ViewName = "Details")
        {
            if (!Id.HasValue)
                return BadRequest(); // 400

            var Employee = _EmployeeRepo.GetById(Id.Value);

            if (Employee is null)
                return NotFound(); // 404

            return View(Employee);
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            ///if(!Id.HasValue)
            ///    return BadRequest();
            ///var Employee = _EmployeeRepo.GetById(Id.Value);
            ///if(Employee is null)
            ///    return NotFound();
            ///return View(Employee);
            
            //ViewBag.Departments = _departmentRepos.GetAll();
            return Details(Id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int Id, Employee Employee)
        {
            if (Id != Employee.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(Employee);

            try
            {
                _EmployeeRepo.Update(Employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log Exception 
                // Friendly Message

                if (_ev.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "An Error Has Occured during Updating the Employee");

                return View(Employee);
            }

        }
        public IActionResult Delete(int? Id)
        {
            return Details(Id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete(Employee Employee)
        {
            try
            {
                _EmployeeRepo.Delete(Employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log Exception 
                // Friendly Message

                if (_ev.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "An Error Has Occured during Updating the Employee");
                return View(Employee);
            }
        }
    }
}
