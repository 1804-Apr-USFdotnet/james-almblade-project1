using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using System.Linq.Expressions;

namespace SearchFunction
{
    public interface ISearchRestaurants
    {
        List<Restaurant> FindRestaurants(string s);

        List<Restaurant> GetTopRestaurants();
    }
}
