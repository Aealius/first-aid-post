using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class BloodType
    {
        public BloodType()
        {
            MedicalCards = new HashSet<MedicalCard>();
        }

        public int BloodTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MedicalCard> MedicalCards { get; set; }
    }
}
