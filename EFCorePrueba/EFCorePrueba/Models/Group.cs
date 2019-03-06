using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupType = new HashSet<GroupType>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public bool Enabled { get; set; }

        public ICollection<GroupType> GroupType { get; set; }
    }
}
