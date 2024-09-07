using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Specialities = new HashSet<Speciality>();
            Students = new HashSet<Student>();
        }

        public int FacultyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Speciality> Specialities { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
