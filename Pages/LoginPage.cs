using OpenQA.Selenium;

namespace Lab2_BankAppTests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By managerLoginButton = By.XPath("//button[contains(text(), 'Bank Manager Login')]");

        public LoginPage(IWebDriver driver) : base(driver) { }

        private const string Url = "https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login";

        public void Open()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public void ClickBankManagerLogin()
        {
            WaitForClickable(managerLoginButton).Click();
        }
    }
}