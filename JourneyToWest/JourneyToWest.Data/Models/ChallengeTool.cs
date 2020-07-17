using System;
using System.Collections.Generic;

namespace JourneyToWest.Models
{
    public partial class ChallengeTool
    {
        public string Id { get; set; }
        public string ChallengeId { get; set; }
        public string ToolId { get; set; }
        public int? Quantity { get; set; }

        public virtual Challenge Challenge { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
