using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class GroupType
    {
        public string IdGroup { get; set; }
        public string IdType { get; set; }

        public Group IdGroupNavigation { get; set; }
        public Type IdTypeNavigation { get; set; }
    }
}
