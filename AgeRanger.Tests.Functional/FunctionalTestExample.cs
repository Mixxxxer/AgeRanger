using AgeRanger.Tests.Functional.Support;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AgeRanger.Tests.Functional
{
    [TestClass]
    public class FunctionalTestExample : SupportBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            Setup();
        }

        [TestMethod]
        public void Add_Displays_Div_And_Providing_Detail_Creates_New_Person()
        {
            webDriver.FindElement(By.Id("addbtn")).Click();
            webDriver.FindElement(By.Id("firstname")).SendKeys("Test");
            webDriver.FindElement(By.Id("lastname")).SendKeys("Person");
            webDriver.FindElement(By.Id("age")).SendKeys("15");
            webDriver.FindElement(By.Id("savebtn")).Click();

            WaitForElementVisible(By.CssSelector("#display tbody tr:nth-of-type(6)"), 2);

            var id = GetElementText(webDriver, 6, 1);
            var firstName = GetElementText(webDriver, 6, 2);
            var lastName = GetElementText(webDriver, 6, 3);
            var age = GetElementText(webDriver, 6, 4);
            var ageGroup = GetElementText(webDriver, 6, 5);

            id.Should().Be("5");
            firstName.Should().Be("Test");
            lastName.Should().Be("Person");
            age.Should().Be("15");
            ageGroup.Should().Be("Teenager");
        }

        private string GetElementText(IWebDriver driver, int row, int column)
        {
            return webDriver.FindElement(By.CssSelector(string.Format("#display tbody tr:nth-of-type({0}) td:nth-of-type({1})", row, column))).Text;
        }

        [ClassCleanup]
        public new static void Cleanup()
        {
            SupportBase.Cleanup();
        }
    }
}
