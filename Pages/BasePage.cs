using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab2_BankAppTests.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
        }

        protected IWebElement WaitForElement(By locator)
        {
            return Wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return (element.Displayed) ? element : null;
            });
        }

        protected IWebElement WaitForClickable(By locator)
        {
            return Wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return (element.Displayed && element.Enabled) ? element : null;
            });
        }
    }
}