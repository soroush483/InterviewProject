using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using InterviewProjectCGI.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace InterviewProjectCGI.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        LoginPage loginPage = null;

        //StepDefinitions
        [Given(@"I open the login webpage")]
        public void GivenIOpenTheLoginWebpage()
        {
            IWebDriver webDriver = new ChromeDriver("C:\\Users\\Soroush\\Desktop\\InterviewCGI\\Chromedriver");
            webDriver.Navigate().GoToUrl("https://www.tennis-point.de/konto-login/");
            loginPage = new LoginPage(webDriver);
            ///jhgcjhvbkjbk
        }
        [Given(@"click accept cookie button")]
        public void GivenClickAcceptCookieButton()
        {
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            loginPage.ClickAcceptCookieButton();
        }


        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();//read data from table and store in data variable
            loginPage.Login((string)data.Username, (string)data.Password);

        }

        [Given(@"I click Anmelden button")]
        public void GivenIClickAnmeldenButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"I should see Soroush in Mein Konto as logedin customer")]
        public void ThenIShouldSeeSoroushInMeinKontoAsLogedinCustomer()
        {
            string s = "Mein Konto - \"Soroush\"";
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Assert.AreEqual(loginPage.IsCustomerNameExist().ToString(), s);
            //ScenarioContext.Current.Pending();
        }
        ///////////////////////////////////////////////////////////////////////////////////
        [Then(@"I enter Wilson H2 Komfortschläger in search box")]
        public void ThenIEnterWilsonHKomfortschlagerInSearchBox()
        {
            loginPage.search("Wilson H2 Komfortschläger");
        }

        [Then(@"click on product link")]
        public void ThenClickOnProductLink()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            loginPage.ClickProductlink();
        }

        [Then(@"click on Size one button For Grip Strenght")]
        public void ThenClickOnSizeOneButtonForGripStrenght()
        {
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            loginPage.SelectProductGrip();
        }

        [Then(@"click on the In Den Warenkorb button to add product to cart")]
        public void ThenClickOnTheInDenWarenkorbButtonToAddProductToCart()
        {
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            loginPage.ClickAddtoCartButton();
        }

        [Then(@"I should see Wilson H2 Komfortschläger in the cart")]
        public void ThenIShouldSeeWilsonHKomfortschlagerInTheCart()
        {
            string productsName = "Wilson\r\nH2 Komfortschläger";
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Assert.AreEqual(loginPage.IsProductExist().ToString(), productsName);
        }






    }
}
