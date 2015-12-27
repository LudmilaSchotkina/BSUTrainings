using System;
using System.Diagnostics;
using System.IO;
using NLog;
using NUnit.Framework;
using System.Threading;

namespace ZdravoByAutomation.SmokeTests
{
    [TestFixture]
    class SmokeTests
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private Steps.Steps steps = new Steps.Steps();
        private const string USERNAME = "lshchetkina1@gmail.com";
        private const string PASSWORD = "TestUser1_";

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
            logger.Info("Browser started");
        }

        
        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
            logger.Info("Browser closed");
        }
        
        [Test]
        public void OneCanLogin()
        {
            logger.Info("'OneCanLogin' test started");
            steps.LoginSystem(USERNAME, PASSWORD);
            Assert.True(steps.IsLoggedIn(USERNAME));
            logger.Info("'OneCanLogin' test completed successfully");
        }
    
        [Test]
        public void CreateExamination()
        {
            logger.Info("'CreateExamination' test started");
            steps.LoginSystem(USERNAME, PASSWORD);
            Thread.Sleep(5000);
            Assert.True(steps.CreateExamination());
            logger.Info("'OneCanLogin' test completed successfully");
        }
        
        [Test]
        public void ChangeRegion()
        {
            logger.Info("'ChangeRegion' test started");
            steps.LoginSystem(USERNAME, PASSWORD);
            Assert.True(steps.ChangeUserRegion());
            logger.Info("'OneCanLogin' test completed successfully");
        }
        
        
        [Test]
        public void CalculateBmi()
        {
            logger.Info("'CalculateBmi' test started");
            Assert.True(steps.CalculateBmi("70", "1.70"));
            Assert.False(steps.CalculateBmi("7000", "17000"));
            logger.Info("'CalculateBmi' test completed successfully");
        }
        
        
        [Test]
        public void HideRegion()
        {
            logger.Info("'HideRegion' test started");
            steps.LoginSystem(USERNAME, PASSWORD);
            Thread.Sleep(5000);
            Assert.True(steps.HideUserRegion());
            Assert.True(steps.ShowUserRegion());
            logger.Info("'HideRegion' test completed successfully");
        }
        
    }
}
