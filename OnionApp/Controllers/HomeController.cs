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
        IUofW unitOfWork;
        public HomeController(IUofW r)
        {
            unitOfWork = r;
        }

        public ActionResult Catalog()
        {
            var product = unitOfWork.RepositoryCar.GetAll();
            return View("Catalog",product);
        }

    }
}