using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RRRavesDBEntities db) : base(db) { }

        public IEnumerable<Restaurant> GetTopThree()
        {
            return RRRavesDBEntities.Set<Restaurant>().OrderByDescending(x => x.AveRating).Take(3);
        }

        public new Restaurant Get(int id)
        {
            var temp = db.Set<Restaurant>().SingleOrDefault(i => i.ID_Restaurant == id);
            return temp;
        }

        public void EditRestaurant(int id, Restaurant restaurant)
        {
            //var rest = RRRavesDBEntities.Set<Restaurant>().Single(i => i.ID_Restaurant == id);
            //if (rest != null)
            //{
            //    rest.Name = restaurant.Name;
            //    rest.Address = restaurant.Address;
            //    rest.City = restaurant.City;
            //    rest.Zipcode = restaurant.Zipcode;
            //    rest.Phone = restaurant.Phone;
            //    rest.Website = restaurant.Website;
            //}

            var oldRest = RRRavesDBEntities.Restaurants.Find(id);
            RRRavesDBEntities.Entry(oldRest).CurrentValues.SetValues(restaurant);
        }

        public new void Remove(Restaurant entity)
        {
            RRRavesDBEntities.Set<Restaurant>().Remove(entity);
        }

        public RRRavesDBEntities RRRavesDBEntities { get { return db as RRRavesDBEntities; } }
    }
}
