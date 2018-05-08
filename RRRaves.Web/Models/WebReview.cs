using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RRRaves.Web.Models
{
    public class WebReview
    {
        public int ReviewID { get; set; }
        [Required, Range(1,10)]
        public int Rating { get; set; }
        [Required, StringLength(240)]
        public string ReviewText { get; set; }
        public Nullable<int> Restaurant { get; set; }
    }
}