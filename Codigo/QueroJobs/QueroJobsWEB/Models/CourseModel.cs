using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class CourseModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Curso")]
    [DataType(DataType.Text)]
    [StringLength(100, ErrorMessage = "O campo Curso aceita entre 3 e 100 caracteres", MinimumLength = 3)]
    public string CourseName { get; set; }

}
