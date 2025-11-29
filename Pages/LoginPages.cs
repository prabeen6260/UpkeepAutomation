using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers; 

namespace TruSwap.Automation.Tests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            // Auth0 can be slow to load, so we set a specific explicit wait of 15 seconds
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        // 1. TruSwap Home Page Elements
        private By homeLoginBtn = By.XPath("//button[contains(text(), 'Sign In Securely')]"); // Update text to match your homepage button

        // 2. Auth0 Hosted Page Elements
        // Auth0 usually uses 'username' or 'email' for the name attribute
        private By auth0Email = By.CssSelector("input[name='username'], input[name='email']");
        private By auth0Password = By.CssSelector("input[name='password']");
        // The specific "Continue" or "Log In" button on Auth0
        private By auth0Submit = By.CssSelector("button[type='submit']");

        public void Login(string user, string pass)
        {
            // Step A: Click Login on TruSwap homepage
            _wait.Until(ExpectedConditions.ElementToBeClickable(homeLoginBtn)).Click();

            // Step B: Wait for Auth0 to load (Check if email input exists)
            // This is crucial because of the page redirect
            var emailInput = _wait.Until(ExpectedConditions.ElementIsVisible(auth0Email));

            // Step C: Interact with Auth0
            emailInput.Clear();
            emailInput.SendKeys(user);
            
            _driver.FindElement(auth0Password).SendKeys(pass);
            _driver.FindElement(auth0Submit).Click();
        }
    }
}