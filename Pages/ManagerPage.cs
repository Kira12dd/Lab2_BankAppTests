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
            Click(customersTabButton);
        }

        public void EnterSearchText(string text)
        {
            TypeText(searchInput, text);
        }

        public List<string> GetRows()
        {
            return Driver.FindElements(customerRows).Select(r => r.Text).ToList();
        }

        // true, якщо таблиця відфільтрувалась за 10 с
        public bool WaitUntilFilteredBy(string text)
        {
            try
            {
                Wait.Until(d =>
                {
                    var rows = d.FindElements(customerRows);
                    return rows.Count > 0 &&
                           rows.All(r => r.Text.Contains(text, StringComparison.OrdinalIgnoreCase));
                });
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        // true, якщо таблиця стала порожньою за 10 с
        public bool WaitUntilTableIsEmpty()
        {
            try
            {
                Wait.Until(d => d.FindElements(customerRows).Count == 0);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}