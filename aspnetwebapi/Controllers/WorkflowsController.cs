using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnetwebapi.Models;

namespace aspnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowsController : ControllerBase
    {
        private readonly WorkflowContext _context;

        public WorkflowsController(WorkflowContext context)
        {
            _context = context;
        }

        // GET: api/Workflows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workflow>>> GetWorkflows()
        {
            return await _context.Workflows.ToListAsync();
        }

        // GET: api/Workflows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workflow>> GetWorkflow(string id)
        {
            var workflow = await _context.Workflows.FindAsync(id);

            if (workflow == null)
            {
                return NotFound();
            }

            return workflow;
        }

        // PUT: api/Workflows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkflow(string id, Workflow workflow)
        {
            if (id != workflow.ID)
            {
                return BadRequest();
            }

            _context.Entry(workflow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkflowExists(id))
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

        // POST: api/Workflows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Workflow>> PostWorkflow(Workflow workflow)
        {
            _context.Workflows.Add(workflow);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorkflowExists(workflow.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetWorkflow), new { id = workflow.ID }, workflow);
        }

        // DELETE: api/Workflows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkflow(string id)
        {
            var workflow = await _context.Workflows.FindAsync(id);
            if (workflow == null)
            {
                return NotFound();
            }

            _context.Workflows.Remove(workflow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkflowExists(string id)
        {
            return _context.Workflows.Any(e => e.ID == id);
        }
    }
}
