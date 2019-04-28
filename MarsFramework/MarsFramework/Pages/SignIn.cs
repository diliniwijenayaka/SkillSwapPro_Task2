using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MarsFramework.Global.CommonMethods;
using NUnit.Framework;

namespace MarsFramework.Pages
{
    public class SignIn
    {
        
        #region  Initialize Web Elements 

        //Finding the Sign button
        private IWebElement SignInButton => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui secondary menu inverted']/div/a"));

        // Finding the Email Field
        private IWebElement Email1 => GlobalDefinitions.driver.FindElement(By.Name("email"));

        //Finding the Password Field
        private IWebElement Password1 => GlobalDefinitions.driver.FindElement(By.Name("password"));

        //Finding the Login Button
        private IWebElement LoginButton => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class ='field']/button"));

        #endregion

    #region  Initialize Web Elements 
    //Finding the Sign Link
    [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div[1]/div[1]/div/a[2]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/div[1]/form/div[1]/input")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/div[1]/form/div[2]/input")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/div[1]/form/div[4]/div")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        public void LoginSteps()
        {

            GlobalDefinitions.driver.Manage().Window.Maximize();

            GlobalDefinitions.ExcelOperations.PopulateInCollection(GlobalDefinitions.ReadJson(), "SignIn"); //Populating second sheet of excel sheet

            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelOperations.ReadData(1, "Url"));

            //Click on Sign In tab
            SignInButton.Click();
            Thread.Sleep(500);

            //Enter the data in Username textbox
            Email1.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Email"));
            Thread.Sleep(500);

            //Enter the password
            Password1.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Password"));
            Thread.Sleep(500);

            //Click on Login button
            LoginButton.Click();
            Thread.Sleep(7000);

            //Verification
            Thread.Sleep(1000);

            //Verification
            var text = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='item']/button"));
            Assert.IsTrue(text.Text.Contains("Sign Out"));

        }
    }
}