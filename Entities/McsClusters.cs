using System;
using System.Collections.Generic;

namespace cms.Entities
{
    public partial class McsClusters
    {

        public string ClusterName { get; set; }
        public string ClusterCode { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public bool Status { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? ContactId { get; set; }
        public Guid ClusterId { get; set; }

        public McsCompanies Company { get; set; }
        public McsContactDetails Contact { get; set; }
        public ICollection<McsPlants> McsPlants { get; set; }
    }
}
