using Microsoft.AspNetCore.Mvc.Rendering;
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
    public SelectList EmploymentStatus { get; set; }

    [Required]
    public IEnumerable<FormationModel> Formations { get; set; }

    [Required]
    public IEnumerable<ProfessionalExperienceModel> ProfessionalExperiences { get; set; }

    [Required]
    [MaxLength(2000)]
    [MinLength(10)]
    public string Description { get; set; }

    public class FormationModel
    {
        [Required]
        public string Scholarity { get; set; }
        public string Course { get; set; }//aqui seria um like
        public string Instituion { get; set; }//aqui seria um like

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }

    public class ProfessionalExperienceModel
    {
        [Required]
        public string Role { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}