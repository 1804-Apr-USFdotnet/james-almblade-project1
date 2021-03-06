﻿using System.Collections.Generic;
using System.Web.Mvc;
using SearchFunction;
using RestaurantAndReviewFunctions;
using RRRaves.Web.Models;

namespace RRRaves.Web.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string SearchRest)
        {
            SearchRestaurants sr = new SearchRestaurants();

            var temp = sr.FindRestaurants(SearchRest);
            var WebRestList = new List<WebRestaurant>();
            DisplayAll da = new DisplayAll();
            temp = da.RestaurantsByName(temp);
            foreach (var item in temp)
            {
                WebRestList.Add(WebDataConversion.RestaurantToWeb(item));
            }
            if (WebRestList != null)
            {
                return View(WebRestList);
            }
            else { return new HttpNotFoundResult();  }
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var Model = new RestaurantAndReviews(id.Value);
                    if (Model.WebRest == null)
                    {
                        return new HttpNotFoundResult();
                    }
                    else
                    {
                        return View(Model);
                    }
                }
                else
                {
                    return new EmptyResult();
                }
            }
            catch
            {
                return new HttpNotFoundResult();
            }

        }

        public ActionResult DisplayAllName()
        {
            DisplayAll da = new DisplayAll();
            var temp = da.RestaurantsByName();
            List<WebRestaurant> listWR = new List<WebRestaurant>();
            foreach (var item in temp)
            {
                listWR.Add(WebDataConversion.RestaurantToWeb(item));
            }
            return View(listWR);
        }

        public ActionResult DisplayAllRating()
        {
            DisplayAll da = new DisplayAll();
            var temp = da.RestaurantsByRating();
            List<WebRestaurant> listWR = new List<WebRestaurant>();
            foreach (var item in temp)
            {
                listWR.Add(WebDataConversion.RestaurantToWeb(item));
            }
            return View(listWR);
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(WebRestaurant webRestaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var temp = WebDataConversion.WebRestaurantToData(webRestaurant);
                    var rf = new RestaurantFunctions();
                    rf.AddRestaurant(temp);
                    return RedirectToAction("Index", "Restaurant", null);
                }
                else
                {
                    return View("Create");
                }
            }
            catch
            {
                return new EmptyResult();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {

                if (id.HasValue)
                {
                    SearchRestaurants sr = new SearchRestaurants();
                    var rest = sr.GetRestaurant(id.Value);
                    var WebRest = WebDataConversion.RestaurantToWeb(rest);
                    return View("Edit", WebRest);
                }
                else
                {
                    return new EmptyResult();
                }
            }
            catch
            {
                return new HttpNotFoundResult();
            }
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult EditR(WebRestaurant wr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var temp = WebDataConversion.WebRestaurantToData(wr);
                    RestaurantFunctions rf = new RestaurantFunctions();
                    rf.UpdateRestaurant(wr.RestaurantID, temp);

                    return RedirectToAction("Details", "Restaurant", new { @id = wr.RestaurantID });
                }
                else
                {
                    return View("Edit");
                }
            }
            catch
            {
                return new EmptyResult();
            }
        }

        public ActionResult DeleteReviewsFirst()
        {
            return View();
        }


        // GET: Restaurant/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    RetrieveReviews rr = new RetrieveReviews();
                    var revList = rr.RetrieveReviewList(id.Value);
                    if (revList.Count > 0)
                    {
                        return RedirectToAction("DeleteReviewsFirst", "Restaurant", null);
                    }
                    SearchRestaurants sr = new SearchRestaurants();
                    var temp = sr.GetRestaurant(id.Value);

                    return View(WebDataConversion.RestaurantToWeb(temp));
                }
                else
                {
                    return new EmptyResult();
                }
            }
            catch
            {
                return new EmptyResult();
            }
        }

        // Does not delete unless all reviews are gone.
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {

                    RestaurantFunctions rf = new RestaurantFunctions();

                    rf.RemoveRestaurant(id);
                    return RedirectToAction("Index", "Restaurant", null);

            }
            catch
            {
                return new EmptyResult();
            }
        }
    }
}
