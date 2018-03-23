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
    [Route("api/JobService")]
    public class JobServiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobService
        [HttpGet]
        public IEnumerable<JobService> GetJobServices()
        {
            return _context.JobServices;
        }

        // GET: api/JobService/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobService = await _context.JobServices.SingleOrDefaultAsync(m => m.JobServiceID == id);

            if (jobService == null)
            {
                return NotFound();
            }

            return Ok(jobService);
        }

        // PUT: api/JobService/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobService([FromRoute] int id, [FromBody] JobService jobService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobService.JobServiceID)
            {
                return BadRequest();
            }

            _context.Entry(jobService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobServiceExists(id))
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

        // POST: api/JobService
        [HttpPost]
        public async Task<IActionResult> PostJobService([FromBody] JobService jobService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JobServices.Add(jobService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobService", new { id = jobService.JobServiceID }, jobService);
        }

        // DELETE: api/JobService/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobService = await _context.JobServices.SingleOrDefaultAsync(m => m.JobServiceID == id);
            if (jobService == null)
            {
                return NotFound();
            }

            _context.JobServices.Remove(jobService);
            await _context.SaveChangesAsync();

            return Ok(jobService);
        }

        private bool JobServiceExists(int id)
        {
            return _context.JobServices.Any(e => e.JobServiceID == id);
        }
    }
}