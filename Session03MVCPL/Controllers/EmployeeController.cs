﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Session03MVCBLL.Interfaces;
using Session03MVCBLL.Repositories;
using Session03MVCEDAL.Models;
using Session03MVCPL.ViewModel;
using System;
using System.Linq;

namespace Session03MVCPL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly IEmployeeRepositories _EmployeeRepo; // Null
        public IWebHostEnvironment _ev { get; }
        public IDepartmentRepositories _departmentRepos { get; }

        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper IWebHostEnvironment ev) // Ask CLR for Creating an Object From Class Implementing IEmployeeRepositories
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            _ev = ev;
        }
        public IActionResult Index(string searchInput)
        {
            //// 1. ViewData
            //ViewData["Message"] = "Hello ViewData";

            //// 2. ViewBag
            //ViewBag.Message = "Hello ViewBag";
            var employees = Enumerable.Empty<Employee>();
            var employeeRepo = _unitOfWork.Repository<Employee>() as EmployeeRepository;

            if (string.IsNullOrEmpty(searchInput))
                employees = _unitOfWork.Repository<Employee>().GetAll();
            else
                employees = employeeRepo.SearchByName(searchInput.ToLower());

            return View(employees);
        }
        //[HttpGet]
        public IActionResult Create()
        {
            //ViewData["Departments"] = _departmentRepos.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employeeModel)
        {
            if (ModelState.IsValid) // Server Side Vaildation
            {
                var mappedEmp = mapper.Map<EmployeeViewModel,Employee>(employeeModel);
                _unitOfWork.Repository<Employee>().Add(employeeModel);
                // 3. TempData
                //if (count > 0)
                //    TempData["Message"] = "Employee is created Successfully";
                //else
                //    TempData["Message"] = " An Error Occured, Employee Not Created";

          
                // 2. Update Employee

                // 3. Delete Employee
          

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        public IActionResult Details(int? Id, string ViewName = "Details")
        {
            if (!Id.HasValue)
                return BadRequest(); // 400

            var Employee = _unitOfWork.Repository<Employee>().GetById(Id.Value);

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
                _unitOfWork.Repository<Employee>().Update(Employee);
                _unitOfWork.Complete();
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
                _unitOfWork.Repository<Employee>().Delete(Employee);
                _unitOfWork.Complete();
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
