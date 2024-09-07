using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class VaccinationCardRecord
    {
        public int VaccardRecordId { get; set; }
        public int MedicalCardId { get; set; }
        public string Inoculation { get; set; }
        public string Vaccine { get; set; }
        public string Series { get; set; }
        public double Dose { get; set; }
        public string ImmuneWay { get; set; }
        public DateTime ImmuneDate { get; set; }
        public string Reactions { get; set; }
        public int InfectionId { get; set; }

        public virtual Infection Infection { get; set; }
        public virtual MedicalCard MedicalCard { get; set; }
    }
}
