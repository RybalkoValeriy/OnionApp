using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionApp.Controllers;
using System.Web.Mvc;
using Moq;
using Data;
using System.Collections.Generic;
using CoreEntities;
using IRepositories;
using BusinessLogic;

namespace OnionApp.Tests.Contollers
{
    [TestClass]
    public class BasketControllerTest
    {
        private Mock<IUofW> mock;
        private BasketController basketController;
         
        [TestInitialize]
        public void SetupContext()
        {
            mock = new Mock<IUofW>();
            basketController = new BasketController(mock.Object);
        }

        [TestMethod]
        public void Basket_ViewEqualsModelValid()
        {
            // Arrange 
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(s => s["basket"]).Returns(new List<Basket>() { new Basket() {Car=new Car() { },Count=1,SessionID="1" } });
            // Act
            ViewResult viewResult2 = basketController.ReserveOrder(buyer) as ViewResult;
            // Assert

            Assert.IsNotNull(viewResult2);
           // Assert.AreEqual(expectViewName, viewResult2.ViewName);
            
        }

        // 
        //[TestMethod]
        //public void Basket_ReserveOrderEqualOrederIsAccepted()
        //{

        //}
    }
}
