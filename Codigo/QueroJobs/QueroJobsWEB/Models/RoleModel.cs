using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class RoleModel
{
    [Key]

    public int Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Nome do cargo")]
    [StringLength(100, ErrorMessage = "Nome do cargo não pode passar de 100 caracteres e não pode ter menos de 3 caracteres", MinimumLength = 3)]
    public string RoleName { get; set; }
}
