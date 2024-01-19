using Microsoft.EntityFrameworkCore;

namespace aspnetwebapi.Models
{
    public class WorkflowStepContext : DbContext
    {
        public WorkflowStepContext(DbContextOptions<WorkflowStepContext> options)
            : base(options)
        { }

        public DbSet<WorkflowStep> WorkflowSteps { get; set; } = null!;
    }
}

