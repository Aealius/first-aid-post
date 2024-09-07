using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class Infection
    {
        public Infection()
        {
            VaccinationCardRecords = new HashSet<VaccinationCardRecord>();
        }

        public int InfectionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VaccinationCardRecord> VaccinationCardRecords { get; set; }
    }
}
