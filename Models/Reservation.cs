using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgentieTurism.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        public Client Client { get; set; }
        [Required]
        public Offer Offer { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        [Display(Name = "Number Of Units")]
        public int NumberOfUnits { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModify { get; set; }
    }
}
