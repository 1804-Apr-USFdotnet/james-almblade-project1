using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAverager
    {
        void AverageRatingsAdd(int RestaurantID, int NewRating);
        void AverageRatingsEdit(int RestaurantID, int OldRating, int NewRating);
        void AverageRatingsRemove(int RestaurantID, int OldRating);
    }
}
