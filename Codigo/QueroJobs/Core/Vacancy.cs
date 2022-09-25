#nullable disable

namespace Core
{
    public partial class Vacancy
    {
        public Vacancy()
        {
            Candidatevacancies = new HashSet<Candidatevacancy>();
            Formationvacancies = new HashSet<Formationvacancy>();
            Vacancycompetences = new HashSet<Vacancycompetence>();
            Vacancyoccupationareas = new HashSet<Vacancyoccupationarea>();
        }

        public int Id { get; set; }
        public int IdCompany { get; set; }
        public int IdRole { get; set; }
        public string VacancyName { get; set; }
        public decimal? Salary { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Modality { get; set; }
        public string Situation { get; set; }
        public int Workload { get; set; }
        public int Quantity { get; set; }

        public virtual Company IdCompanyNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<Candidatevacancy> Candidatevacancies { get; set; }
        public virtual ICollection<Formationvacancy> Formationvacancies { get; set; }
        public virtual ICollection<Vacancycompetence> Vacancycompetences { get; set; }
        public virtual ICollection<Vacancyoccupationarea> Vacancyoccupationareas { get; set; }
    }
}
