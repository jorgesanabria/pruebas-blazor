using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class Permission
    {
        public Permission()
        {
            PermissionRole = new HashSet<PermissionRole>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string IdType { get; set; }
        public bool Enabled { get; set; }

        public Type IdTypeNavigation { get; set; }
        public ICollection<PermissionRole> PermissionRole { get; set; }
    }
}
