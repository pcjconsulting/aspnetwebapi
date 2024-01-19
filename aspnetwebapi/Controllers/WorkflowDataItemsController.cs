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
    public class WorkflowDataItemsController : ControllerBase
    {
        private readonly WorkflowDataItemContext _context;

        public WorkflowDataItemsController(WorkflowDataItemContext context)
        {
            _context = context;
        }

        // GET: api/WorkflowDataItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkflowDataItem>>> GetWorkflowDataItems()
        {
            return await _context.WorkflowDataItems.ToListAsync();
        }

        // GET: api/WorkflowDataItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkflowDataItem>> GetWorkflowDataItem(string id)
        {
            var workflowDataItem = await _context.WorkflowDataItems.FindAsync(id);

            if (workflowDataItem == null)
            {
                return NotFound();
            }

            return workflowDataItem;
        }

        // PUT: api/WorkflowDataItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkflowDataItem(string id, WorkflowDataItem workflowDataItem)
        {
            if (id != workflowDataItem.ID)
            {
                return BadRequest();
            }

            _context.Entry(workflowDataItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkflowDataItemExists(id))
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

        // POST: api/WorkflowDataItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkflowDataItem>> PostWorkflowDataItem(WorkflowDataItem workflowDataItem)
        {
            _context.WorkflowDataItems.Add(workflowDataItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorkflowDataItemExists(workflowDataItem.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetWorkflowDataItem), new { id = workflowDataItem.ID }, workflowDataItem);
        }

        // DELETE: api/WorkflowDataItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkflowDataItem(string id)
        {
            var workflowDataItem = await _context.WorkflowDataItems.FindAsync(id);
            if (workflowDataItem == null)
            {
                return NotFound();
            }

            _context.WorkflowDataItems.Remove(workflowDataItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkflowDataItemExists(string id)
        {
            return _context.WorkflowDataItems.Any(e => e.ID == id);
        }
    }
}
