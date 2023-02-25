#nullable disable

namespace Core
{
    public partial class Occupationarea
    {
        public Occupationarea()
        {
            Candidateoccupationareas = new HashSet<Candidateoccupationarea>();
            Vacancyoccupationareas = new HashSet<Vacancyoccupationarea>();
        }

        public int Id { get; set; }
        public string OccupationAreaName { get; set; }

        public virtual ICollection<Candidateoccupationarea> Candidateoccupationareas { get; set; }
        public virtual ICollection<Vacancyoccupationarea> Vacancyoccupationareas { get; set; }
    }
}
