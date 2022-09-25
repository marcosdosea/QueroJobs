#nullable disable

namespace Core
{
    public partial class Candidateformation
    {
        public int IdCandidate { get; set; }
        public int IdFormation { get; set; }

        public virtual Formation IdFormationNavigation { get; set; }
    }
}
