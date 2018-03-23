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
    public class CompanyController : Controller
    {
        WebApiServices<Company> _context = new WebApiServices<Company>();



        // GET: Company
        public IActionResult Index()
        {
            return View(_context.GetData());
        }

        // GET: Company/Details/5
        public IActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var company = _context.GetData(id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CompanyID,Name,Address,Area,State,Mobile,Telephone,Email,CreditLimit,LicenseExpiry,EstCardExpiry")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.PostData(company);
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Company/Edit/5
        public IActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var company = _context.GetData(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CompanyID,Name,Address,Area,State,Mobile,Telephone,Email,CreditLimit,LicenseExpiry,EstCardExpiry")] Company company)
        {
            if (id != company.CompanyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.PutData(company);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyID))
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
            return View(company);
        }

        // GET: Company/Delete/5
        public IActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var company = _context.GetData(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var company = _context.GetData(id);
            _context.DeleteData(company);
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return !String.IsNullOrEmpty(_context.GetData(id).Name);
        }
    }
}
