using System;
using System.Threading;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ZdravoByAutomation.Pages
{
    class ExaminationPage
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private IWebDriver driver;
        
        private const string USERNAME = "testuser";

        private const string BASE_URL = "http://www.zdravo.by/";

        private const string EXAMINATION_URL = "http://www.zdravo.by/examination";

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Самостоятельный выбор')]")]
        private IWebElement planType;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Офтальмолог')]")]
        private IWebElement examinationType;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Выбрать медцентры')]")]
        private IWebElement chooseButton;
    
        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Создать направление')]")]
        private IWebElement createExaminationButton;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Получить направление')]")]
        private IWebElement getExaminationButton;

        [FindsBy(How = How.Id, Using = "Fio")]
        private IWebElement inputName;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Завершить')]")]
        private IWebElement submitButton;

        [FindsBy(How = How.LinkText, Using = "//*[contains(text(), 'Удалить направление')]")]
        private IWebElement deleteExaminationButton;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Удалить')]")]
        private IWebElement deleteButton;
        
        [FindsBy(How = How.ClassName, Using = "rf-number")]
        private IWebElement surveyElement;

        public ExaminationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(EXAMINATION_URL);
            logger.Info("Opened page: " + EXAMINATION_URL);
        }

        public string CreateExamination()
        {
            planType.Click();
            examinationType.Click();
            chooseButton.Click();
            Thread.Sleep(3000);
            examinationType.Click();
            createExaminationButton.Click();
            logger.Info("Examination was created successfully");
            Thread.Sleep(3000);
            getExaminationButton.Click();
            inputName.SendKeys(USERNAME);
            Thread.Sleep(3000);
            submitButton.Click();

            return surveyElement.Text; 
        }

        public bool isExists(string surveyId)
        {
            driver.Navigate().GoToUrl(BASE_URL);
            var id = surveyId.Split()[2];
            Thread.Sleep(3000);
            if (driver.PageSource.Contains(id))
                return true;
            return false;
        }

        public void RemoveExamination()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            deleteExaminationButton.Click();
            deleteButton.Click();
        }
    }
}
