using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class HealthGroup
    {
        public HealthGroup()
        {
            MedicalCards = new HashSet<MedicalCard>();
        }

        public int HealthGroupId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<MedicalCard> MedicalCards { get; set; }
    }
}
