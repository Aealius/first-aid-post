using Appp.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class Student
    {
        public Student()
        {
            Certificates = new HashSet<Certificate>();
            MedicalExaminations = new HashSet<MedicalExamination>();
        }

        public int StudentId { get; set; }
        public int? MedicalcardId { get; set; }
        public int FacultyId { get; set; }
        public int SpecialityId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public DateTime EnrollDate { get; set; }
        public DateTime? ExpulsionDate { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual Group Group { get; set; }
        public virtual MedicalCard Medicalcard { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<MedicalExamination> MedicalExaminations { get; set; }
    }
}
