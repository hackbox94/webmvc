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
    public class JobServiceController : Controller
    {
        private WebApiServices<JobService> _context= new WebApiServices<JobService>();


        // GET: JobService
        public IActionResult Index()
        {
            var applicationDbContext = _context.GetData();
            return View(applicationDbContext);
        }

        // GET: JobService/Details/5
        public IActionResult Details(int id=0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jobService = _context.GetData(id);
            if (jobService == null)
            {
                return NotFound();
            }

            return View(jobService);
        }

        // GET: JobService/Create
        public IActionResult Create()
        {
             WebApiServices<JobServiceHead> JobServiceHeads = new WebApiServices<JobServiceHead>();
            ViewData["JobServiceHeadID"] = new SelectList(JobServiceHeads.GetData(), "JobServiceHeadID", "Name");
            return View();
        }

        // POST: JobService/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("JobServiceID,Name,GovtFees,JobServiceHeadID")] JobService jobService)
        {
            if (ModelState.IsValid)
            {
                _context.PostData(jobService);
                return RedirectToAction(nameof(Index));
            }
            WebApiServices<JobServiceHead> JobServiceHeads = new WebApiServices<JobServiceHead>();
            ViewData["JobServiceHeadID"] = new SelectList(JobServiceHeads.GetData(), "JobServiceHeadID", "Name", jobService.JobServiceHeadID);
            return View(jobService);
        }

        // GET: JobService/Edit/5
        public IActionResult Edit(int id=0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jobService = _context.GetData(id);
            if (jobService == null)
            {
                return NotFound();
            }
            WebApiServices<JobServiceHead> JobServiceHeads = new WebApiServices<JobServiceHead>();
            ViewData["JobServiceHeadID"] = new SelectList(JobServiceHeads.GetData(), "JobServiceHeadID", "Name", jobService.JobServiceHeadID);
            return View(jobService);
        }

        // POST: JobService/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("JobServiceID,Name,GovtFees,JobServiceHeadID")] JobService jobService)
        {
            if (id != jobService.JobServiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.PutData(jobService);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobServiceExists(jobService.JobServiceID))
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
            WebApiServices<JobServiceHead> JobServiceHeads = new WebApiServices<JobServiceHead>();
            ViewData["JobServiceHeadID"] = new SelectList(JobServiceHeads.GetData(), "JobServiceHeadID", "Name", jobService.JobServiceHeadID);
            return View(jobService);
        }

        // GET: JobService/Delete/5
        public IActionResult Delete(int id=0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jobService = _context.GetData(id);
            if (jobService == null)
            {
                return NotFound();
            }

            return View(jobService);
        }

        // POST: JobService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var jobService = _context.GetData(id);
            _context.DeleteData(jobService);
            return RedirectToAction(nameof(Index));
        }

        private bool JobServiceExists(int id)
        {
            return !String.IsNullOrEmpty(_context.GetData(id).Name);
        }
    }
}
