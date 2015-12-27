using System;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace ZdravoByAutomation.Pages
{
    class UserProfilePage
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private IWebDriver driver;

        private const string BASE_URL = "https://zdravo.by/users/26608/testuser";

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'testuser')]")]
        private IWebElement linkLoggedInUser;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'редактировать')]")]
        private IWebElement editLink;
        
        private const string USER_COUNTRY_ID = "User_Country";
    
        private const string USER_REGION_ID = "User_Region";

        private const string USER_COUNTRY = "Республика Беларусь";

        private const string USER_REGION = "Гродно";

        [FindsBy(How = How.Id, Using = USER_COUNTRY_ID)]
        private IWebElement country;

        [FindsBy(How = How.Id, Using = USER_REGION_ID)]
        private IWebElement region;

        [FindsBy(How = How.Name, Using = "EditUser")]
        private IWebElement submitButton;

        [FindsBy(How = How.Id, Using = "UserSettings_HideRegion")]
        private IWebElement regionCheckbox;

        public UserProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            logger.Info("Opened page: " + BASE_URL);
        }

        private void clickOptionInList(string listControlId, string optionText)
        {
            driver.FindElement(By.XPath("//select[@id='" + listControlId + "']/option[contains(.,'" + optionText + "')]")).Click();
        }

        public void ChangeRegion()
        {
            linkLoggedInUser.Click();
            editLink.Click();
            country.Click();
            clickOptionInList(USER_COUNTRY_ID, USER_COUNTRY);
            region.Click();
            clickOptionInList(USER_REGION_ID, USER_REGION);
            submitButton.Click();
            logger.Info("Region was changed");
        }

        public bool IsCorrectRegion()
        {
            var regionLabel = driver.FindElement(By.XPath("//*[contains(text(), 'Гродно')]"));
            if (USER_REGION.Equals(regionLabel.Text))
            {
                logger.Info("Success. Regions are correspond");
                return true;
            }
            return false;
        }

        public void HideRegion()
        {
            OpenPage();
            Thread.Sleep(5000);
            editLink.Click();
            if (!regionCheckbox.Selected)
            {
                regionCheckbox.Click();
                submitButton.Click();
                logger.Info("Region is hidden");
            }
            
        }

        public void ShowRegion()
        {
            OpenPage();
            Thread.Sleep(5000);
            editLink.Click();
            if (regionCheckbox.Selected)
            {
                regionCheckbox.Click();
                submitButton.Click();
                logger.Info("Region is shown");
            }

        }

        public bool IsRegionHidden()
        {
            Thread.Sleep(5000);
            OpenPage();
            if (driver.PageSource.Contains(USER_REGION))
            {
                return false;
            }
            logger.Info("Region is hidden");

            return true;
        }
    }
}
