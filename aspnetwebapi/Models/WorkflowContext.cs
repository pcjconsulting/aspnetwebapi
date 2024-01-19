using Microsoft.EntityFrameworkCore;

namespace aspnetwebapi.Models
{
    public class WorkflowContext : DbContext
    {
        public WorkflowContext(DbContextOptions<WorkflowContext> options)
            : base(options)
        { }

        public DbSet<Workflow> Workflows { get; set; } = null!;
    }
}
