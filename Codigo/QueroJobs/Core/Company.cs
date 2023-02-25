#nullable disable

namespace Core
{
    public partial class Company
    {
        public Company()
        {
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string FantasyName { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Complement { get; set; }
        public string CellphoneNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string Cnpj { get; set; }
        public string StateRegistration { get; set; }
        public string CorporateName { get; set; }
        public string ResponsibleName { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
