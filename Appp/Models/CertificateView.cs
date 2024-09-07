using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class CertificateView
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Note { get; set; }
        public string Dianosis { get; set; }
        public string DoctorName { get; set; }
    }
}
