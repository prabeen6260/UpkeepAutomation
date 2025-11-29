using NUnit.Framework;
using TruSwap.Automation.Tests.Pages;
using TruSwap.Automation.Tests.Utilities;
using OpenQA.Selenium.Support.UI; // For WebDriverWait
using Microsoft.Extensions.Configuration;

namespace TruSwap.Automation.Tests.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        [Test]
        public void VerifyAuth0Login_RedirectsCorrectly()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            // 1. Arrange
            // IMPORTANT: Use a standard Email/Password user from your Auth0 Users dashboard.
            // Do NOT use "Sign in with Google" as Selenium often gets blocked by Google security.
            string testUser = config["Login:Email"]; 
            string testPass = config["Login:Password"]; 

            driver.Navigate().GoToUrl(config["url"]); // Your React App URL

            // 2. Act
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(testUser, testPass);

            // 3. Assert
            // We need to wait for Auth0 to redirect back to TruSwap
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            // Wait until the URL no longer contains "auth0.com" 
            wait.Until(d => !d.Url.Contains("auth0.com"));
            
            // Verify we are on the dashboard or home
            Assert.That(driver.Url.Contains("Upkeep") || driver.Url.Contains("home"), Is.True,
                $"Login failed. Current URL: {driver.Url}");
        }
    }
}