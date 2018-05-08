using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantAndReviewFunctions;
using SearchFunction;

namespace RRRaves.Web.Models
{
    public class RestaurantAndReviews
    {
        public WebRestaurant WebRest { get; set; }
        public List<WebReview> WebReviews { get; set; }

        public RestaurantAndReviews(int id)
        {
            var sr = new SearchRestaurants();
            var TempRest = sr.GetRestaurant(id);
            var rr = new RetrieveReviews();
            WebRest = WebDataConversion.RestaurantToWeb(TempRest);

            var rlist = rr.RetrieveReviewList(id);
            WebReviews = new List<WebReview>();

            foreach (var item in rlist)
            {
                WebReviews.Add(WebDataConversion.ReviewToWeb(item));
            }
        }
    }
}