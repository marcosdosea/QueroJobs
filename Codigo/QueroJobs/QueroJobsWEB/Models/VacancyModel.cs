using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class VacancyModel
{
    [Key]
    public int Id { get; set; }
    public int IdCompany { get; set; }
    public int IdRole { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Vaga")]
    [DataType(DataType.Text)]
    [StringLength(100, ErrorMessage = "O campo nome aceita entre 3 e 100 caracteres", MinimumLength = 3)]
    public string VacancyName { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Salário")]
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
    [Display(Name = "Modalidade")]
    [DataType(DataType.Text)]
    [StringLength(100, ErrorMessage = "O campo nome aceita entre 3 e 100 caracteres", MinimumLength = 3)]
    public string Modality { get; set; }


    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Situação")]
    [DataType(DataType.Text)]
    [StringLength(100, ErrorMessage = "O campo nome aceita entre 3 e 100 caracteres", MinimumLength = 3)]
    public string Situation { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Carga horária")]
    [Range(1, 24, ErrorMessage = "A carga horária tem que estar enttre 1 e 24")]
    public int Workload { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Quantidade de vagas")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantidade de vagas tem que ser maior que 0")]
    public int Quantity { get; set; }
}
