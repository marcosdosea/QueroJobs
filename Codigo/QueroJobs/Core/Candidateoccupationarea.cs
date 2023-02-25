#nullable disable

namespace Core
{
    public partial class Candidateoccupationarea
    {
        public int IdCandidate { get; set; }
        public int IdOccupationArea { get; set; }

        public virtual Candidate IdCandidateNavigation { get; set; }
        public virtual Occupationarea IdOccupationAreaNavigation { get; set; }
    }
}
