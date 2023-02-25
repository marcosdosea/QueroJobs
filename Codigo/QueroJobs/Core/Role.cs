#nullable disable

namespace Core
{
    public partial class Role
    {
        public Role()
        {
            Candidateroles = new HashSet<Candidaterole>();
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Candidaterole> Candidateroles { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
