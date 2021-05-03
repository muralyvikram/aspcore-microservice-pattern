using System;
using System.Collections.Generic;

namespace cms.Entities
{
    public partial class McsDepartments
    {
        public McsDepartments()
        {
            McsSections = new HashSet<McsSections>();
        }

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public bool? Status { get; set; }
        public Guid PlantId { get; set; }
        public Guid ContactId { get; set; }

        public McsContactDetails Contact { get; set; }
        public McsPlants Plant { get; set; }
        public ICollection<McsSections> McsSections { get; set; }
    }
}
