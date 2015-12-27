using System;
using System.Threading;
using NLog;
using OpenQA.Selenium;

namespace ZdravoByAutomation.Steps
{
    class Steps
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

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
            logger.Info("Page loaded");
            loginPage.Login(username, password);
            logger.Info("Logged in successfully");
        }

        public bool IsLoggedIn(string username)
        {
            Pages.MainPage loginPage = new Pages.MainPage(driver);
            string test = loginPage.GetLoggedInUserName().Trim().ToLower();
            logger.Info("Is logged in successfully: " + test.Equals(username));
            return test.Equals(username);
        }

        public bool CreateExamination()
        {
            Pages.ExaminationPage examinationPage = new Pages.ExaminationPage(driver);
            examinationPage.OpenPage();
            logger.Info("Page loaded");
            Thread.Sleep(3000);
            string surveyId = examinationPage.CreateExamination();
            logger.Info("Examination Id is " + surveyId);

            if (examinationPage.isExists(surveyId))
                return true;
            return false;
        }
        
        public bool ChangeUserRegion()
        {
            Pages.UserProfilePage userProfile = new Pages.UserProfilePage(driver);
            userProfile.ChangeRegion();
            logger.Info("Region was changed");
            return userProfile.IsCorrectRegion();
        }

        public bool HideUserRegion()
        {
            Pages.UserProfilePage userProfile = new Pages.UserProfilePage(driver);
            userProfile.HideRegion();
            logger.Info("Region was hidden");
            return userProfile.IsRegionHidden();
        }

        public bool ShowUserRegion()
        {
            Pages.UserProfilePage userProfile = new Pages.UserProfilePage(driver);
            userProfile.ShowRegion();
            logger.Info("Region was shown");
            return !userProfile.IsRegionHidden();
        }

        public bool CalculateBmi(string height, string weight)
        {
            Pages.CalculatorPage bmiPage = new Pages.CalculatorPage(driver);
            return bmiPage.CalculateBmi(height, weight);
        }
    }
}
