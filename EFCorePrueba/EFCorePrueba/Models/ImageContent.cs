using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class ImageContent
    {
        public decimal IdContent { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

        public Content IdContentNavigation { get; set; }
    }
}
