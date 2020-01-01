using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController()
        {
            _employeeRepository = new MockEmployeeRepository(); 
        }

        /* public string index() {
             return "Hello From MVC HomeController";
         }*/
        /* public JsonResult Index()
         {
             return Json(new { id = 1, name = "program" });
         }*/

        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }

      /*  public JsonResult Details() 
        {
            Employee model = _employeeRepository.GetEmployee(1);
                return Json(model);
        }
          */
        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);

            //---Return (-ViewData-) 
            //  ViewData["PageTitle"] = "Employee Details";
            //  ViewData["Employee"] = model;
            //---Return (-ViewData-) 

            //return View(model);
            //  return View("Test");// name of page.cshtml

            //---Return (-ViewBag-) 
            ViewBag.PageTitle = "Employee Details";
            ViewBag.Employee = model;
            //---Return (-ViewData-) 

            return View();
        }
    }
}
