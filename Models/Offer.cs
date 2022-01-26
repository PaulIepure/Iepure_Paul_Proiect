using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgentieTurism.Models
{
    public class Offer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Please enter a value bigger than 1")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Time Period")]
        public Period TimePeriod { get; set; }
        [Required]
        [Display(Name = "Meal Type")]
        public MealType MealType { get; set; }
        [Required]
        [Display(Name = "Number Of Persons")]
        public int NumberOfPersons { get; set; }
    }
}
