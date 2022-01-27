using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AgentieTurism.Data;
using AgentieTurism.Models;

namespace AgentieTurism.Pages.Clients
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
            ViewData["Genders"] = GetGenders();
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Genders"] = GetGenders();
                return Page();
            }

            _context.Client.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        private SelectList GetGenders()
        {
            var genders = from Gender g in Enum.GetValues(typeof(Gender))
                          select new { ID = (int)g, Name = g.ToString() };
            return new SelectList(genders, "ID", "Name");
        }
    }
}
