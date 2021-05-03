using System;
using System.Collections.Generic;

namespace cms.Entities
{
    public partial class McsCompanies
    {
        public McsCompanies()
        {
            McsClusters = new HashSet<McsClusters>();
        }

        public string CompanyName { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime DeactivatedDate { get; set; }
        public bool? Status { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public Guid? ContactId { get; set; }

        public McsContactDetails Contact { get; set; }
        public ICollection<McsClusters> McsClusters { get; set; }
    }
}