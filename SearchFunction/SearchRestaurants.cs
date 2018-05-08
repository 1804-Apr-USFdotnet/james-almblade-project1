using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Repository;

namespace SearchFunction
{
    public class SearchRestaurants : ISearchRestaurants
    {
        public SearchRestaurants()
        {
        }

        static Logger logger = NLog.LogManager.GetCurrentClassLogger();

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
                    logger.Debug(e, e.Message);
                    throw;
                }
            }
        }

        public List<Restaurant> FindRestaurants(string s)
        {
            try
            {

                using (var WorkUnit = new UnitOfWork(new RRRavesDBEntities()))
                {
                    return WorkUnit.RestaurantRepo.Find(x => x.Name.ToUpper().Contains(s.ToUpper())).ToList();
                }
            }
            catch (Exception e)
            {
                logger.Debug(e, e.Message);
                throw;
            }
        }

        public Restaurant GetRestaurant(int id)
        {
            try
            {
                using (var WorkUnit = new UnitOfWork(new RRRavesDBEntities()))
                {
                    return WorkUnit.RestaurantRepo.Get(id);
                }
            }
            catch (Exception e)
            {
                logger.Debug(e, e.Message);
                throw;
            }

        }
    }
}
