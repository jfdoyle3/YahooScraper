using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using HtmlAgilityPack;
using System.Linq;


namespace YahooScraper.Scraper
{
    public class YahooFinance
    {

       public  List<List<string>> Login()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--headless");
            option.AddArgument("window-size=1200,1100");

            using (IWebDriver driver = new ChromeDriver(option))
            {
                driver.Navigate().GoToUrl("https://finance.yahoo.com");

                WebDriverWait waitSignIn = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
                waitSignIn.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("uh-signedin")));

                IWebElement signIn = driver.FindElement(By.Id("uh-signedin"));
                signIn.Click();

                WebDriverWait waitLogin = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
                waitLogin.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("login-username")));

                IWebElement LoginField = driver.FindElement(By.Id("login-username"));
                LoginField.SendKeys("jfdoyle_iii");
                LoginField.SendKeys(Keys.Enter);

                WebDriverWait waitPassword= new WebDriverWait(driver, TimeSpan.FromSeconds(25));
                waitPassword.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("login-passwd")));


                IWebElement passwordField = driver.FindElement(By.Id("login-passwd"));
                passwordField.SendKeys("m93Fe8YHn");
                passwordField.SendKeys(Keys.Enter);



                driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_2/view/v1");
                WebDriverWait waitStockTable = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
                waitStockTable.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//table")));


                HtmlDocument financePage = new HtmlDocument();
                financePage.LoadHtml(driver.PageSource);
             

                List<List<string>> stockTable =
                                    financePage.DocumentNode.SelectSingleNode("//table")
                                                            .Descendants("tr")
                                                            .Skip(1)
                                                            .Where(tr => tr.Elements("td").Count()>1)
                                                            .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                                            .ToList();
                driver.Quit();
                return stockTable;
                }
            }
       }
      
    }
