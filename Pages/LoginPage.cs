using OpenQA.Selenium;

namespace Lab2_BankAppTests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By managerLoginButton = By.XPath("//button[contains(text(), 'Bank Manager Login')]");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void Open(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void ClickBankManagerLogin()
        {
            WaitForClickable(managerLoginButton).Click();
        }
    }
}