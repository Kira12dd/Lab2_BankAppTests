using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Lab2_BankAppTests.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            IWebDriver driver = new ChromeDriver(options);
            _scenarioContext["WebDriver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TryGetValue("WebDriver", out IWebDriver driver))
            {
                driver.Quit();
            }
        }
    }
}