using System;
using System.Collections.Generic;

namespace cms.Entities
{
    public partial class McsSections
    {
        public string SectionName { get; set; }
        public string SectionCode { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public bool? Status { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? ContactId { get; set; }
        public Guid SectionId { get; set; }

        public McsContactDetails Contact { get; set; }
        public McsDepartments Department { get; set; }
    }
}
