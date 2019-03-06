using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class Role
    {
        public Role()
        {
            InverseIdParentNavigation = new HashSet<Role>();
            PermissionRole = new HashSet<PermissionRole>();
            UserRole = new HashSet<UserRole>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string IdParent { get; set; }
        public bool Enabled { get; set; }
        public string IdType { get; set; }

        public Role IdParentNavigation { get; set; }
        public Type IdTypeNavigation { get; set; }
        public ICollection<Role> InverseIdParentNavigation { get; set; }
        public ICollection<PermissionRole> PermissionRole { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
