using System;
using System.Collections.Generic;
namespace cms.dtos {
    public class CompanyContactUpdateDto {
        public Guid ContactUid { get; set; }
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
    public class CompanyInputUpdateDto {
        public Guid ContactId { get; set; }
        public Guid? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime DeactivatedDate { get; set; }
        public bool? Status { get; set; }
        public string CompanyCode { get; set; }

        public virtual CompanyContactUpdateDto Contact { get; set; }

    }

    public class CompanyViewDto {
        public Guid ContactId { get; set; }
        public Guid? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime DeactivatedDate { get; set; }
        public bool? Status { get; set; }
        public string CompanyCode { get; set; }

        public virtual CompanyContactUpdateDto Contact { get; set; }

    }
}