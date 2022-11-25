using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Aspnetuser
    {
        public Aspnetuser()
        {
            Aspnetuserclaims = new HashSet<Aspnetuserclaim>();
            Aspnetuserlogins = new HashSet<Aspnetuserlogin>();
            Aspnetuserroles = new HashSet<Aspnetuserrole>();
            Aspnetusertokens = new HashSet<Aspnetusertoken>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<Aspnetuserclaim> Aspnetuserclaims { get; set; }
        public virtual ICollection<Aspnetuserlogin> Aspnetuserlogins { get; set; }
        public virtual ICollection<Aspnetuserrole> Aspnetuserroles { get; set; }
        public virtual ICollection<Aspnetusertoken> Aspnetusertokens { get; set; }
    }
}
