using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace ZavrsniIspitSe
{
    class Class1
    {
        IWebDriver driver;
        string isDisplayed;
        //bool PassFail;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
        }
        public void gotoURL(string url)
        {
            this.driver.Url = url;
        }

        [Test]
        public void ZavrsniTest()
        {
            gotoURL("http://test.qa.rs/");
            Thread.Sleep(3000);

            IWebElement create = driver.FindElement(By.XPath("//a[@href='/new']"));
            create.Click();
            Thread.Sleep(2000);

            string firstName = "QaIme";
            string lastName = "QaPrezime";
            string userName = "QaKorisnickoIme";
            string eMail = "QAnekimail@qa.com";
            string phone = "0641234567";

            IWebElement fName = driver.FindElement(By.XPath("//input[@placeholder='Unesi ime']"));
            fName.SendKeys(firstName);
            IWebElement lName = driver.FindElement(By.XPath("//input[@placeholder='Unesi prezime']"));
            lName.SendKeys(lastName);
            IWebElement uName = driver.FindElement(By.XPath("//input[@placeholder='Unesi korisničko ime']"));
            uName.SendKeys(userName);
            IWebElement mail = driver.FindElement(By.XPath("//input[@placeholder='Unesi e-mail']"));
            mail.SendKeys(eMail);
            IWebElement num = driver.FindElement(By.XPath("//input[@placeholder='Unesi telefon']"));
            num.SendKeys(phone);

            IWebElement country = driver.FindElement(By.XPath("//select[@name='zemlja']/option[@value='srb']"));
            country.Click();
            IWebElement gender = driver.FindElement(By.XPath("//input[@value='z']"));
            gender.Click();
            IWebElement news = driver.FindElement(By.XPath("//input[@id='newsletter']"));
            news.Click();
            IWebElement prom = driver.FindElement(By.XPath("//input[@id='promotions']"));
            prom.Click();

            IWebElement submit = driver.FindElement(By.XPath("//input[@value='Registruj se']"));
            submit.Click();

            IWebElement congrats = driver.FindElement(By.XPath("//div[@role='alert']"));
            isDisplayed = Convert.ToString(congrats.Displayed);
            isDisplayed = Convert.ToString(congrats.FindElement(By.XPath("//div[@role='alert']")).Displayed);
            System.IO.File.AppendAllText(@"D:\Gaga\QA\Zavrsni Ispit - Selenium\ZavrsniIspitSe\Se.txt", "Uspeh! Uspešno ste dodali korisnika " + firstName + " " + lastName + Environment.NewLine);
            Thread.Sleep(4000);

            //bool uspeh1 = congrats.Contains(firstName);
            //bool uspeh2 = congrats.Contains(lastName);
            //PassFail = uspeh1 && uspeh2;
            //string passFails = Convert.ToString(PassFail);
            //System.IO.File.AppendAllText(@"D:\Gaga\QA\Zavrsni Ispit - Selenium\ZavrsniIspitSe\Se.txt", passFails);

            IWebElement table = driver.FindElement(By.XPath("//table"));
            IList<IWebElement> onetablerows = table.FindElements(By.XPath("//tr/td"));
            foreach (var rows in onetablerows)
            {
                System.IO.File.AppendAllText(@"D:\Gaga\QA\Zavrsni Ispit - Selenium\ZavrsniIspitSe\Se.txt", rows.Text.ToString() + Environment.NewLine);
            }

            IList<IWebElement> genderrows = table.FindElements(By.XPath("//tr/td[contains(text() , 'Z')]"));
            foreach (var rows in genderrows)
            {
                System.IO.File.AppendAllText(@"D:\Gaga\QA\Zavrsni Ispit - Selenium\ZavrsniIspitSe\Se.txt", rows.Text.ToString() + Environment.NewLine);
            }
        }
        [TearDown]
        public void BrowserClose()
        {
            driver.Close();
        }
    }
}
