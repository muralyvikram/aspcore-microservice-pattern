using System;
using System.Collections.Generic;

namespace cms.Entities
{
    public partial class McsPlants
    {
        public McsPlants()
        {
            McsDepartments = new HashSet<McsDepartments>();
        }

        public string PlantName { get; set; }
        public string PlantCode { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public bool? Status { get; set; }
        public Guid? ClusterId { get; set; }
        public Guid PlantId { get; set; }
        public Guid? ContactId { get; set; }

        public McsClusters Cluster { get; set; }
        public McsContactDetails Contact { get; set; }
        public ICollection<McsDepartments> McsDepartments { get; set; }
    }
}
