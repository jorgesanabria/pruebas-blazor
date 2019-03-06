using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class ContentProperty
    {
        public decimal IdContent { get; set; }
        public string IdProperty { get; set; }

        public Content IdContentNavigation { get; set; }
        public Property IdPropertyNavigation { get; set; }
    }
}
