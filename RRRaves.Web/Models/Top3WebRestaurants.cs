using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchFunction;

namespace RRRaves.Web.Models
{
    public class Top3WebRestaurants
    {
        public List<WebRestaurant> Top3List { get; set; }

        public Top3WebRestaurants()
        {
            Top3List = new List<WebRestaurant>();

            var search = new SearchRestaurants();

            var Top3Data = search.GetTopRestaurants();

            foreach (var item in Top3Data)
            {
                Top3List.Add(WebDataConversion.RestaurantToWeb(item));
            }
        }
    }
}