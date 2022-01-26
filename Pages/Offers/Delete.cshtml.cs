using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgentieTurism.Data;
using AgentieTurism.Models;

namespace AgentieTurism.Pages.Offers
{
    public class DeleteModel : PageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public DeleteModel(AgentieTurism.Data.AgentieTurismContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Offer Offer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Offer = await _context.Offer.FirstOrDefaultAsync(m => m.Id == id);

            if (Offer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Offer = await _context.Offer.FindAsync(id);

            if (Offer != null)
            {
                _context.Offer.Remove(Offer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
