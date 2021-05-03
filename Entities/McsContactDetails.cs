using System;
using System.Collections.Generic;

namespace cms.Entities
{
    public partial class McsContactDetails
    {


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
        public Guid ContactUid { get; set; }

        public McsClusters McsClusters { get; set; }
        public McsCompanies McsCompanies { get; set; }
        public McsPlants McsPlants { get; set; }

        public McsDepartments McsDepartments { get; set; }

        public McsSections McsSections { get; set; }
    }
}