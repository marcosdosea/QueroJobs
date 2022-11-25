using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Scholarity
    {
        public Scholarity()
        {
            Formations = new HashSet<Formation>();
            Formationvacancies = new HashSet<Formationvacancy>();
        }

        public int Id { get; set; }
        public string ScholarityName { get; set; }

        public virtual ICollection<Formation> Formations { get; set; }
        public virtual ICollection<Formationvacancy> Formationvacancies { get; set; }
    }
}
