using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class PermissionRole
    {
        public string IdPermission { get; set; }
        public string IdRole { get; set; }

        public Permission IdPermissionNavigation { get; set; }
        public Role IdRoleNavigation { get; set; }
    }
}
