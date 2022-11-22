using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class FormModel
{
    [Key]
    public int CandidateId { get; set; }
    [Required]
    [Display(Name = "Area de ocupação")]
    public IEnumerable<string> OccupationAreaNames { get; set; }

    [Required]
    [Display(Name = "Pretensão salarial")]
    public decimal SalaryExpectation { get; set; }

    [Required]
    [Display(Name = "Situação empregatícia")]
    public string EmploymentStatus { get; set; }

    [Required]
    [Display(Name = "Escolaridade")]
    public string Scholarity { get; set; }
    [Display(Name = "Curso")]
    public string Course { get; set; }
    [Display(Name = "Instituição")]
    public string Instituion { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Data de início")]
    public DateTime ScholarityStartDate { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data de fim")]
    public DateTime? ScholarityEndDate { get; set; }

    [Required]
    [Display(Name = "Cargo")]
    public string Role { get; set; }

    [Required]
    [Display(Name = "Mês de início")]
    [Range(1, 12)]
    public int ProfessionalExperienceStartMonth { get; set; }

    [Range(1, 12)]
    [Display(Name = "Mês de Conclusão")]
    public int? ProfessionalExperienceEndMonth { get; set; }

    [Required]
    [Range(1900, 2022)]
    [Display(Name = "Ano de início")]
    public int ProfessionalExperienceStartYear { get; set; }

    [Range(1900, 2022)]
    [Display(Name = "Ano de Conclusão")]
    public int? ProfessionalExperienceEndYear { get; set; }

    [Required]
    [MaxLength(2000)]
    [MinLength(10)]
    public string Description { get; set; }

}