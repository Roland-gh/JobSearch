using JobSearch.Models;

using Microsoft.EntityFrameworkCore;

namespace JobSearch.Data
{
    public class JobSearchContext : DbContext
    {
        public JobSearchContext()
        {
            
        }

        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6N2QK3F;Database=JobSearch;User Id=DESKTOP-6N2QK3F\\Roland Faulhaber;Password=buck2112;Trusted_Connection=True;TrustServerCertificate=True");
            
        }
    }
}
