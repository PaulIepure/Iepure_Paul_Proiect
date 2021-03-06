using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgentieTurism.Data;
using AgentieTurism.Models;

namespace AgentieTurism.Pages.Offers
{
    public class EditModel : PageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public EditModel(AgentieTurism.Data.AgentieTurismContext context)
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
            ViewData["TimePeriods"] = GetTimePeriods();
            ViewData["MealTypes"] = GetMealTypes();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["TimePeriods"] = GetTimePeriods();
                ViewData["MealTypes"] = GetMealTypes();
                return Page();
            }

            _context.Attach(Offer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(Offer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OfferExists(int id)
        {
            return _context.Offer.Any(e => e.Id == id);
        }
        private SelectList GetTimePeriods()
        {
            var periods = from Period g in Enum.GetValues(typeof(Period))
                          select new { ID = (int)g, Name = g.ToString() };
            return new SelectList(periods, "ID", "Name");
        }
        private SelectList GetMealTypes()
        {
            var mealTypes = from MealType g in Enum.GetValues(typeof(MealType))
                            select new { ID = (int)g, Name = g.ToString() };
            return new SelectList(mealTypes, "ID", "Name");
        }
    }
}
