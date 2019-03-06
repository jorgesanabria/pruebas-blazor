using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class Property
    {
        public Property()
        {
            ContentProperty = new HashSet<ContentProperty>();
            InverseIdParentNavigation = new HashSet<Property>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string IdParent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Enabled { get; set; }
        public string IdType { get; set; }

        public Property IdParentNavigation { get; set; }
        public Type IdTypeNavigation { get; set; }
        public ICollection<ContentProperty> ContentProperty { get; set; }
        public ICollection<Property> InverseIdParentNavigation { get; set; }
    }
}
