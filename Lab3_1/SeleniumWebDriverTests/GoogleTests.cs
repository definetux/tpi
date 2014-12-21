using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriverTests
{
    [TestFixture]
    public class GoogleTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void TestGoogle()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");
            IWebElement query = _driver.FindElement(By.Name("q"));
            query.SendKeys("unit testing");
            query.Submit();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));

            IWebElement link = _driver.FindElement(By.LinkText("Unit testing - Wikipedia, the free encyclopedia"));
            link.Click();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));

            IWebElement search = _driver.FindElement(By.Name("search"));
            search.SendKeys("NUnit");
            search.Submit();

            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));

            IWebElement ru = _driver.FindElement(By.ClassName("interwiki-ru"));

            Assert.That(_driver.Url, Is.EqualTo("http://en.wikipedia.org/wiki/NUnit"));
            Assert.That(ru, Is.Not.Null);
        }
    }
}