using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace RestaurantAndReviewFunctions
{
    public class ReviewFunctions
    {
        public ReviewFunctions() { }

        public void AddReview(Review r)
        {
            using (var WorkUnit = new UnitOfWork(new RRRavesDBEntities()))
            {
                WorkUnit.ReviewRepo.Add(r);
                WorkUnit.Complete();
            }
        }

        public void RemoveReview(int id)
        {
            using (var uow = new UnitOfWork(new RRRavesDBEntities()))
            {
                var temp = uow.ReviewRepo.Get(id);
                uow.ReviewRepo.Remove(temp);
                uow.Complete();
            }
        }

        public void UpdateReview(int id, string field, string newvalue)
        {
            using (var uow = new UnitOfWork(new RRRavesDBEntities()))
            {
                uow.ReviewRepo.EditReview(id, field, newvalue);
                uow.Complete();
            }
        }
    }
}
