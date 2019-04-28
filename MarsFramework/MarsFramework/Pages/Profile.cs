using MarsFramework.Global;
//using MarsCoreFramework.AbstractMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
//using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MarsFramework
{
    public class Profile
    {

        #region  Initialize Web Elements 

        //Click on Name
        private IWebElement ClickUserName => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='title']/i"));

        //Edit First Name
        private IWebElement FirstName => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]"));

        //Edit Last Name
        private IWebElement LastName => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[2]"));

        //Click Save button for Name
        private IWebElement ClickSave => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui fluid accordion']/div[2]/div/div[2]/button"));

        //Click on Availability Edit button
        private IWebElement AvailabilityTimeEditIcon => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[2]/div/span/i"));

        //Click on Hours Edit button
        private IWebElement HoursEditIcon => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/i"));

        //Click on Earn target Edit button
        private IWebElement EarnTargetEditIcon => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/i"));

        //Click on fulltime option
        private IWebElement FullTime => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[2]/div/span/select/option[3]"));

        //Click on parttime option
        private IWebElement PartTime => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[2]/div/span/select/option[2]"));

        //Click on lessHours option
        private IWebElement LessHours => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[2]"));

        //Click on moreHours option
        private IWebElement MoreHours => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[3]"));

        //Click on AsneddedHours option
        private IWebElement AsNeeded => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[4]"));

        //Click on earnoption1 option
        private IWebElement LessEarn => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[2]"));

        //Click on earnoption2 option
        private IWebElement MoreEarn => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[3]"));

        //Click on earnoption3 option
        private IWebElement DoubleEarn => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[4]"));

        //click on Profile
        private IWebElement ClickProfile => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='nav-secondary']//a[text()[normalize-space(.)='Profile']]"));

        //*[@class='nav-secondary']//a[text()[normalize-space(.)='Profile']]

        #endregion

        internal void EditProfile()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelOperations.PopulateInCollection(GlobalDefinitions.ReadJson(), "Profile");
            //GlobalDefinitions.wait(5);

            //click on Profile from menu

            //clickProfile.Click();

            //Click on user name 
            ClickUserName.Click();

            //Edit First Name
            //GlobalDefinitions.wait(5);
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]")).Click();
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]")).Clear();
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]")).SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "FirstName"));

            //Edit Last Name
            LastName.Click();
            LastName.Clear();
            LastName.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "LastName"));

            //click Save button
            ClickSave.Click();
            Thread.Sleep(5000);

            //Click Availiable  Edit Icon

            AvailabilityTimeEditIcon.Click();
            Thread.Sleep(5000);
            //GlobalDefinitions.wait(5);

            //Availability Time option

            switch (GlobalDefinitions.ExcelOperations.ReadData(1, "AvailableTime"))
            {

                case "Full Time":
                    // IWebElement fullTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[2]/div/span/select/option[3]"));
                    FullTime.Click();
                    break;
                case "Part Time":
                    //IWebElement partTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[2]/div/span/select/option[2]"));
                    PartTime.Click();
                    break;
            }
            // Hours Edit Icon

            HoursEditIcon.Click();
            //GlobalDefinitions.wait(5);

            //Availability Hours option

            switch (GlobalDefinitions.ExcelOperations.ReadData(1, "Hours"))
            {

                case "Less than 30hours a week":
                    //IWebElement lessHours = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[2]"));
                    LessHours.Click();
                    break;
                case "More than 30hours a week":
                    //IWebElement moreHours = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[3]"));
                    MoreHours.Click();
                    break;
                case "As needed":
                    //IWebElement asNeeded = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[4]"));
                    AsNeeded.Click();
                    break;
            }

            //Click edit for earn Target

            EarnTargetEditIcon.Click();
            Thread.Sleep(5000);

            //Earn Target option

            switch (GlobalDefinitions.ExcelOperations.ReadData(1, "EarnTarget"))
            {

                case "Less than $500 per month":
                    //IWebElement lessEarn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[2]"));
                    LessEarn.Click();
                    break;
                case "Between $500 and $1000 per month":
                    //IWebElement moreEarn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[3]"));
                    MoreEarn.Click();
                    break;
                case "More than $1000 per month":
                    //IWebElement doubleEarn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[4]"));
                    DoubleEarn.Click();
                    break;
            }
        }


    }

}