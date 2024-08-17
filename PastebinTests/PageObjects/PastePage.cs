using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PastebinTests.PageObjects
{
    public class PastePage
    {
        private readonly WebDriverWait _wait;

        public PastePage(IWebDriver driver)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
        }

        private IWebElement ExpirationDropdown => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("select#expiration")));
        private IWebElement DescriptionField => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("description")));
        private IWebElement TitleField => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("paste[section1][name]")));
        private IWebElement ContentField => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("paste[section1][contents]")));

        private IWebElement CreatePasteButton => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@type='submit']")));

        public void SelectExpiration(string expiration)
        {
            var selectElement = new SelectElement(ExpirationDropdown);
            selectElement.SelectByText(expiration);
        }

        public void EnterDescription(string description)
        {
            DescriptionField.SendKeys(description);
        }               

        public void EnterTitle(string title)
        {
            TitleField.SendKeys(title);
        }

        public void EnterContent(string content)
        {
            ContentField.SendKeys(content);
        }

        public void ClickCreatePaste()
        {
            CreatePasteButton.Click();
        }
    }
}
