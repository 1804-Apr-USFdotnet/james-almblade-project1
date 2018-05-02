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
            RRRavesDBEntities.Set<Review>().Remove(entity);
            int RestId = (int)entity.Restaurant;
        }

        public new void RemoveRange(IEnumerable<Review> entities)
        {
            RRRavesDBEntities.Set<Review>().RemoveRange(entities);
            foreach (var item in entities)
            {
                int RestId = (int)item.Restaurant;
            }
        }

        public void EditReview(int id, string field, string newvalue)
        {
            switch (field)
            {
                case "Rating":
                    var oldRating = RRRavesDBEntities.Set<Review>().Find(id).Rating;
                    RRRavesDBEntities.Set<Review>().Find(id).Rating = Convert.ToInt32(newvalue);
                    var rid = (int)RRRavesDBEntities.Set<Review>().Find(id).Restaurant;
                    this.AverageRatingsEdit(rid, oldRating, Convert.ToInt32(newvalue));
                    break;
                case "ReviewText":
                    RRRavesDBEntities.Set<Review>().Find(id).ReviewText = newvalue;
                    break;
                default:
                    break;

            }
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
