using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class LoginCompanyModel
{
    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Email *")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Digite um email válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Senha *")]
    public string Password { get; set; }
}