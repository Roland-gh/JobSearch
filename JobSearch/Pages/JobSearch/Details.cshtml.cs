using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobSearch.Data;
using JobSearch.Models;

namespace JobSearch.Pages.JobSearch
{
    public class DetailsModel : PageModel
    {
        private readonly JobSearchContext _context;

        public DetailsModel(JobSearchContext context)
        {
            _context = context;
        }

        public Job Job { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.FirstOrDefaultAsync(m => m.JobID == id);
            
            if (job == null)
            {
                return NotFound();
            }
            else
            {
                Job = job;
            }
            return Page();
        }
    }
}
