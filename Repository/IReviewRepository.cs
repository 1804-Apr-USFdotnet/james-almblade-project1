using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IReviewRepository : IRepository<Review>, IAverager
    {
        void EditReview(int id, string field, string newvalue);
    }
}
