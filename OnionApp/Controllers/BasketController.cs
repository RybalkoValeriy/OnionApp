using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CoreEntities;
using BusinessLogic;
using IRepositories;
using OnionApp.Models;
using BusinessInterfaces;

namespace OnionApp.Controllers
{
    public class BasketController : Controller
    {
        IUofW unitOfWork;
        IOrderProducts orderProducts;
        public BasketController(IUofW r)
        {
            unitOfWork = r;
            this.orderProducts = new OrderCar();
        }

        [ValidateAntiForgeryToken]
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

            if (ModelState.IsValid && Session["basket"] is List<Basket>)
            {
                Buyer buyer = new Buyer()
                {
                    SessionId = Session.SessionID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone
                };
                var basket = Session["basket"] as List<Basket>;

                try
                {
                    orderProducts.ToOrder(buyer, basket, unitOfWork);
                }
                catch (Exception ex)
                {
                    return View("~/Views/Exeption/Error.cshtml", new HandleErrorInfo(ex, "Home", "Catalog"));
                }

                return RedirectToAction("OrderIsAccepted", "Basket", new { session = Session.SessionID, trans = buyer.Transaction.FirstOrDefault().Id });
            }

            ModelState.AddModelError("", "Apparently, something went wrong");
            var modelCar = unitOfWork.RepositoryCar.GetAll();
            return View("~/Views/Home/Catalog.cshtml", modelCar);
        }

        public ActionResult OrderIsAccepted(string session, Guid trans)
        {
            if (session == Session.SessionID && trans != null)
            {
                var orderCar = new List<OrderedCarView>();
                var buyerLast = unitOfWork.RepositoryBuyer.GetAll().Where(x => x.SessionId == session && x.Transaction == x.Transaction.FirstOrDefault(t => t.Id == trans)).FirstOrDefault();
                foreach (var item in buyerLast.Transaction)
                {
                    orderCar.Add
                        (
                            new OrderedCarView()
                            {
                                Car = item.Car,
                                Count = item.Count
                            }
                        );
                }
                TransactionResultView modelTransactions = new TransactionResultView
                {
                    FullName = buyerLast.FirstName + ' ' + buyerLast.LastName,
                    Phone = buyerLast.Phone,
                    Date = buyerLast.Transaction.FirstOrDefault().DateTransaction,
                    OrderedCars = orderCar
                };
                Session.Abandon();
                return View("OrderIsAccepted", modelTransactions);
            }
            ModelState.AddModelError("", "Apparently, something went wrong");
            var modelCar = unitOfWork.RepositoryCar.GetAll();
            return View("~/Views/Home/Catalog.cshtml", modelCar);
        }

        [HttpPost]
        public JsonResult Add(int id, int count)
        {
            var car = unitOfWork.RepositoryCar.FindOne(id);
            if (car != null && count > 0)
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