using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Vacancyformation
    {
        public int IdVacancy { get; set; }
        public int IdFormation { get; set; }

        public virtual Formation IdFormationNavigation { get; set; }
        public virtual Vacancy IdVacancyNavigation { get; set; }
    }
}
