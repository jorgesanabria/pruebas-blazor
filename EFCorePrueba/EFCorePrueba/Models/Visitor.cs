using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class Visitor
    {
        public Visitor()
        {
            ConversationContent = new HashSet<ConversationContent>();
            User = new HashSet<User>();
        }

        public string Email { get; set; }
        public string Name { get; set; }

        public ICollection<ConversationContent> ConversationContent { get; set; }
        public ICollection<User> User { get; set; }
    }
}
