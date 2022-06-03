using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using stori_challenge.SeleniumControl;
using System;

namespace stori_challenge
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.AddArgument("--start-maximized");
            Browser.driver = new ChromeDriver(opt);
            Browser.driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
        }

        [Test]
        public void Test1()
        {
            //PART 1
            IWebElement radiobutton2 = Browser.driver.FindElement(By.CssSelector("input[value='radio2']"));
            radiobutton2.Click();

            IWebElement radiobutton3 = Browser.driver.FindElement(By.CssSelector("input[value='radio3']"));
            radiobutton3.Click();

            IWebElement radiobutton1 = Browser.driver.FindElement(By.CssSelector("input[value='radio1']"));
            radiobutton1.Click();

            //PART 2
            IWebElement suggestionClass = Browser.driver.FindElement(By.XPath("//input[@id='autocomplete'][1]"));
            suggestionClass.SendKeys("Me");
            suggestionClass.SendKeys(Keys.ArrowDown);
            suggestionClass.SendKeys(Keys.Enter);

            //PART 3
            SelectElement dropdown = new SelectElement(Browser.driver.FindElement(By.XPath("//select[name='dropdown-class-example']")));
            dropdown.SelectByIndex(1); //2nd option
            dropdown.SelectByIndex(2); //3rd option

            //PART 4
            IWebElement checkbox1 = Browser.driver.FindElement(By.CssSelector("input[id='checkBoxOption1']"));
            checkbox1.Click();
            IWebElement checkbox2 = Browser.driver.FindElement(By.CssSelector("input[id='checkBoxOption2']"));
            checkbox2.Click();

            //PART 5
            IWebElement switchToAlertTextBox = Browser.driver.FindElement(By.CssSelector("#name"));
            switchToAlertTextBox.SendKeys("Stori Card");
            IWebElement switchToAlertButton = Browser.driver.FindElement(By.XPath("//input[@id='alertbtn']"));
            switchToAlertButton.Click();
            Browser.driver.SwitchTo().Alert().Accept();

            //PART 6
            try
            {
                IWebElement hiddenElement = Browser.driver.FindElement(By.CssSelector(".displayed-class"));
                Console.WriteLine("Element is present");
            }
            catch (Exception e)
            {
                if(e is ElementNotVisibleException | e is StaleElementReferenceException)
                Console.WriteLine("Element is NOT present");
                throw;
            }        
        }

        [TearDown]
        public void TearDown()
        {
            Browser.driver.Quit();
        }
    }
}