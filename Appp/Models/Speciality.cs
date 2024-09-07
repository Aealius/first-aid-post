using Appp.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class Speciality
    {
        public Speciality()
        {
            Groups = new HashSet<Group>();
            Students = new HashSet<Student>();
        }

        public int SpecialityId { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
