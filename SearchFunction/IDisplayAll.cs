using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace SearchFunction
{
    public interface IDisplayAll
    {
        List<Restaurant> RestaurantsByName();
        List<Restaurant> RestaurantsByRating();
        List<Review> ReviewsDescending();
        List<Review> ReviewsAscending();
    }
}
