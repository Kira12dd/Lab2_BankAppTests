using System.Linq;
using Lab2_BankAppTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Lab2_BankAppTests.StepDefinitions
{
    [Binding]
    public class CustomerSearchSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ManagerPage _managerPage;

        public CustomerSearchSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["WebDriver"];
            _loginPage = new LoginPage(_driver);
            _managerPage = new ManagerPage(_driver);
        }

        [Given(@"I open the banking application")]
        public void GivenIOpenTheBankingApplication()
        {
            _loginPage.Open("https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login");
        }

        [When(@"I log in as a Bank Manager")]
        public void WhenILogInAsABankManager()
        {
            _loginPage.ClickBankManagerLogin();
        }

        [When(@"I navigate to the Customers tab")]
        public void WhenINavigateToTheCustomersTab()
        {
            _managerPage.OpenCustomersTab();
        }

        [When(@"I search for customer ""(.*)""")]
        public void WhenISearchForCustomer(string customerName)
        {
            _managerPage.EnterSearchText(customerName);
        }

        [Then(@"the customer list should display ""(.*)"" in the search results")]
        public void ThenTheCustomerListShouldDisplayInTheSearchResults(string expectedName)
        {
            var rows = _managerPage.GetRowsAfterSearch(expectedName);

            Assert.That(rows, Is.Not.Empty, "Таблиця результатів порожня!");
            Assert.That(rows.All(r => r.IndexOf(expectedName, System.StringComparison.OrdinalIgnoreCase) >= 0), Is.True,
                $"Не всі записи відповідають пошуку '{expectedName}'.");
        }
    }
}