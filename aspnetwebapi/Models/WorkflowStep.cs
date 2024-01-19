using Microsoft.AspNetCore.Components.RenderTree;
using System.Data;
using System.Xml.Linq;


/// <remarks>
///     • an IoT service executes the workflow using c# HiveMQ MQTT 5 lib --> request/response
///     • the react-native client renders the workflow
///     • the aspnetwebapi rest service manages the workflow entities
/// </remarks>
namespace aspnetwebapi.Models
{
    public class WorkflowStep
    {

        /// <summary>
        /// WorkflowStep is a restful entity with a recursive data structure.
        /// </summary>
        /// <remarks>
        /// Create a WorkflowStep object.
        /// </remarks>
        /// <param name="name">The name of the step.</param>
        /// <param name="id">The ID of the step</param>
        /// <param name="prevID">The ID of the previous step</param>
        /// <param name="nextID">The ID of the next step</param>
        /// <param name="stepData">The data parameters for the ExecuteAsync method.</param>
        /// <param name="resourceData"></param>
        /// <param name="stepTasks">The tasks for this step.</param>
        //public WorkflowStep(string name, string id, string description, string prevID, string nextID,
        //                List<WorkflowDataItem> stepData, List<WorkflowDataItem> resourceData, List<WorkflowStep> stepTasks)
        //{ }

        /// <summary>
        /// The Name.
        /// </summary>
        public string? Name { get; set; } // = name;

        /// <summary>
        /// The Description.
        /// </summary>
        public string? Description { get; set; } // = description;

        /// <summary>
        /// The ID of this WorkflowStep.
        /// </summary>
        public string? ID { get; set; } // = id;

        /// <summary>
        /// The ID of the previous WorkflowStep in the execute sequence.
        /// </summary>
        public string? PrevID { get; set; } // = prevID;

        /// <summary>
        /// The ID of the next WorkflowStep in the execute sequence.
        /// </summary>
        public string? NextID { get; set; } // = nextID;

        /// <summary>
        /// A list of renderable data parameters for the step.  Includes user input.
        /// </summary>
        public List<WorkflowDataItem>? StepData { get; set; } // = stepData;

        /// <summary>
        /// A list of renderable resources used by the step.
        /// </summary>
        public List<WorkflowDataItem>? ResourceData { get; set; } // = resourceData;

        /// <summary>
        /// AskContinueToNextStep is true if the step prompts the user before continuing. 
        /// </summary>
        public bool? AskContinueToNextStep { get; set; }

        /// <summary>
        /// StepTasks contains the WorkflowStep elements in this WorkflowStep node.
        /// </summary>
        public List<WorkflowStep>? StepTasks { get; set; } // = stepTasks;


        /// <summary>
        /// RenderAsync renders a react-native UI enabling the operator to execute the step
        /// </summary>
        /// <returns></returns>
        //public async Task RenderAsync() {; }

        /// <summary>
        /// ExecuteAsync performs one operation on a dataset.
        /// </summary>
        /// <returns>A result dataset</returns>
        //public async Task<IWorkflowDataField> ExecuteAsync() { return null; }

    }
}
