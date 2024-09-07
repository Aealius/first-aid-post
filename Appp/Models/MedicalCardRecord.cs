using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class MedicalCardRecord
    {
        public int MedcardRecordId { get; set; }
        public int MedicalCardId { get; set; }
        public DateTime VisitDate { get; set; }
        public string Complaints { get; set; }
        public string Diagnosis { get; set; }

        public virtual MedicalCard MedicalCard { get; set; }
    }
}
