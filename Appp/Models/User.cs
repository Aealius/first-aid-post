using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class User
    {
        public User()
        {
            Certificates = new HashSet<Certificate>();
        }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Login { get; set; }
        public string Pwd { get; set; }
        public string DoctorInitials { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
    }
}
