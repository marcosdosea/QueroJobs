using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class CandidateModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Nome")]
    [DataType(DataType.Text)]
    [StringLength(100, ErrorMessage = "O campo nome aceita entre 3 e 100 caracteres", MinimumLength = 3)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Digite um email válido")]
    public string Email { get; set; }

    [Display(Name = "CEP")]
    [DataType(DataType.PostalCode)]
    public string Cep { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "País")]
    [StringLength(100, ErrorMessage = "Nome do país tem entre 3 e 100 letras", MinimumLength = 3)]
    public string Country { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Estado")]
    [StringLength(2, ErrorMessage = "Débito técnico, isso no futuro vai ser uma combobox", MinimumLength = 2)]
    public string State { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Cidade")]
    [StringLength(100, ErrorMessage = "Nome da cidade tem entre 3 e 100 letras", MinimumLength = 3)]
    public string City { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Bairro")]
    [StringLength(100, ErrorMessage = "Nome do bairro tem entre 3 e 100 letras", MinimumLength = 3)]
    public string District { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Rua")]
    [StringLength(100, ErrorMessage = "Nome da rua tem entre 3 e 100 letras", MinimumLength = 3)]
    public string Street { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Numero da Casa")]
    [StringLength(6, ErrorMessage = "Numero da casa tem entre 1 e 6 digitos", MinimumLength = 1)]
    public string HouseNumber { get; set; }

    [Display(Name = "Complemento do endereço")]
    [StringLength(100, ErrorMessage = "Complemento do endereço tem no máximo 100 digitos")]
    public string Complement { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Número de celular")]
    [RegularExpression(@"^(\([1-9]{2}\)|[1-9]{2}) ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Exemplo de numero de celular: (12)12345-6789")]
    public string CellphoneNumber { get; set; }

    [Display(Name = "Número de telefone")]
    [RegularExpression(@"^(\([1-9]{2}\)|[1-9]{2}) ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Exemplo de numero de telefone: (12)12345-6789")]
    public string TelephoneNumber { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Data de nascimento")] 
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Genero")]
    [StringLength(1, ErrorMessage = "Débito técnico, isso no futuro vai ser uma combobox", MinimumLength = 1)]
    public string Gender { get; set; }

    [Required(ErrorMessage = "CPF requerido")]
    [RegularExpression(@"([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Deficiência")]
    [StringLength(100, ErrorMessage = "Deficiência tem no máximo 100 digitos")]
    public string Deficiency { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [DataType(DataType.Currency, ErrorMessage = "Digite um valor válido")]
    public decimal SalaryExpectation { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Situação Empregatícia")]
    [StringLength(100, ErrorMessage = "A situação empregatícia tem no máximo 100 digitos")]
    public string EmploymentStatus { get; set; }

    [Display(Name = "Cargo atual")]
    [StringLength(100, ErrorMessage = "O cargo atual tem no máximo 100 digitos")]
    public string ActualRole { get; set; }

    [Display(Name = "Descrição")]
    [StringLength(2000, ErrorMessage = "A descrição tem no máximo 2000 digitos")]
    public string Description { get; set; }
}
