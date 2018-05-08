using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RRRaves.Web.Models
{
    public class WebRestaurant
    {
        public int RestaurantID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required, DataType(DataType.PostalCode)]
        [RegularExpression(@"\d{5}", ErrorMessage = "Please give a valid zip code.")]
        public string Zipcode { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please give a valid phone number.")]
        public string Phone { get; set; }
        [Required]
        public string Website { get; set; }
        [Display(Name = "Average Rating")]
        public decimal AveRating { get; set; }
    }
}