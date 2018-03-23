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
    public class BankController : Controller
    {
        WebApiServices<Bank> _context = new WebApiServices<Bank>();


        // GET: Bank
        public IActionResult Index()
        {
            return View(_context.GetData());
        }

        // GET: Bank/Details/5
        public IActionResult Details(int id=0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var bank = _context.GetData(id);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }

        // GET: Bank/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bank/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BankID,Name,AccountNumber")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                _context.PostData(bank);
                return RedirectToAction(nameof(Index));
            }
            return View(bank);
        }

        // GET: Bank/Edit/5
        public IActionResult Edit(int id=0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var bank = _context.GetData(id);
            if (bank == null)
            {
                return NotFound();
            }
            return View(bank);
        }

        // POST: Bank/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("BankID,Name,AccountNumber")] Bank bank)
        {
            if (id != bank.BankID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.PutData(bank);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankExists(bank.BankID))
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
            return View(bank);
        }

        // GET: Bank/Delete/5
        public IActionResult Delete(int id=0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var bank = _context.GetData(id);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }

        // POST: Bank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bank = _context.GetData(id);
            _context.DeleteData(bank);
            return RedirectToAction(nameof(Index));
        }

        private bool BankExists(int id)
        {
            return !String.IsNullOrEmpty(_context.GetData(id).Name);
        }
    }
}
