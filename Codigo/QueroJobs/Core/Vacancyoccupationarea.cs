#nullable disable

namespace Core
{
    public partial class Vacancyoccupationarea
    {
        public int IdOccupationArea { get; set; }
        public int IdVacancy { get; set; }

        public virtual Occupationarea IdOccupationAreaNavigation { get; set; }
        public virtual Vacancy IdVacancyNavigation { get; set; }
    }
}
