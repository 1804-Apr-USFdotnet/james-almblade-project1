using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;

namespace RRRaves.Web.Models
{
    static public class WebDataConversion
    {

        static public WebRestaurant RestaurantToWeb(Restaurant r)
        {
            WebRestaurant wr = new WebRestaurant()
            {
                RestaurantID = r.ID_Restaurant,
                Name = r.Name,
                City = r.City,
                Address = r.Address,
                Phone = r.Phone,
                Zipcode = r.Zipcode,
                Website = r.Website,
                AveRating = r.AveRating
            };

            return wr;
        }

        static public Restaurant WebRestaurantToData(WebRestaurant wr)
        {
            Restaurant r = new Restaurant()
            {
                ID_Restaurant = wr.RestaurantID,
                Name = wr.Name,
                City = wr.City,
                Address = wr.Address,
                Phone = wr.Phone,
                Zipcode = wr.Zipcode,
                Website = wr.Website,
                AveRating = wr.AveRating
            };

            return r;
        }

        static public WebReview ReviewToWeb(Review r)
        {
            WebReview wr = new WebReview()
            {
                ReviewID = r.ID_Review,
                Rating = r.Rating,
                ReviewText = r.ReviewText,
                Restaurant = r.Restaurant
            };
            return wr;
        }

        static public Review WebReviewToData(WebReview wr)
        {
            Review r = new Review()
            {
                ID_Review = wr.ReviewID,
                Rating = wr.Rating,
                ReviewText = wr.ReviewText,
                Restaurant = wr.Restaurant
            };
            return r;
        }
    }
}