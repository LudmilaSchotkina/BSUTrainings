using System;
using OpenQA.Selenium;

namespace ZdravoByAutomation.Steps
{
    class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = WebDriver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            WebDriver.DriverInstance.CloseBrowser();
        }
        
        public void LoginSystem(string username, string password)
        {
            Pages.MainPage loginPage = new Pages.MainPage(driver);
            loginPage.OpenPage();
            loginPage.Login(username, password);
           // Console.WriteLine("Logged in");
        }

        public bool IsLoggedIn(string username)
        {
            Pages.MainPage loginPage = new Pages.MainPage(driver);
            string test = loginPage.GetLoggedInUserName().Trim().ToLower();
            Console.WriteLine(test);
            Console.WriteLine(username);
            Console.WriteLine(test.Equals(username));
            return test.Equals(username);
        }
        /*
        public bool CreateNewRepository(string repositoryName, string repositoryDescription)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ClickOnCreateNewRepositoryButton();
            Pages.CreateNewRepositoryPage createNewRepositoryPage = new Pages.CreateNewRepositoryPage(driver);
            string expectedRepoName = createNewRepositoryPage.CreateNewRepository(repositoryName, repositoryDescription);

            return expectedRepoName.Equals(createNewRepositoryPage.GetCurrentRepositoryName());
        }

        public bool CurrentRepositoryIsEmpty()
        {
            Pages.CreateNewRepositoryPage createNewRepositoryPage = new Pages.CreateNewRepositoryPage(driver);
            return createNewRepositoryPage.IsCurrentRepositoryEmpty();
        }
        */
    }
}
