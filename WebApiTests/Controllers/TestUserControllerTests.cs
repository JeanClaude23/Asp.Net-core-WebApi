using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Tests
{
    [TestClass()]
    public class TestUserControllerTests
    {
        static MS_LearningsContext context = new MS_LearningsContext();
        TestUserController controller = new TestUserController(context);

        [TestMethod()]
        public async Task GetbyIdTestAsync()
        {
            var actionResult = await controller.GetUserbyId(4);
            Assert.AreEqual(actionResult.Value.Username, "jean");
        }

        [TestMethod]
        public async Task GetCookieTest()
        {
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            var newCookies = new[] { "AccountID=123" };
            controller.ControllerContext.HttpContext.Request.Headers["Cookie"] = newCookies;
            Assert.AreEqual(controller.GetCookie(), "123");
        }

        [TestMethod()]
        public async Task SetCookieAsyncTest()
        {
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            var result = await controller.SetCookieAsync("Roger");
            Assert.AreEqual(controller.GetCookie(), "1");
        }

        [TestMethod()]
        public void DeleteCookieTest()
        {
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            var newCookies = new[] { "AccountID=123" };
            controller.ControllerContext.HttpContext.Request.Headers["Cookie"] = newCookies;
            controller.DeleteCookie();
            Assert.AreEqual(controller.GetCookie(), null);
        }
        //[TestMethod()]
        //public async Task GetAllUsersTest()
        //{
        //    var actionResult = await controller.GetUsers();
        //    //Assert.AreEqual(actionResult);
        //}
    }
}