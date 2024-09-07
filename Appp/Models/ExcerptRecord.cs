using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class ExcerptRecord
    {
        public int ExcerptRecordId { get; set; }
        public int MedicalCardId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }

        public virtual MedicalCard MedicalCard { get; set; }
    }
}
