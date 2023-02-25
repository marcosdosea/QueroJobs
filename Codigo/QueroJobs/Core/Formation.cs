#nullable disable

namespace Core
{
    public partial class Formation
    {
        public int Id { get; set; }
        public int IdCandidate { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int IdCourse { get; set; }
        public int IdInstitution { get; set; }
        public int IdScholarity { get; set; }

        public virtual Candidate IdCandidateNavigation { get; set; }
        public virtual Course IdCourseNavigation { get; set; }
        public virtual Institution IdInstitutionNavigation { get; set; }
        public virtual Scholarity IdScholarityNavigation { get; set; }
    }
}
