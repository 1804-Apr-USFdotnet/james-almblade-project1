using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace MyJsonSerializer
{
    public interface ISerializer
    {
        void RestaurantToJson(Restaurant restaurant, string filepath);
        Restaurant JsonToRestaurant(string filepath);
        void ReviewToJson(Review review, string filepath);
        Review JsonToReview(string filepath);
    }
}
