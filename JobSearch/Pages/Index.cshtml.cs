using JobSearch.Data;
using JobSearch.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Pages
{
    public class IndexModel : PageModel
    {
        private readonly JobSearchContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(JobSearchContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }



        public PaginatedList<Job> Job { get; set; } = default!;
        public int NumberOfJobs { get; set; } = 0;

        
        public string? SearchString { get; set; }

        public async Task OnGetAsync(int? pageIndex, string searchString)
        {
            IQueryable<Job> JobIQ;

            

            if (searchString != null)
            {
                 JobIQ = from j in _context.Jobs.Where(j => j.JobTitle.Contains(searchString))
                                        select j;

                //JobIQ = _context.Jobs.Where(j => j.JobTitle.Contains(searchString));
            }
            else 
            {
                JobIQ = from j in _context.Jobs
                                        select j;
            }


            var pageSize = _configuration.GetValue("PageSize", 10);
            NumberOfJobs = _context.Jobs.Count();
            Job = await PaginatedList<Job>.CreateAsync(JobIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
