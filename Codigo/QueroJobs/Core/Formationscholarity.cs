#nullable disable

namespace Core
{
    public partial class Formationscholarity
    {
        public int IdFormation { get; set; }
        public int IdScholarity { get; set; }

        public virtual Formation IdFormationNavigation { get; set; }
        public virtual Scholarity IdScholarityNavigation { get; set; }
    }
}
