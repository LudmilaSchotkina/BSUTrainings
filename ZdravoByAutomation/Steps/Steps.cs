using System;
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

        public bool CreateExamination()
        {
            Pages.ExaminationPage examinationPage = new Pages.ExaminationPage(driver);
            examinationPage.OpenPage();
            System.Threading.Thread.Sleep(3000);
            string surveyId = examinationPage.CreateExamination();

            logger.Info("Examination id is" + surveyId);

            if (examinationPage.isExists(surveyId))
            {
                //examinationPage.RemoveExamination();
                return true;
            }
            return false;
        }
        
        public bool ChangeUserRefion()
        {
            Pages.UserProfilePage userProfile = new Pages.UserProfilePage(driver);
            userProfile.ChangeRegion();
            return userProfile.isCorrectRegion();
        }

        public bool HideUserRegion()
        {
            Pages.UserProfilePage userProfile = new Pages.UserProfilePage(driver);
            userProfile.HideRegion();
            return userProfile.IsRegionHidden();
        }
    }
}
