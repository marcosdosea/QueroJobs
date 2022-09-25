#nullable disable

namespace Core
{
    public partial class Formationcourse
    {
        public int IdFormation { get; set; }
        public int IdCourse { get; set; }

        public virtual Course IdCourseNavigation { get; set; }
        public virtual Formation IdFormationNavigation { get; set; }
    }
}
