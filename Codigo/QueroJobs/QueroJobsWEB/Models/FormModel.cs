using System.ComponentModel.DataAnnotations;

namespace QueroJobsWEB.Models;

public class FormModel
{
    [Key]
    public int CandidateId { get; set; }
    [Required]
    public IEnumerable<string> OccupationAreaNames { get; set; }

    [Required]
    public decimal SalaryExpectation { get; set; }

    [Required]
    [Display(Name = "Pretensão salarial")]
    public string EmploymentStatus { get; set; }

    [Required]
    public string Scholarity { get; set; }
    public string Course { get; set; }
    public string Instituion { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ScholarityStartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? ScholarityEndDate { get; set; }

    [Required]
    public string Role { get; set; }

    [Required]
    public int ProfessionalExperienceStartMonth { get; set; }

    public int? ProfessionalExperienceEndMonth { get; set; }

    [Required]
    public int ProfessionalExperienceStartYear { get; set; }

    public int? ProfessionalExperienceEndYear { get; set; }
    [Required]
    [MaxLength(2000)]
    [MinLength(10)]
    public string Description { get; set; }

}