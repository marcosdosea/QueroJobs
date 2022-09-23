using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Institution
    {
        public Institution()
        {
            Formations = new HashSet<Formation>();
        }

        public int Id { get; set; }
        public string InstitutionName { get; set; }

        public virtual ICollection<Formation> Formations { get; set; }
    }
}
