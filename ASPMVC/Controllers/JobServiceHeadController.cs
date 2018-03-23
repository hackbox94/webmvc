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
    public class JobServiceHeadController : Controller
    {

        WebApiServices<JobServiceHead> _context = new WebApiServices<JobServiceHead>();


        // GET: JobServiceHead
        public IActionResult Index()
        {
            return View(_context.GetData());
        }

        // GET: JobServiceHead/Details/5
        public IActionResult Details(int id=0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jobServiceHead = _context.GetData(id);
            if (jobServiceHead == null)
            {
                return NotFound();
            }

            return View(jobServiceHead);
        }

        // GET: JobServiceHead/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobServiceHead/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("JobServiceHeadID,Name")] JobServiceHead jobServiceHead)
        {
            if (ModelState.IsValid)
            {
                _context.PostData(jobServiceHead);
                return RedirectToAction(nameof(Index));
            }
            return View(jobServiceHead);
        }

        // GET: JobServiceHead/Edit/5
        public IActionResult Edit(int id=0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jobServiceHead = _context.GetData(id);
            if (jobServiceHead == null)
            {
                return NotFound();
            }
            return View(jobServiceHead);
        }

        // POST: JobServiceHead/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("JobServiceHeadID,Name")] JobServiceHead jobServiceHead)
        {
            if (id != jobServiceHead.JobServiceHeadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.PutData(jobServiceHead);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobServiceHeadExists(jobServiceHead.JobServiceHeadID))
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
            return View(jobServiceHead);
        }

        // GET: JobServiceHead/Delete/5
        public IActionResult Delete(int id=0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jobServiceHead = _context.GetData(id);
            if (jobServiceHead == null)
            {
                return NotFound();
            }

            return View(jobServiceHead);
        }

        // POST: JobServiceHead/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var jobServiceHead = _context.GetData(id);
            _context.DeleteData(jobServiceHead);
            return RedirectToAction(nameof(Index));
        }

        private bool JobServiceHeadExists(int id)
        {
            return !String.IsNullOrEmpty(_context.GetData(id).Name);
        }
    }
}
