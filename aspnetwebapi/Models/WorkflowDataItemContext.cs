using Microsoft.EntityFrameworkCore;

namespace aspnetwebapi.Models
{
    public class WorkflowDataItemContext : DbContext
    {
        public WorkflowDataItemContext(DbContextOptions<WorkflowDataItemContext> options)
            : base(options)
        { }

        public DbSet<WorkflowDataItem> WorkflowDataItems { get; set; } = null!;
    }
}
