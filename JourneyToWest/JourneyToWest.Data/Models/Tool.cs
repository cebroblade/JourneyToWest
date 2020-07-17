using System;
using System.Collections.Generic;

namespace JourneyToWest.Models
{
    public partial class Tool
    {
        public Tool()
        {
            ChallengeTool = new HashSet<ChallengeTool>();
        }

        public string ToolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public string ImageTool { get; set; }

        public virtual ICollection<ChallengeTool> ChallengeTool { get; set; }
    }
}
