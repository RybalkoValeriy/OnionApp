using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreEntities;
using Data;
using IRepositories;
using BusinessLogic;

namespace OnionApp.Controllers
{
    public class HomeController : Controller
    {
        ICarRepository repo;
        public HomeController(ICarRepository r)
        {
            repo = r;
        }

        public ActionResult Catalog()
        {
            if (Session["basket"] != null)
            {
                var value = Session["basket"] as List<Basket>;
            }

            var product = repo.GetAll().ToList();
            return View(product);
        }

        [HttpPost]
        public ActionResult Reserv([Bind(Include = "FirstName, LastName, Phone")]Buyer model)
        {
            if (!string.IsNullOrEmpty(model.FirstName) && !string.IsNullOrEmpty(model.LastName) && !string.IsNullOrEmpty(model.Phone)&& Session["basket"] is List<Basket>&& Session["basket"]!=null)
            {
                Buyer buyer = new Buyer()
                {
                    SessionID = Session.SessionID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone
                };

                var basket=Session["basket"] as List<Basket>;
                OrderCar order = new OrderCar();
                order.ToOrder(buyer, basket);

                Session["basket"] = null;
                return View("Ok");
            }
            return RedirectToAction("Catalog");
        }

        [HttpGet]
        public JsonResult BasketAdd(int id, int count)
        {
            var car = repo.GetOneCar(id);
            if (car != null)
            {
                Basket b = new Basket()
                {
                    guidSessinoID = Session.SessionID,
                    car = car,
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
            return Json(Session["basket"] as List<Basket>, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Remove(int id, int count)
        {
            if (Session["basket"] is List<Basket>)
            {
                var basketlist = Session["basket"] as List<Basket>;

                var remove = new Basket();
                foreach (var item in basketlist)
                {
                    if (item.Count == count && item.car.Id == id&&Session.SessionID==item.guidSessinoID)
                    {
                        remove = item;
                    }
                }
                basketlist.Remove(remove);
                Session["basket"] = basketlist;
            }

            return Json(Session["basket"] as List<Basket>, JsonRequestBehavior.AllowGet);
        }
    }
}