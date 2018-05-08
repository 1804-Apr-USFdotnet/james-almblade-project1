using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantAndReviewFunctions;
using SearchFunction;
using RRRaves.Web.Models;

namespace RRRaves.Web.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            return new EmptyResult();
        }


        // GET: Review/Create
        public ActionResult Create(int? id)
        {
            if (id.HasValue)
            {
                WebReview temp = new WebReview();
                temp.Restaurant = id.Value;
                return View("Create", temp);
            }
            else { return new EmptyResult(); }
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(WebReview WebRv)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var rf = new ReviewFunctions();
                    rf.AddReview(WebDataConversion.WebReviewToData(WebRv));
                    var temp = WebRv.Restaurant;
                    return RedirectToAction("Details", "Restaurant", new { @id = WebRv.Restaurant });
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return new EmptyResult();
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                RetrieveReviews rr = new RetrieveReviews();
                var rev = rr.GetReview(id.Value);
                var WebRev = WebDataConversion.ReviewToWeb(rev);
                return View("Edit", WebRev);
            }
            else
            {
                return new EmptyResult();
            }
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult EditR(WebReview webr)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var temp = WebDataConversion.WebReviewToData(webr);
                    ReviewFunctions rf = new ReviewFunctions();
                    rf.UpdateReview(webr.ReviewID, temp);
                    var temp2 = webr.Restaurant;
                    return RedirectToAction("Details", "Restaurant", new { @id = webr.Restaurant });
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


        // GET: Review/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {

                RetrieveReviews rr = new RetrieveReviews();
                var temp = rr.GetReview(id.Value);

                return View(WebDataConversion.ReviewToWeb(temp));
            }
            else
            {
                return new EmptyResult();
            }
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {

                ReviewFunctions rf = new ReviewFunctions();
                RetrieveReviews rr = new RetrieveReviews();
                var temp = rr.GetReview(id).Restaurant;


                rf.RemoveReview(id);
                return RedirectToAction("Details", "Restaurant", new { @id = temp.Value});

            }
            catch
            {
                return new EmptyResult();
            }
        }
    }
}
