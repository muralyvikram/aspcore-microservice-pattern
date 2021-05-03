using System;
using System.Collections.Generic;

namespace cms.Entities
{
    public partial class McsRoles
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime? DeactivatedDate { get; set; }
    }
}
