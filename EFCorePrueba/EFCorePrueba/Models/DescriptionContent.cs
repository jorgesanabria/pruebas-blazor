using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class DescriptionContent
    {
        public decimal IdContent { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IdType { get; set; }

        public Content IdContentNavigation { get; set; }
    }
}
