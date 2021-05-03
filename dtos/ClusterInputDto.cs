using System;
using System.Collections.Generic;
namespace cms.dtos {
    public class ClusterContactInputDto {

        public string DoorNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string LandMark { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string LandLineNo { get; set; }
        public string MobileNo1 { get; set; }
        public string MobileNo2 { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
    public class ClusterInputDto {
        public string ClusterName { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime DeactivatedDate { get; set; }
        public bool? Status { get; set; }
        public string ClusterCode { get; set; }
        public Guid CompanyId { get; set; }
        public virtual ClusterContactInputDto Contact { get; set; }

    }
}