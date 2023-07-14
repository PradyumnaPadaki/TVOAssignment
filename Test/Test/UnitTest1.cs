using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class StartPoint
{
    static void test()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.facebook.com/");
        driver.FindElement(By.Name("email")).SendKeys("pradyumnapadaki@gmail.com");
        driver.FindElement(By.Id("pass")).SendKeys("16October199$");

    }
}