﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Appp.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
