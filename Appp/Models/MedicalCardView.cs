using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class MedicalCardView
    {
        public int MedicalCardId { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public int? BloodTypeId { get; set; }
        public int? HealthGroupId { get; set; }
        public string BloodTypeName { get; set; }
        public string HealthGroupName { get; set; }
    }
}
