using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Candidate
    {
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
    }
}
