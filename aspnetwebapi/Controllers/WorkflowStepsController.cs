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
    public class WorkflowStepsController : ControllerBase
    {
        private readonly WorkflowStepContext _context;

        public WorkflowStepsController(WorkflowStepContext context)
        {
            _context = context;
        }

        // GET: api/WorkflowSteps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkflowStep>>> GetWorkflowSteps()
        {
            return await _context.WorkflowSteps.ToListAsync();
        }

        // GET: api/WorkflowSteps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkflowStep>> GetWorkflowStep(string id)
        {
            var workflowStep = await _context.WorkflowSteps.FindAsync(id);

            if (workflowStep == null)
            {
                return NotFound();
            }

            return workflowStep;
        }

        // PUT: api/WorkflowSteps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkflowStep(string id, WorkflowStep workflowStep)
        {
            if (id != workflowStep.ID)
            {
                return BadRequest();
            }

            _context.Entry(workflowStep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkflowStepExists(id))
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

        // POST: api/WorkflowSteps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkflowStep>> PostWorkflowStep(WorkflowStep workflowStep)
        {
            _context.WorkflowSteps.Add(workflowStep);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorkflowStepExists(workflowStep.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetWorkflowStep), new { id = workflowStep.ID }, workflowStep);
        }

        // DELETE: api/WorkflowSteps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkflowStep(string id)
        {
            var workflowStep = await _context.WorkflowSteps.FindAsync(id);
            if (workflowStep == null)
            {
                return NotFound();
            }

            _context.WorkflowSteps.Remove(workflowStep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkflowStepExists(string id)
        {
            return _context.WorkflowSteps.Any(e => e.ID == id);
        }
    }
}
