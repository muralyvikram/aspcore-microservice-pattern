using System;
using System.Collections.Generic;
namespace cms.dtos {
    public class DepartmentContactInputDto {

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
    public class DepartmentInputDto {
        public string DepartmentName { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime DeactivatedDate { get; set; }
        public bool? Status { get; set; }
        public string DepartmentCode { get; set; }
        public Guid PlantId { get; set; }
        public virtual DepartmentContactInputDto Contact { get; set; }

    }
}