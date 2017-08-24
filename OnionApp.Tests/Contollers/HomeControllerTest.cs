using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionApp.Controllers;
using System.Web.Mvc;
using Moq;
using Data;
using CoreEntities;
using IRepositories;

namespace OnionApp.Tests.Contollers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IUofW> mock;
        private HomeController homecontroller;
        private ViewResult result;

        [TestInitialize]
        public void SetupContext()
        {
            // Arrage
            mock = new Mock<IUofW>();
            mock.Setup(val => val.repositoryCar.GetAll()).Returns(new List<Car>());
            homecontroller = new HomeController(mock.Object);
            
            // Act
            result = homecontroller.Catalog() as ViewResult;
        }

        // return view "Catalog"
        [TestMethod]
        public void Catalog_ViewEqualCatalogCshtml()
        {
            // Assert
            Assert.AreEqual("Catalog", result.ViewName);
        }

        // model is not null
        [TestMethod]
        public void Catalog_ViewModelNotNull()
        {
            // Assert
            Assert.IsNotNull(result.Model);
        }
    }
}
