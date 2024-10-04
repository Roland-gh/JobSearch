using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearch.Models
{
    public class Job
    {
        public int JobID { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Applied")]
        public DateTime DateApplied { get; set; }

        [DisplayName("Provider")]
        public string? SearchProvider { get; set; }

        [DisplayName("Job Title")]
        public string? JobTitle { get; set; }

        
        public string? Employer { get; set; }

        [DisplayName("Pay Range")]
        public string? PayRange { get; set; }

        [DisplayName("Description")]
        public string? JobDescription { get; set; }
    }
}
