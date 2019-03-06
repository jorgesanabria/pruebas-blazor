using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class ConversationContent
    {
        public decimal IdContent { get; set; }
        public string IdVisitor { get; set; }
        public string Content { get; set; }

        public Visitor IdVisitorNavigation { get; set; }
    }
}
