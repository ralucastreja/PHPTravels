using OpenQA.Selenium;

namespace PHPTravels.Pages
{
    public class Homepage : BasePage
    {
        public Homepage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement PageTitle => driver.FindElement(By.XPath("/html/head/title"));

        public string GetPageTitle()
        {
            return driver.Title;
        }
    }
}
