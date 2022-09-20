using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Formationinstitution
    {
        public int IdFormation { get; set; }
        public int IdInstitution { get; set; }

        public virtual Formation IdFormationNavigation { get; set; }
        public virtual Institution IdInstitutionNavigation { get; set; }
    }
}
