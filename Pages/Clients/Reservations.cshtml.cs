using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentieTurism.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgentieTurism.Pages.Clients
{
    public class ReservationsModel : PageModel
    {
        private readonly AgentieTurism.Data.AgentieTurismContext _context;

        public ReservationsModel(AgentieTurism.Data.AgentieTurismContext context)
        {
            _context = context;
        }
        public List<Reservation> Reservations { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Reservations = await _context.Reservation.Include(r=>r.Client)
                .Include(r=>r.Offer).Where(r => r.Client.Id == id).ToListAsync();

            if (Reservations == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
