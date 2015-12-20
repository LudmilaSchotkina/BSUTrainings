using System;
using System.Diagnostics;
using System.IO;
using NLog;
using NUnit.Framework;

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
            //Console.WriteLine("Time {0}", DateTime.Now);
            logger.Info("Logged in successfully");
            Assert.True(true);
            System.Threading.Thread.Sleep(1000);
            Assert.True(steps.IsLoggedIn(USERNAME));

        }
        /*
        [Test]
        public void OneCanCreateProject()
        {
            steps.LoginGithub(USERNAME, PASSWORD);
            Assert.IsTrue(steps.CreateNewRepository("testRepo", "auto-generated test repo"));
            Assert.IsTrue(steps.CurrentRepositoryIsEmpty());
        }
         */
    }
}
