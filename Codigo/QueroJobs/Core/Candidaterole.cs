using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Candidaterole
    {
        public int IdCandidate { get; set; }
        public int IdRole { get; set; }
        public int StartMonth { get; set; }
        public int StartYear { get; set; }
        public int? EndMonth { get; set; }
        public int? EndYear { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
    }
}
