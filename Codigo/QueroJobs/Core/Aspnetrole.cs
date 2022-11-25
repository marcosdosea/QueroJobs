using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Aspnetrole
    {
        public Aspnetrole()
        {
            Aspnetroleclaims = new HashSet<Aspnetroleclaim>();
            Aspnetuserroles = new HashSet<Aspnetuserrole>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<Aspnetroleclaim> Aspnetroleclaims { get; set; }
        public virtual ICollection<Aspnetuserrole> Aspnetuserroles { get; set; }
    }
}
