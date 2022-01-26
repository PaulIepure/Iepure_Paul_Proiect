using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgentieTurism.Models
{
    public class Client
    {
        public int Id { get; set; }
        [RegularExpression("([0-9]{13})", ErrorMessage = "The CNP value must contain 13 numbers.")]
        [Required]
        public string CNP { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Full address")]
        [Required]
        public string FullAddress { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [RegularExpression("([0-9]{10})", ErrorMessage = "The Phone Number value must contain 10 numbers.")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
}
