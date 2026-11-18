using Lab2_BankAppTests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace Lab2_BankAppTests.StepDefinitions
{
    [Binding]
    public class CustomerSearchSteps
    {
        private readonly LoginPage _loginPage;
        private readonly ManagerPage _managerPage;

        public CustomerSearchSteps(ScenarioContext scenarioContext)
        {
            var driver = (IWebDriver)scenarioContext["WebDriver"];
            _loginPage = new LoginPage(driver);
            _managerPage = new ManagerPage(driver);
        }

        [Given(@"I open the banking application")]
        public void GivenIOpenTheBankingApplication()
        {
            _loginPage.Open();
        }

        [Given(@"I log in as a Bank Manager")]
        public void GivenILogInAsABankManager()
        {
            _loginPage.ClickBankManagerLogin();
        }

        [Given(@"I navigate to the Customers tab")]
        public void GivenINavigateToTheCustomersTab()
        {
            _managerPage.OpenCustomersTab();
        }

        [When(@"I search for customer ""([^""]*)""")]
        public void WhenISearchForCustomer(string customerName)
        {
            _managerPage.EnterSearchText(customerName);
        }

        [Then(@"only customers matching ""([^""]*)"" should be displayed")]
        public void ThenOnlyMatchingCustomersShouldBeDisplayed(string expectedName)
        {
            var isFiltered = _managerPage.WaitUntilFilteredBy(expectedName);
            var rows = _managerPage.GetRows();

            Assert.That(isFiltered, Is.True,
                $"Таблиця не відфільтрувалась за '{expectedName}'. Рядки: {string.Join(" | ", rows)}");
        }

        [Then(@"no customers should be displayed")]
        public void ThenNoCustomersShouldBeDisplayed()
        {
            Assert.That(_managerPage.WaitUntilTableIsEmpty(), Is.True,
                "Таблиця не порожня після пошуку неіснуючого клієнта.");
        }
    }
}