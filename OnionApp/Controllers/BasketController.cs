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
            return RedirectToAction("Catalog", "Home");
        }

        [HttpPost]
        public JsonResult Add(int id, int count)
        {
            var car = unitOfWork.RepositoryCar.FindOne(id);
            if (car != null)
            {
                Basket basket = new Basket()
                {
                    SessionID = Session.SessionID,
                    Car = car,
                    Count = count
                };
                if (basket != null)
                {
                    List<Basket> list = new List<Basket>
                    {
                        basket
                    };
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