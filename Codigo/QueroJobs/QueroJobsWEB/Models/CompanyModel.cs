using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class CompanyModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Nome Fantasia *")]
    [DataType(DataType.Text)]
    [StringLength(100, ErrorMessage = "O campo FantasyName aceita entre 3 e 100 caracteres", MinimumLength = 3)]
    public string FantasyName { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Email *")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Digite um email válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "CEP *")]
    [DataType(DataType.PostalCode)]
    public string? Cep { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "País *")]
    [StringLength(100, ErrorMessage = "Nome do país tem entre 3 e 100 letras", MinimumLength = 3)]
    public string Country { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Estado *")]
    [StringLength(2)]
    public string State { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Cidade *")]
    [StringLength(100, ErrorMessage = "Nome da cidade tem entre 3 e 100 letras", MinimumLength = 3)]
    public string City { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Bairro *")]
    [StringLength(100, ErrorMessage = "Nome do bairro tem entre 3 e 100 letras", MinimumLength = 3)]
    public string District { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Rua *")]
    [StringLength(100, ErrorMessage = "Nome da rua tem entre 3 e 100 letras", MinimumLength = 3)]
    public string Street { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Número *")]
    [StringLength(6, ErrorMessage = "Numero da casa tem entre 1 e 6 digitos", MinimumLength = 1)]
    public string HouseNumber { get; set; }

    [Display(Name = "Complemento do endereço")]
    [StringLength(100, ErrorMessage = "Complemento do endereço tem no máximo 100 digitos")]
    public string? Complement { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Celular")]
    [RegularExpression(@"^(\([1-9]{2}\)|[1-9]{2}) ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Exemplo de numero de celular: (12)12345-6789")]
    public string CellphoneNumber { get; set; }

    [Display(Name = "Telefone")]
    [RegularExpression(@"^(\([1-9]{2}\)|[1-9]{2}) ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Exemplo de numero de telefone: (12)12345-6789")]
    public string? TelephoneNumber { get; set; }

    [Required(ErrorMessage = "CNPJ requerido")]
    [Display(Name = "CNPJ *")]
    [RegularExpression(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})")]
    public string Cnpj { get; set; }

    [Display(Name = "Registro Estadual")]
    [StringLength(9, ErrorMessage = "Registro Estadual tem 9 digitos")]
    public string? StateRegistration { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Razão Social *")]
    [StringLength(150, ErrorMessage = "Nome do bairro tem entre 3 e 150 letras", MinimumLength = 3)]
    public string CorporateName { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Nome Completo do responsável *")]
    [StringLength(100, ErrorMessage = "Nome do responsável deve ter entre 3 e 100 letras", MinimumLength = 3)]
    public string ResponsibleName { get; set; }

    [Display(Name = "Senha")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Confirmar senha")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "As senha devem ser iguais")]
    public string ConfirmPassword { get; set; }
}
