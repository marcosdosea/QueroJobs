using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    internal class VacancyDTO
    {
        public int Id { get; set; }
        public int IdCompany { get; set; }
        public int IdRole { get; set; }
        public string VacancyName { get; set; }
        public decimal? Salary { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Modality { get; set; }
        public string Situation { get; set; }
        public int Workload { get; set; }
        public int Quantity { get; set; }
    }
}
