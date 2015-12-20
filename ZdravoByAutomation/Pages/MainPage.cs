using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ZdravoByAutomation.Pages
{
    class MainPage
    {
        private IWebDriver driver;

        private const string BASE_URL = "http://www.zdravo.by/";

        [FindsBy(How = How.Id, Using = "LoginEmail")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "LoginPassword")]
        private IWebElement inputPassword;

        [FindsBy(How = How.Id, Using = "registerButton")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'testuser')]")]
        private IWebElement linkLoggedInUser;
        
        [FindsBy(How = How.Id, Using = "showRegisterBlock")]
        private IWebElement showLoginForm;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Настройки')]")] 
        private IWebElement linkSettings;

        [FindsBy(How = How.ClassName, Using = "value")]
        private IWebElement loggedInUser;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            //Console.WriteLine("Login Page opened");
        }
        public void Login(string username, string password)
        {
            showLoginForm.Click();
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();
        }

        public string GetLoggedInUserName()
        {
            linkLoggedInUser.Click();
            linkSettings.Click();
            return loggedInUser.Text;
        }
    }
}
