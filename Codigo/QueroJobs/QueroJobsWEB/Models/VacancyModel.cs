using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class VacancyModel
{
    [Key]
    public int Id { get; set; }


    [Required(ErrorMessage = "Campo requerido")]
    public int IdCompany { get; set; }


    [Required(ErrorMessage = "Campo requerido")]
    public int IdRole { get; set; }


    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Nome da Vaga")]
    [DataType(DataType.Text)]
    [StringLength(100, ErrorMessage = "O campo nome aceita entre 3 e 100 caracteres", MinimumLength = 3)]
    public string VacancyName { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [DataType(DataType.Currency, ErrorMessage = "Digite um valor válido")]
    public decimal? Salary { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Data de abertura")]
    [DataType(DataType.Date)]
    public DateTime OpenDate { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Data de fechamento")]
    [DataType(DataType.Date)]
    public DateTime CloseDate { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Descrição da Vaga")]
    [DataType(DataType.Text)]
    [StringLength(100, ErrorMessage = "O campo nome aceita entre 3 e 100 caracteres", MinimumLength = 3)]
    public string Description { get; set; }


    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Localidade da Vaga")]
    [DataType(DataType.Text)]
    [StringLength(100, ErrorMessage = "O campo nome aceita entre 3 e 100 caracteres", MinimumLength = 3)]
    public string Location { get; set; }


    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Nome da Modalidade da Vaga")]
    [DataType(DataType.Text)]
    [StringLength(100, ErrorMessage = "O campo nome aceita entre 3 e 100 caracteres", MinimumLength = 3)]
    public string Modality { get; set; }


    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Nome da Situação da Vaga")]
    [DataType(DataType.Text)]
    [StringLength(100, ErrorMessage = "O campo nome aceita entre 3 e 100 caracteres", MinimumLength = 3)]
    public string Situation { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [RegularExpression(@"([1-9]")] // TODO: Pesquisar
    public int Workload { get; set; }


    //TODO: Pesquisar qual restrição colocar para esse inteiro
    [Required(ErrorMessage = "Campo requerido")]
    public int Quantity { get; set; }
}
