using System;
using System.Collections.Generic;
namespace cms.dtos {
    public class CompanyOutputDto {

        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime DeactivatedDate { get; set; }
        public bool? Status { get; set; }

    }
}