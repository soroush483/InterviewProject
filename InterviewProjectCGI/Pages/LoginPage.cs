using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewProjectCGI.Pages
{
    public class LoginPage
    {
        public IWebDriver WebDriver { get; }
        public LoginPage(IWebDriver webDriver )=>WebDriver = webDriver;
        public IWebElement TxtUserName => WebDriver.FindElement(By.Name("loginEmail"));
        public IWebElement TxtPassword => WebDriver.FindElement(By.Name("loginPassword"));
        public IWebElement BtnAcceptcookies => WebDriver.FindElement(By.CssSelector("#onetrust-accept-btn-handler"));
        public IWebElement BtnLogin => WebDriver.FindElement(By.CssSelector("body > div.page > div.container.login-page > div.container.mt-3.mt-md-0 > div > div:nth-child(1) > div > div.card-body > div > form > button"));
        public IWebElement LblCustomerName => WebDriver.FindElement(By.TagName("h1"));
        public IWebElement TxtSearch => WebDriver.FindElement(By.Name("q"));
        public IWebElement Lnkproduct => WebDriver.FindElement(By.PartialLinkText("H2 Komfortschläger"));
        public IWebElement LnkProductGrip => WebDriver.FindElement(By.LinkText("1"));
        public IWebElement BtnAddToCart => WebDriver.FindElement(By.Id("add-to-cart-btn"));
        public IWebElement  LnkProductInCart=> WebDriver.FindElement(By.ClassName("product-name"));



        public void ClickAcceptCookieButton() => BtnAcceptcookies.Submit();
        public void Login(string userName, string password)
        {
            TxtUserName.SendKeys(userName);
            TxtPassword.SendKeys(password);
        }
        public void ClickLoginButton() => BtnLogin.Submit();
        public string IsCustomerNameExist()=>LblCustomerName.Text;
        public void search(string product) =>TxtSearch.SendKeys(product);
        public void ClickProductlink() =>Lnkproduct.Click();
        public void SelectProductGrip() => LnkProductGrip.Click();
        public void ClickAddtoCartButton() => BtnAddToCart.Click();
        public string IsProductExist() => LnkProductInCart.Text;

    }

}
