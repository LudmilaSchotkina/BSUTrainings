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
        }

        
        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }
        
        [Test]
        public void OneCanLogin()
        {
            steps.LoginSystem(USERNAME, PASSWORD);
            logger.Info("Logged in successfully");
            Assert.True(steps.IsLoggedIn(USERNAME));

        }

        [Test]
        public void CreateExamination()
        {
            steps.LoginSystem(USERNAME, PASSWORD);
            logger.Info("Logged in successfully");

            Assert.True(steps.CreateExamination());
        }

        [Test]
        public void ChangeRegion()
        {
            steps.LoginSystem(USERNAME, PASSWORD);
            logger.Info("Logged in successfully");
            Assert.True(steps.ChangeUserRefion());
        }
        
        [Test]
        public void HideRegion()
        {
            steps.LoginSystem(USERNAME, PASSWORD);
            logger.Info("Logged in successfully");
            Thread.Sleep(5000);
            Assert.True(steps.HideUserRegion());
        }
    }
}
