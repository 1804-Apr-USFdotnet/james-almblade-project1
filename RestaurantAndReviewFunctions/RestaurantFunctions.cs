using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace RestaurantAndReviewFunctions
{
    public class RestaurantFunctions
    {
        public RestaurantFunctions() {        }

        public void AddRestaurant(Restaurant r)
        {
            using (var WorkUnit = new UnitOfWork(new RRRavesDBEntities()))
            {
                WorkUnit.RestaurantRepo.Add(r);
                WorkUnit.Complete();
            }
        }

        public void RemoveRestaurant(int id)
        {
            using (var uow = new UnitOfWork(new RRRavesDBEntities()))
            {
                var temp = uow.RestaurantRepo.Get(id);
                uow.RestaurantRepo.Remove(temp);
                uow.Complete();
            }
        }

        public void UpdateRestaurant(int id, string field, string newvalue)
        {
            using (var uow = new UnitOfWork(new RRRavesDBEntities()))
            {
                uow.RestaurantRepo.EditRestaurant(id, field, newvalue);
                uow.Complete();
            }
        }
    }
}
