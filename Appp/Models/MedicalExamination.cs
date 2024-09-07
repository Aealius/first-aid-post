using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class MedicalExamination
    {
        public int MedExamId { get; set; }
        public int StudentId { get; set; }
        public bool CompletanceStatus { get; set; }
        public string Reason { get; set; }
        public string AcademicYear { get; set; }

        public virtual Student Student { get; set; }
    }
}
