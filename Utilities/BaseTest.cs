using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TruSwap.Automation.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Initialize Chrome Driver
            driver = new ChromeDriver();
            
            // maximize window
            driver.Manage().Window.Maximize();
            
            // Add implicit wait (helps with React loading times)
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void Teardown()
        {
            // Close the browser after each test
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}