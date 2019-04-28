using System;
using OpenQA.Selenium;
using MarsFramework.Global;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ProfileLanguage
    {
        #region  Initialize Web Elements

        //Add Lanaguage Name Locator
        private IWebElement addLanguageName => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[1]/input"));

        //Dropdown List Lanaguge Level  
        private IWebElement DropDownListLanguageLevel => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2]//select"));

        //Add button Locatore
        private IWebElement AddButton => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='six wide field']/input[1]"));

        //Locate table for languages
        private IWebElement tableElement => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table"));

        #endregion

        //Add a new Language
        public void AddNewLanguage()
        {
            GlobalDefinitions.ExcelOperations.PopulateInCollection(GlobalDefinitions.ReadJson(), "ProfileLanguage");

            //Add Language Name
            addLanguageName.Clear();
            addLanguageName.Click();
            addLanguageName.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Language"));

            //Select a Level
            IList<IWebElement> options = DropDownListLanguageLevel.FindElements(By.TagName("option"));
            int optionCount = options.Count();
            for (int i = 0; i < optionCount; i++)
            {
                if (options[i].Text == GlobalDefinitions.ExcelOperations.ReadData(1, "Language Level"))
                {
                    options[i].Click();
                }
            }

            //Click Add Button
            AddButton.Click();
            Thread.Sleep(5000);
        }

        //Verify the Language is added
        public void rowPresent(string language)
        {


            bool languageFound = false;
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));

            foreach (IWebElement row in tableRow)
            {
                var p = row.Text;
                if (row.Text.Contains(GlobalDefinitions.ExcelOperations.ReadData(1, "Language")))
                {
                    languageFound = true;
                    break;
                }
            }
        }

        //Deleting a Language

        public void deleteLanguage()
        {
            var deleteLanguage = new Profile();
            IWebElement barXpath = GlobalDefinitions.driver.FindElement(By.XPath("//tr[.//td='" + GlobalDefinitions.ExcelOperations.ReadData(1, "Language") + "']/td[3]/span[2]/i"));
            barXpath.Click();
            Thread.Sleep(5000);
            Global.GlobalDefinitions.driver.SwitchTo().DefaultContent();

        }

        //Verify Langauge is deleted from profile
        public void languageDeletedConfirm()
        {
            bool languagePresent = false;
            IWebElement tableElement = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));
            foreach (IWebElement row in tableRow)
            {
                var p = row.Text;

                if (row.Text.Contains(GlobalDefinitions.ExcelOperations.ReadData(1, "Language")))
                {
                    languagePresent = true;
                    //SaveScreenShotClass.SaveScreenshot(Driver.webDriver, "LanguageNotDeleted");

                }
            }

            languagePresent = false;
        }
    }
}

