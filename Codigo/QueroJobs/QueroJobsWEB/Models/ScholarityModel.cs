using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class ScholarityModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Nome da escolaridade")]
    [StringLength(100, ErrorMessage = "Nome da escolaridade não pode passar de 100 caracteres e não pode ter menos de 3 caracteres", MinimumLength = 3)]
    public string ScholarityName { get; set; }
}
