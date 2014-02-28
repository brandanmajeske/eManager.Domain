using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using eManager.Domain;
using eManager.Web.Models;

namespace eManager.Web.Controllers
{
	[Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
		private IDepartmentDataSource _db;

	    public EmployeeController(IDepartmentDataSource db)
	    {
		    _db = db;
	    }
		
		[HttpGet]
        public ActionResult Create(int departmentId)
        {
	        var model = new CreateEmployeeViewModel();
	        model.DepartmentId = departmentId; 
			return View(model);
        }

	    [HttpPost]
	    public ActionResult Create(CreateEmployeeViewModel viewModel)
	    {
		    if (ModelState.IsValid)
		    {
			    var department = _db.Departments.Single(d => d.Id == viewModel.DepartmentId);
			    var employee = new Employee();
			    employee.Name = viewModel.Name;
			    employee.HireDate = viewModel.HireDate;
				department.Employees.Add(employee);
			    _db.Save();
			    return RedirectToAction("detail", "department", new { id = viewModel.DepartmentId});
		    }
		    return View(viewModel);
	    }

    }
}
