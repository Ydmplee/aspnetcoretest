using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTest.Models;
using AspNetCoreTest.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreTest.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            ViewBag.title = "Department Index";
            var departments = await _departmentService.GetAll();
            return View(departments);
        }

        public IActionResult Add()
        {
            ViewBag.title = "Add Department";
            return View(new Department());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Department model)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Add(model);

            }

            return RedirectToAction(nameof(Index));
        }
    }
}
