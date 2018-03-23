using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using WEBAPI.Data;

namespace WEBAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/JobServiceHead")]
    public class WebApiJobServiceHeadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WebApiJobServiceHeadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WebApiJobServiceHead
        [HttpGet]
        public IEnumerable<JobServiceHead> GetJobServiceHeads()
        {
            return _context.JobServiceHeads;
        }

        // GET: api/WebApiJobServiceHead/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobServiceHead([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobServiceHead = await _context.JobServiceHeads.SingleOrDefaultAsync(m => m.JobServiceHeadID == id);

            if (jobServiceHead == null)
            {
                return NotFound();
            }

            return Ok(jobServiceHead);
        }

        // PUT: api/WebApiJobServiceHead/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobServiceHead([FromRoute] int id, [FromBody] JobServiceHead jobServiceHead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobServiceHead.JobServiceHeadID)
            {
                return BadRequest();
            }

            _context.Entry(jobServiceHead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobServiceHeadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WebApiJobServiceHead
        [HttpPost]
        public async Task<IActionResult> PostJobServiceHead([FromBody] JobServiceHead jobServiceHead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JobServiceHeads.Add(jobServiceHead);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobServiceHead", new { id = jobServiceHead.JobServiceHeadID }, jobServiceHead);
        }

        // DELETE: api/WebApiJobServiceHead/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobServiceHead([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobServiceHead = await _context.JobServiceHeads.SingleOrDefaultAsync(m => m.JobServiceHeadID == id);
            if (jobServiceHead == null)
            {
                return NotFound();
            }

            _context.JobServiceHeads.Remove(jobServiceHead);
            await _context.SaveChangesAsync();

            return Ok(jobServiceHead);
        }

        private bool JobServiceHeadExists(int id)
        {
            return _context.JobServiceHeads.Any(e => e.JobServiceHeadID == id);
        }
    }
}