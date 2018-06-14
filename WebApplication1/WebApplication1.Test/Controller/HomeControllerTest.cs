using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Test.Controller
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("歡迎使用", viewData["Message"]);
        }

        [TestMethod]
        public void About()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.About() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(String.Empty, result.ViewName);
        }
    }
}
