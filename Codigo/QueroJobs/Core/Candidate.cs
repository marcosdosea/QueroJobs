#nullable disable

namespace Core
{
    public partial class Candidate
    {
        public Candidate()
        {
            Candidatecompetences = new HashSet<Candidatecompetence>();
            Candidateoccupationareas = new HashSet<Candidateoccupationarea>();
            Candidateroles = new HashSet<Candidaterole>();
            Candidatevacancies = new HashSet<Candidatevacancy>();
            Formations = new HashSet<Formation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
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
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Cpf { get; set; }
        public string Deficiency { get; set; }
        public decimal SalaryExpectation { get; set; }
        public string EmploymentStatus { get; set; }
        public string ActualRole { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Candidatecompetence> Candidatecompetences { get; set; }
        public virtual ICollection<Candidateoccupationarea> Candidateoccupationareas { get; set; }
        public virtual ICollection<Candidaterole> Candidateroles { get; set; }
        public virtual ICollection<Candidatevacancy> Candidatevacancies { get; set; }
        public virtual ICollection<Formation> Formations { get; set; }
    }
}
