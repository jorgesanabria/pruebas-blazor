using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class Taxonomy
    {
        public Taxonomy()
        {
            ContentTaxonomy = new HashSet<ContentTaxonomy>();
            InverseIdParentNavigation = new HashSet<Taxonomy>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string IdParent { get; set; }
        public string IdType { get; set; }
        public bool Enabled { get; set; }

        public Taxonomy IdParentNavigation { get; set; }
        public Type IdTypeNavigation { get; set; }
        public ICollection<ContentTaxonomy> ContentTaxonomy { get; set; }
        public ICollection<Taxonomy> InverseIdParentNavigation { get; set; }
    }
}
