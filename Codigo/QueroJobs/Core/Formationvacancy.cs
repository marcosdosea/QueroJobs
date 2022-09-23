using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Formationvacancy
    {
        public int Id { get; set; }
        public int IdVacancy { get; set; }
        public int IdCourse { get; set; }
        public int IdScholarity { get; set; }
        public string Status { get; set; }

        public virtual Course IdCourseNavigation { get; set; }
        public virtual Scholarity IdScholarityNavigation { get; set; }
        public virtual Vacancy IdVacancyNavigation { get; set; }
    }
}
