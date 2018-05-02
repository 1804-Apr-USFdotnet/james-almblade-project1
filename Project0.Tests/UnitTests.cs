using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using AutoFixture.AutoMoq;
using AutoFixture;
using System.Data.Entity;
using Moq;
using Repository;

namespace Project0.Tests
{
    public class UnitTests
    {
        [Fact]
        public void RepoAdd_AddRestaurant_CheckAdded()
        {
            //Arrange
            var dbmock = new RRRavesDBEntities();


            var restrepo = new RestaurantRepository(dbmock);


            Restaurant restaurantEx = new Restaurant();
            restaurantEx.ID_Restaurant = 12;


            //Act
            restrepo.Add(restaurantEx);
            var actual = restrepo.Get(restaurantEx.ID_Restaurant);

            //Assert
            Assert.Equal(restaurantEx, actual);
        }

        [Fact]
        public void RepoAdd_AddReview_CheckAdded()
        {
            //Arrange
            var dbmock = new RRRavesDBEntities();


            var revrepo = new ReviewRepository(dbmock);


            Review reviewEx = new Review();
            reviewEx.ID_Review = 12;
            reviewEx.Rating = 0;
            reviewEx.Restaurant = 1;


            //Act
            revrepo.Add(reviewEx);
            var actual = revrepo.Get(reviewEx.ID_Review);

            //Assert
            Assert.Equal(reviewEx, actual);
        }
    }
}
