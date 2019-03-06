using System;
using System.Collections.Generic;

namespace EFCorePrueba.Models
{
    public partial class User
    {
        public User()
        {
            Content = new HashSet<Content>();
            UserRole = new HashSet<UserRole>();
        }

        public string Id { get; set; }
        public string Password { get; set; }
        public string IdVisitor { get; set; }

        public Visitor IdVisitorNavigation { get; set; }
        public ICollection<Content> Content { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
