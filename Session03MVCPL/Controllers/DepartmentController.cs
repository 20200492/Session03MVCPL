using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using Session03MVCBLL.Interfaces;
using Session03MVCBLL.Repositories;
using Session03MVCEDAL.Data;
using Session03MVCEDAL.Models;
using System;

namespace Session03MVCPL.Controllers
{
    // Inheritance : DepartmentController is  a Controller
    // Association : DepartmentController has a IDepartmentRepositories
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepositories _departmentRepo; // Null
        public IWebHostEnvironment _ev { get; }
        public DepartmentController(IDepartmentRepositories departmentRepo, IWebHostEnvironment ev) // Ask CLR for Creating an Object From Class Implementing IDepartmentRepositories
        {
            _departmentRepo = departmentRepo;
            _ev = ev;
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
        public IActionResult Details(int? Id,string ViewName ="Details")
        {
            if (!Id.HasValue)
                return BadRequest(); // 400

            var department = _departmentRepo.GetById(Id.Value);

            if (department is null)
                return NotFound(); // 404

            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            ///if(!Id.HasValue)
            ///    return BadRequest();
            ///var department = _departmentRepo.GetById(Id.Value);
            ///if(department is null)
            ///    return NotFound();
            ///return View(department);
            
            return Details(Id,"Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int Id ,Department department)
        {
            if(Id !=department.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(department);

            try
            {
                _departmentRepo.Update(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log Exception 
                // Friendly Message

                if (_ev.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "An Error Has Occured during Updating the Department");

                return View(department);
            }

        }
        public IActionResult Delete(int? Id )
        {
            return Details(Id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            try
            {
                _departmentRepo.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log Exception 
                // Friendly Message

                if (_ev.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "An Error Has Occured during Updating the Department");
                return View(department);
            }
        }

    }
}
