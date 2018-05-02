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

        public void EditRestaurant(int id, string field, string newvalue)
        {
            switch (field)
            {
                case "Name":
                    RRRavesDBEntities.Set<Restaurant>().Find(id).Name = newvalue;
                    break;
                case "Address":
                    RRRavesDBEntities.Set<Restaurant>().Find(id).Address = newvalue;
                    break;
                case "City":
                    RRRavesDBEntities.Set<Restaurant>().Find(id).City = newvalue;
                    break;
                case "ZipCode":
                    RRRavesDBEntities.Set<Restaurant>().Find(id).Zipcode = newvalue;
                    break;
                case "Phone":
                    RRRavesDBEntities.Set<Restaurant>().Find(id).Phone = newvalue;
                    break;
                case "Website":
                    RRRavesDBEntities.Set<Restaurant>().Find(id).Website = newvalue;
                    break;
                default:
                    break;

            }
        }

        public RRRavesDBEntities RRRavesDBEntities { get { return db as RRRavesDBEntities; } }
    }
}
