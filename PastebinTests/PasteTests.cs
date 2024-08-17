using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using PastebinTests.PageObjects;

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

            Assert.IsTrue(_driver.Url.Contains("paste.ee/p/"));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
