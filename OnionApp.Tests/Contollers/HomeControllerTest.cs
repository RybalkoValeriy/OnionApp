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
        private HomeController homeController;

        IEnumerable<Car> dataCar = new List<Car>
        {
            new Car()
            {
                Id=1,
                Name="Audi",
                Price=1000,
                Description="descr",
                UrlImage=""
            }
        };

        [TestInitialize]
        public void SetupContext()
        {
            mock = new Mock<IUofW>();
            mock.Setup(x => x.RepositoryCar.GetAll())
                .Returns(dataCar);
            homeController = new HomeController(mock.Object);
        }

        [TestMethod]
        public void Catalog_ValidateModelAndView()
        {
            // Arrange

            // Act
            var resultView = homeController.Catalog() as ViewResult;

            // Assert
            Assert.AreEqual("Catalog", resultView.ViewName, " error view Catalog");
            Assert.AreEqual(dataCar, resultView.Model, "model fail");
            mock.VerifyAll();
        }
    }
}
