using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace SearchFunction
{
    public interface IRetrieveReviews
    {
        List<Review> RetrieveReviewList(int RestaurantID);
        Review GetReview(int ReviewID);
    }
}
