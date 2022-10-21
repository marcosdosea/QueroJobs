using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class InstitutionModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Instituição")]
    [DataType(DataType.Text)]
    [StringLength(100, ErrorMessage = "O campo Curso aceita entre 3 e 100 caracteres", MinimumLength = 3)]
    public string InstitutionName { get; set; }
}

