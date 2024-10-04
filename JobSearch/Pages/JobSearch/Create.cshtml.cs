using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobSearch.Data;
using JobSearch.Models;

namespace JobSearch.Pages.JobSearch
{
    public class CreateModel : PageModel
    {
        private readonly JobSearchContext _context;

        public CreateModel(JobSearchContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Job Job { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Jobs.Add(Job);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
