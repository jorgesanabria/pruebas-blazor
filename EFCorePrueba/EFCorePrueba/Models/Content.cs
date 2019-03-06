using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class Content
    {
        public Content()
        {
            ContentProperty = new HashSet<ContentProperty>();
            ContentTaxonomy = new HashSet<ContentTaxonomy>();
            InverseIdParentNavigation = new HashSet<Content>();
            PriceContent = new HashSet<PriceContent>();
        }

        public decimal Id { get; set; }
        public decimal? IdParent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Enabled { get; set; }
        public string IdType { get; set; }
        public string IdUser { get; set; }

        public Content IdParentNavigation { get; set; }
        public Type IdTypeNavigation { get; set; }
        public User IdUserNavigation { get; set; }
        public DescriptionContent DescriptionContent { get; set; }
        public ImageContent ImageContent { get; set; }
        public ICollection<ContentProperty> ContentProperty { get; set; }
        public ICollection<ContentTaxonomy> ContentTaxonomy { get; set; }
        public ICollection<Content> InverseIdParentNavigation { get; set; }
        public ICollection<PriceContent> PriceContent { get; set; }
    }
}
