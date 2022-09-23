using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Candidatevacancy
    {
        public int IdVacancy { get; set; }
        public int IdCandidate { get; set; }
        public DateTime SubmitDate { get; set; }
        public string Situation { get; set; }
        public string Message { get; set; }

        public virtual Candidate IdCandidateNavigation { get; set; }
        public virtual Vacancy IdVacancyNavigation { get; set; }
    }
}
