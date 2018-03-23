using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDAspMvc.Data;
using Models;
using WEBAPIServices;

namespace ASPMVC.Controllers
{
    public class Employee1Controller : Controller
    {
        private WebApiServices<Employee> _context = new WebApiServices<Employee>();

        // GET: Employee
        public IActionResult Index()
        {
            var applicationDbContext = _context.GetData();
            return View(applicationDbContext);
        }

        // GET: Employee/Details/5
        public IActionResult Details(int id=0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _context.GetData(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            WebApiServices<Company> _companyContext = new WebApiServices<Company>();
            ViewData["CompanyID"] = new SelectList(_companyContext.GetData(), "CompanyID", "Name");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmployeeID,Name,Mobile,Email,VisaExpiry,WorkPermitExpiry,CompanyID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.PostData(employee);
                return RedirectToAction(nameof(Index));
            }
            WebApiServices<Company> _companyContext = new WebApiServices<Company>();
            ViewData["CompanyID"] = new SelectList(_companyContext.GetData(), "CompanyID", "Name", employee.CompanyID);
  
            return View(employee);
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(int id=0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _context.GetData(id); 
            if (employee == null)
            {
                return NotFound();
            }
            WebApiServices<Company> _companyContext = new WebApiServices<Company>();
            ViewData["CompanyID"] = new SelectList(_companyContext.GetData(), "CompanyID", "Name", employee.CompanyID);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("EmployeeID,Name,Mobile,Email,VisaExpiry,WorkPermitExpiry,CompanyID")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.PutData(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            WebApiServices<Company> _companyContext = new WebApiServices<Company>();
            ViewData["CompanyID"] = new SelectList(_companyContext.GetData(), "CompanyID", "Name", employee.CompanyID);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public IActionResult Delete(int id=0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _context.GetData(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.GetData(id);
            _context.DeleteData(employee);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return !String.IsNullOrEmpty(_context.GetData(id).Name);
        }
    }
}
