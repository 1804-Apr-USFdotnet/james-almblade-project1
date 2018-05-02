using Repository;
using System.IO;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using NLog;

namespace MyJsonSerializer
{
    public class Serializer : ISerializer
    {
        public Restaurant JsonToRestaurant(string filepath)
        {
            try
            {
                using (StreamReader file = File.OpenText(filepath))
                {
                    JsonSerializer ser = new JsonSerializer();
                    var restaurant = (Restaurant)ser.Deserialize(file, typeof(Restaurant));
                    return restaurant;
                }
            }
            catch (Exception e)
            {
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Debug(e, e.Message);
                throw;
            }
        }

        public Review JsonToReview(string filepath)
        {
            try
            {
                using (StreamReader file = File.OpenText(filepath))
                {
                    JsonSerializer ser = new JsonSerializer();
                    var review = (Review)ser.Deserialize(file, typeof(Review));
                    return review;
                }
            } catch (Exception e)
            {
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Debug(e, e.Message);
                throw;
            }
        }

        public void RestaurantToJson(Restaurant restaurant, string filepath)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, restaurant);
                }
            }
            catch (Exception e)
            {
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Debug(e, e.Message);
                throw;
            }
        }

        public void ReviewToJson(Review review, string filepath)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, review);
                }
            }
            catch (Exception e)
            {
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Debug(e, e.Message);
                throw;
            }
        }
    }
}
