using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class CompetenceModel
{
    [Key]

    public int Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Nome da competência")]
    [StringLength(100, ErrorMessage = "Nome da competência não pode passar de 100 caracteres e não pode ter menos de 10 caracteres", MinimumLength = 3)]
    public string CompetenceName { get; set; }
}
