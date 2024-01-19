using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using System.Xml.Linq;

namespace aspnetwebapi.Models
{
    public class WorkflowDataItem
    {
        /// <summary>
        /// Create a WorkflowDataItem object.
        /// </summary>
        /// <param name="name">The name of the data item.</param>
        /// <param name="id">The ID of the item</param>
        /// <param name="description">The description of the data item</param>
        /// <param name="value">The value of the data</param>
        /// <param name="tabSequence">The tab order when rendering the item.</param>
        /// <param name="position">The position when rendering the item</param>
        /// <param name="inputPrompt">The input prompt when rendering the item.</param>
        /// <param name="caption">The caption when rendering the item..</param>
        /// <param name="validationErrorMsg">Display message if input validation fails.</param>
        /// <param name="visible">True if the item is visible.</param>
        /// <param name="enabled">True if the item allows input.</param>
        //public WorkflowDataItem(string name, string id, string description, string value, string type,
        //                        int tabSequence, string position, string inputPrompt, string caption,
        //                        string validationErrorMsg, bool visible, bool enabled)
        //{}

        public string? Name { get; set; } // = name;
        public string? Description { get; set; } // = description;
        public string? ID { get; set; } // = id;
        public string? Value { get; set; } // = value;    // serialize for now use string not object
        public string? @Type { get; set; } // = type;    // de-normalize for now use string not enum
        public int? TabSequence { get; set; } // = tabSequence;
        public string? Position { get; set; } // = position;     // de-normalize use comma-separated string for now
        public string? InputPrompt { get; set; } // = inputPrompt;
        public string? Caption { get; set; } // = caption;
        public string? ValidationErrorMessage { get; set; } // = validationErrorMsg;
        public bool? Visible { get; set; } // = visible;
        public bool? Enabled { get; set; } // = enabled;



        //public Task RenderAsync();
        //public Task ValidateAsync();
    }
}
