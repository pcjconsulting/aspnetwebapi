using Microsoft.Extensions.Configuration;

namespace aspnetwebapi.Models
{
    public class Workflow
    {
        //public Workflow(string configurationSettings, string user, string name,
        //                  string description, string station, List<WorkflowStep> steps)
        //{ }
        public string? ID { get; set; } // = id;
        public string? Name { get; set; } // = name;
        public string? Description { get; set; } // = description;
        public string? ConfigurationSettings { get; set; } // = configurationSettings;
        public UserAccount? User { get; set; } // = user;
        public string? Station { get; set; } // = station; 
        public List<WorkflowStep>? Steps { get; set; } // = steps;
    }
}
