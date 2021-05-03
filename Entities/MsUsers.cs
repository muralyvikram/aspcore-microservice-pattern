using System;
using System.Collections.Generic;

namespace cms.Entities
{
    public partial class MsUsers
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Guid? RoleId { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
