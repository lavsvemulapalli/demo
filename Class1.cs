using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoProject
{
    public class Class1
    {
        IWebDriver d;
        [SetUp]
        public void intilizing()
        {
            d = new ChromeDriver();
            d.Navigate().GoToUrl("https://www.saucedemo.com/");
            d.Manage().Window.Maximize();
            d.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);

        }
        [Test]
        public void test()
        {


            d.FindElement(By.XPath("//input[@data-test='username']")).SendKeys("standard_user");
            Thread.Sleep(2000);

            d.FindElement(By.XPath("//input[@data-test='password']")).SendKeys("secret_sauce");
            Thread.Sleep(2000);
            d.FindElement(By.XPath("//input[@class='login-button']")).Click();
            Thread.Sleep(2000);
            Assert.AreEqual("Swag Labs", d.FindElement(By.XPath("//*[@id='header_container']/div[1]")).Text);

        }

        [TearDown]
        public void closing()
        {
            d.Quit();
        }
    }
}
