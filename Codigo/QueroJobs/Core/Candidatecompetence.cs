using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Candidatecompetence
    {
        public int IdCandidate { get; set; }
        public int IdCompetence { get; set; }

        public virtual Candidate IdCandidateNavigation { get; set; }
        public virtual Competence IdCompetenceNavigation { get; set; }
    }
}
