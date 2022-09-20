using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Vacancycompetence
    {
        public int IdVacancy { get; set; }
        public int IdCompetence { get; set; }

        public virtual Vacancy IdVacancyNavigation { get; set; }
    }
}
