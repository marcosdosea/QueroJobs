#nullable disable

namespace Core
{
    public partial class Competence
    {
        public Competence()
        {
            Candidatecompetences = new HashSet<Candidatecompetence>();
            Vacancycompetences = new HashSet<Vacancycompetence>();
        }

        public int Id { get; set; }
        public string CompetenceName { get; set; }

        public virtual ICollection<Candidatecompetence> Candidatecompetences { get; set; }
        public virtual ICollection<Vacancycompetence> Vacancycompetences { get; set; }
    }
}
