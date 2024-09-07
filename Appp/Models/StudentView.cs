using Appp.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class StudentView
    {
        public int StudentId { get; set; }
        public int? MedicalcardId { get; set; }
        public int FacultyId { get; set; }
        public int SpecialityId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public string FacultyName { get; set; }
        public string GroupName { get; set; }
        public string SpecialityName { get; set; }
        public DateTime EnrollDate { get; set; }
        public DateTime? ExpulsionDate { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
