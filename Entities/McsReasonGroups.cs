using System;
using System.Collections.Generic;

namespace cms.Entities
{
    public partial class McsReasonGroups
    {
        public Guid ReasonGroupId { get; set; }
        public string ReasonGroupName { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public bool? Status { get; set; }
    }
}
