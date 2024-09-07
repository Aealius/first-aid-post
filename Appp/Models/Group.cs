using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }

        public int GroupId { get; set; }
        public DateTime CreationYear { get; set; }
        public string Name { get; set; }
        public int SpecialityId { get; set; }

        public virtual Speciality Speciality { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
