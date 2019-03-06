using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class Type
    {
        public Type()
        {
            Content = new HashSet<Content>();
            GroupType = new HashSet<GroupType>();
            Permission = new HashSet<Permission>();
            PriceContent = new HashSet<PriceContent>();
            Property = new HashSet<Property>();
            Role = new HashSet<Role>();
            Taxonomy = new HashSet<Taxonomy>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public bool Enabled { get; set; }

        public ICollection<Content> Content { get; set; }
        public ICollection<GroupType> GroupType { get; set; }
        public ICollection<Permission> Permission { get; set; }
        public ICollection<PriceContent> PriceContent { get; set; }
        public ICollection<Property> Property { get; set; }
        public ICollection<Role> Role { get; set; }
        public ICollection<Taxonomy> Taxonomy { get; set; }
    }
}
