using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class MedicalCard
    {
        public MedicalCard()
        {
            ExcerptRecords = new HashSet<ExcerptRecord>();
            MedicalCardRecords = new HashSet<MedicalCardRecord>();
            RefferalRecords = new HashSet<RefferalRecord>();
            Students = new HashSet<Student>();
            VaccinationCardRecords = new HashSet<VaccinationCardRecord>();
        }

        public int MedicalCardId { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public int? BloodTypeId { get; set; }
        public int? HealthGroupId { get; set; }

        public virtual BloodType BloodType { get; set; }
        public virtual HealthGroup HealthGroup { get; set; }
        public virtual ICollection<ExcerptRecord> ExcerptRecords { get; set; }
        public virtual ICollection<MedicalCardRecord> MedicalCardRecords { get; set; }
        public virtual ICollection<RefferalRecord> RefferalRecords { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<VaccinationCardRecord> VaccinationCardRecords { get; set; }
    }
}
