using OpenQA.Selenium;
using PHPTravels.Helpers;

namespace PHPTravels.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            Reporter reporter = new Reporter();
        }

        public string GetUrl()
        {
            return this.driver.Url;
        }
    }
}
