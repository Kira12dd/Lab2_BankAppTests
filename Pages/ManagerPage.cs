using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Lab2_BankAppTests.Pages
{
    public class ManagerPage : BasePage
    {
        private readonly By customersTabButton = By.XPath("//button[contains(text(), 'Customers')]");
        private readonly By searchInput = By.XPath("//input[@placeholder='Search Customer']");
        private readonly By customerRows = By.XPath("//table/tbody/tr");

        public ManagerPage(IWebDriver driver) : base(driver) { }

        public void OpenCustomersTab()
        {
            WaitForClickable(customersTabButton).Click();
        }

        public void EnterSearchText(string text)
        {
            var input = WaitForElement(searchInput);
            input.Clear();
            input.SendKeys(text);
        }

        public List<string> GetFirstNamesInTable()
        {
            var rows = Driver.FindElements(customerRows);
            return rows.Select(r => r.FindElements(By.TagName("td"))[0].Text).ToList();
        }
    }
}