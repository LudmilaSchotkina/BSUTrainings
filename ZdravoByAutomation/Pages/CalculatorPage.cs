using System;
using System.Threading;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ZdravoByAutomation.Pages
{
    class CalculatorPage
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private IWebDriver driver;

        private const string BASE_URL = "https://zdravo.by/tools/calculators";

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'ИНСТРУМЕНТЫ')]")]
        private IWebElement toolsLink;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Калькуляторы')]")]
        private IWebElement calculatorLink;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Индекс массы тела')]")]
        private IWebElement bmiLink;
    
        [FindsBy(How = How.Id, Using = "0")]
        private IWebElement heightInput;

        [FindsBy(How = How.Id, Using = "1")]
        private IWebElement weightInput;

        [FindsBy(How = How.Id, Using = "calculate")]
        private IWebElement submitButton;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Заключение')]")]
        private IWebElement resultMessage;
        

        public CalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            logger.Info("Opened page: " + BASE_URL);
        }

        public bool CalculateBmi(string height, string weight)
        {
            OpenPage();
            bmiLink.Click();
            heightInput.SendKeys(height);
            weightInput.SendKeys(weight);
            submitButton.Click();
            logger.Info("BMI was calculated successfully");

            try
            {
                if (resultMessage.Displayed)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
