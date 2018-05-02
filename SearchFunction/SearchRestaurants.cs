using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace SearchFunction
{
    public class SearchRestaurants : ISearchRestaurants
    {
        public SearchRestaurants()
        {
        }

        public List<Restaurant> GetTopRestaurants()
        {
            using (var WorkUnit = new UnitOfWork(new RRRavesDBEntities()))
            {
                try
                {
                    return WorkUnit.RestaurantRepo.GetTopThree().ToList();
                }
                catch (Exception e)
                {
                    var logger = NLog.LogManager.GetCurrentClassLogger();
                    logger.Debug(e, e.Message);
                    throw;
                }
            }
        }

        public List<Restaurant> FindRestaurants(string s)
        {
            using (var WorkUnit = new UnitOfWork(new RRRavesDBEntities()))
            {
                return WorkUnit.RestaurantRepo.Find(x => x.Name.ToUpper().Contains(s.ToUpper())).ToList();
            }
        }

        public Restaurant GetRestaurant(int id)
        {
            using (var WorkUnit = new UnitOfWork(new RRRavesDBEntities()))
            {
                return WorkUnit.RestaurantRepo.Get(id);
            }
        }
    }
}
