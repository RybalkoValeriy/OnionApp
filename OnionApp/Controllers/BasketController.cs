using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreEntities;
using Data;
using BusinessLogic;
using IRepositories;

namespace OnionApp.Controllers
{
    public class BasketController : Controller
    {
        IUofW unitOfWork;
        public BasketController(IUofW r)
        {
            unitOfWork = r;

        }

        [HttpPost]
        public ActionResult ReserveOrder([Bind(Include = "FirstName, LastName, Phone")]Buyer model)
        {

            if (string.IsNullOrEmpty(model.FirstName))
            {
                ModelState.AddModelError("", "Enter your name");
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                ModelState.AddModelError("", "Enter your last name");
            }
            if (string.IsNullOrEmpty(model.Phone))
            {
                ModelState.AddModelError("", "Enter your phone");
            }
            //if (Session["basket"] == null)
            //{
            //    ModelState.AddModelError("", "Choose a product");
            //}
            //if (Session["basket"] is List<Basket>)
            //{
            //    ModelState.AddModelError("", "Unknown error, try again.");
            //}
            if (ModelState.IsValid)
            {
                Buyer buyer = new Buyer()
                {
                    SessionId = Session.SessionID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone
                };

                var basket = Session["basket"] as List<Basket>;
                OrderCar order = new OrderCar();
                order.ToOrder(buyer, basket, unitOfWork);

                Session["basket"] = null;
                return View("OrderIsAccepted");
            }
            return View("~/Views/Home/Catalog.cshtml",unitOfWork.repositoryCar.GetAll());
        }

        [HttpPost]
        public JsonResult Add(int id, int count)
        {
            var car = unitOfWork.repositoryCar.FindOne(id);
            if (car != null)
            {
                Basket b = new Basket()
                {
                    SessionID = Session.SessionID,
                    Car = car,
                    Count = count
                };
                if (b != null)
                {
                    List<Basket> list = new List<Basket>();
                    list.Add(b);
                    if (Session["basket"] != null && Session["basket"] is List<Basket>)
                    {
                        var oldlist = Session["basket"] as List<Basket>;
                        var newlist = oldlist.Concat(list).ToList();
                        Session["basket"] = newlist;
                    }
                    else
                    {
                        Session["basket"] = list;
                    }
                }
            }
            return Json((Session["basket"] as List<Basket>));
        }

        [HttpPost]
        public JsonResult Remove(int id, int count)
        {
            if (Session["basket"] is List<Basket>)
            {
                var basketlist = Session["basket"] as List<Basket>;

                var remove = new Basket();
                foreach (var item in basketlist)
                {
                    if (item.Count == count && item.Car.Id == id && Session.SessionID == item.SessionID)
                    {
                        remove = item;
                    }
                }
                basketlist.Remove(remove);
                Session["basket"] = basketlist;
            }

            return Json(Session["basket"] as List<Basket>);
        }
    }
}