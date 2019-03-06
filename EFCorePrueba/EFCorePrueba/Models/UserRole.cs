using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class UserRole
    {
        public string IdUser { get; set; }
        public string IdRole { get; set; }

        public Role IdRoleNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}
