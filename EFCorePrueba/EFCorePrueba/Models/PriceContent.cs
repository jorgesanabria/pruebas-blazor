using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class PriceContent
    {
        public decimal IdContent { get; set; }
        public string IdType { get; set; }
        public decimal Price { get; set; }

        public Content IdContentNavigation { get; set; }
        public Type IdTypeNavigation { get; set; }
    }
}
