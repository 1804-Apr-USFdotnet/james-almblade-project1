using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace SearchFunction
{
    class RetrieveReviews : IRetrieveReviews
    {
        public Review GetReview(int ReviewID)
        {
            using(var uow = new UnitOfWork(new RRRavesDBEntities()))
            {
                return uow.ReviewRepo.Get(ReviewID);
            }
        }

        public List<Review> RetrieveReviewList(int RestaurantID)
        {
            using(var uow = new UnitOfWork(new RRRavesDBEntities()))
            {
                return uow.ReviewRepo.Find(x => x.Restaurant == RestaurantID).ToList();
            }
        }
    }
}
