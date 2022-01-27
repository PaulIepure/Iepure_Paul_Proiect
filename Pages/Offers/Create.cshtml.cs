using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AgentieTurism.Data;
using AgentieTurism.Models;

namespace AgentieTurism.Pages.Offers
{
    public class CreateModel : PageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public CreateModel(AgentieTurism.Data.AgentieTurismContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TimePeriods"] = GetTimePeriods();
            ViewData["MealTypes"] = GetMealTypes();
            return Page();
        }

        [BindProperty]
        public Offer Offer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["TimePeriods"] = GetTimePeriods();
                ViewData["MealTypes"] = GetMealTypes();
                return Page();
            }

            _context.Offer.Add(Offer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
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
