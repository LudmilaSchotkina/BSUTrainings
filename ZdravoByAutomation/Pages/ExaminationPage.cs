using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ZdravoByAutomation.Pages
{
    class ExaminationPage
    {
        private IWebDriver driver;

        private const string BASE_URL = "http://www.zdravo.by/examination";
        
        public ExaminationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }
    }
}
