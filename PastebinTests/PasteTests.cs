using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using PastebinTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastebinTests.Tests
{
    [TestFixture]
    public class PasteTests
    {
        private IWebDriver _driver;
        private PastePage _pastePage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://paste.ee/");
            _pastePage = new PastePage(_driver);
        }

        [Test]
        public void CreateNewPaste()
        {
            _pastePage.SelectExpiration("1 hour"); 
            _pastePage.EnterDescription("Hello from WebDriver");            
            _pastePage.EnterTitle("helloweb");
            _pastePage.EnterContent("helloweb");
            _pastePage.ClickCreatePaste();

            // Validate successful creation if needed, e.g., check for specific URL or content
            Assert.IsTrue(_driver.Url.Contains("paste.ee/p/"));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
