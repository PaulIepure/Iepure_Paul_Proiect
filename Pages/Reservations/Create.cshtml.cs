using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AgentieTurism.Data;
using AgentieTurism.Models;

namespace AgentieTurism.Pages.Reservations
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
            ViewData["Clients"] = GetClients();
            ViewData["Offers"] = GetOffers();
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Reservation.Client.CNP");
            ModelState.Remove("Reservation.Client.FirstName");
            ModelState.Remove("Reservation.Client.LastName");
            ModelState.Remove("Reservation.Client.FullAddress");
            ModelState.Remove("Reservation.Client.BirthDate");
            ModelState.Remove("Reservation.Client.PhoneNumber");
            ModelState.Remove("Reservation.Client.Email");
            ModelState.Remove("Reservation.Offer.Name");
            ModelState.Remove("Reservation.Offer.Description");
            ModelState.Remove("Reservation.Offer.Price");
            ModelState.Remove("Reservation.Offer.NumberOfPersons");
            if (!ModelState.IsValid)
            {
                ViewData["Clients"] = GetClients();
                ViewData["Offers"] = GetOffers();
                return Page();
            }
            Reservation.Client = _context.Client.FirstOrDefault(c => c.Id == Reservation.Client.Id);
            Reservation.Offer = _context.Offer.FirstOrDefault(o => o.Id == Reservation.Offer.Id);
            Reservation.DateCreated = DateTime.Now;
            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        private SelectList GetClients()
        {
            var clients = from Client c in _context.Client.ToList()
                        select new { ID = (int)c.Id, Name =  c.FirstName+" "+ c.LastName};
            return new SelectList(clients, "ID", "Name");
        }
        private SelectList GetOffers()
        {
            var offers = from Offer o in _context.Offer.ToList()
                            select new { ID = o.Id, Name = o.Name };
            return new SelectList(offers, "ID", "Name");
        }
    }
}
