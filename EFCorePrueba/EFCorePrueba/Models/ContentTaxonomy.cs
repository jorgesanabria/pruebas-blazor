using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class ContentTaxonomy
    {
        public decimal IdContent { get; set; }
        public string IdTaxonomy { get; set; }

        public Content IdContentNavigation { get; set; }
        public Taxonomy IdTaxonomyNavigation { get; set; }
    }
}
