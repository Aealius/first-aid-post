using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class Certificate
    {
        public int CertificateId { get; set; }
        public int StudentId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Note { get; set; }
        public string Dianosis { get; set; }
        public int? DoctorId { get; set; }

        public virtual User Doctor { get; set; }
        public virtual Student Student { get; set; }
    }
}
