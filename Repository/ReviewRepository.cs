using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(RRRavesDBEntities db) : base(db) { }

        public new Review Get(int id)
        {
            var temp = db.Set<Review>().SingleOrDefault(i => i.ID_Review == id);
            return temp;
        }

        public new void Add(Review entity)
        {
            RRRavesDBEntities.Set<Review>().Add(entity);
            int RestId = (int)entity.Restaurant;
            this.AverageRatingsAdd(RestId, entity.Rating);
        }

        public new void AddRange(IEnumerable<Review> entities)
        {
            RRRavesDBEntities.Set<Review>().AddRange(entities);
            foreach (var item in entities)
            {
                int RestId = (int)item.Restaurant;
                this.AverageRatingsAdd(RestId, item.Rating);
            }

        }

        public new void Remove(Review entity)
        {
            int RestId = entity.Restaurant.Value;
            int OldRate = entity.Rating;

            this.AverageRatingsRemove(RestId, OldRate);

            RRRavesDBEntities.Set<Review>().Remove(entity);
        }

        public new void RemoveRange(IEnumerable<Review> entities)
        {
            foreach (var item in entities)
            {
                int RestId = (int)item.Restaurant;
                int OldRate = (int)item.Rating;
                this.AverageRatingsRemove(RestId, OldRate);
                RRRavesDBEntities.Set<Review>().Remove(item);
            }
        }

        public void EditReview(int id, Review r)
        {
            //var rest = RRRavesDBEntities.Set<Review>().Single(i => i.ID_Review == id);
            //if (rest != null)
            //{
            //    rest.Rating = r.Rating;
            //    rest.ReviewText = r.ReviewText;

            //}

            var oldReview = RRRavesDBEntities.Reviews.Find(id);
            var oldRate = oldReview.Rating;

            RRRavesDBEntities.Entry(oldReview).CurrentValues.SetValues(r);
            this.AverageRatingsEdit(r.Restaurant.Value, oldRate, r.Rating);


        }

        public void AverageRatingsAdd(int RestaurantID, int NewRating)
        {
            var temp = RRRavesDBEntities.Set<Review>().Where(x => x.Restaurant == RestaurantID);
            var temp2 = temp.Select(x => x.Rating).ToList();
            temp2.Add(NewRating);

            var temp3 = Convert.ToDecimal(temp2.DefaultIfEmpty().Average());

            RRRavesDBEntities.Set<Restaurant>().Find(RestaurantID).AveRating = temp3;
        }


        public void AverageRatingsEdit(int RestaurantID, int OldRating, int NewRating)
        {
            var temp = RRRavesDBEntities.Set<Review>().Where(x => x.Restaurant == RestaurantID);
            var temp2 = temp.Select(x => x.Rating).ToList();
            temp2.Remove(OldRating);
            temp2.Add(NewRating);

            var temp3 = Convert.ToDecimal(temp2.DefaultIfEmpty().Average());

            RRRavesDBEntities.Set<Restaurant>().Find(RestaurantID).AveRating = temp3;
        }

        public void AverageRatingsRemove(int RestaurantID, int OldRating)
        {
            var temp = RRRavesDBEntities.Set<Review>().Where(x => x.Restaurant == RestaurantID);
            var temp2 = temp.Select(x => x.Rating).ToList();
            temp2.Remove(OldRating);

            var temp3 = Convert.ToDecimal(temp2.DefaultIfEmpty().Average());

            RRRavesDBEntities.Set<Restaurant>().Find(RestaurantID).AveRating = temp3;
        }

        public RRRavesDBEntities RRRavesDBEntities { get { return db as RRRavesDBEntities; } }
    }
}
