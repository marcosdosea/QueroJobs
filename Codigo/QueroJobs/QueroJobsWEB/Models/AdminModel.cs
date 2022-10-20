using Core;

namespace QueroJobsWEB.Models
{
    public class AdminModel
    {
        public IEnumerable<Company> company { get; set; }
        public IEnumerable<Candidate> candidate { get; set; }
        public IEnumerable<Competence> competence { get; set; }
        public IEnumerable<Course> course { get; set; }
        public IEnumerable<Role> role { get; set; }
        public IEnumerable<Institution> institution { get; set; }
        public IEnumerable<Vacancy> vacancy { get; set; }
    }
}
