using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class RoleModel
{
    [Key]
    
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Nome da vaga")]
    [StringLength(100, ErrorMessage = "Nome da vaga não pode passar de 100 caracteres  não pode ter menos de 3 caracteres", MinimumLength = 3)]
    public string RoleName { get; set; }
}
