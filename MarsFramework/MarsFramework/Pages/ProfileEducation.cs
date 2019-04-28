using System;
using OpenQA.Selenium;
using MarsFramework.Global;
//using static MarsCoreFramework.Global.CommonMethods;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static MarsFramework.Global.CommonMethods;

namespace MarsFramework.Pages
{
    public class ProfileEducation
    {
        //University Name
        private IWebElement addUniversity => GlobalDefinitions.driver.FindElement(By.XPath(".//*[contains(@class, 'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[1]/div[1]/input"));

        //Dropdown List Country
        private IWebElement DropdownListCountry => GlobalDefinitions.driver.FindElement(By.XPath(".//*[contains (@class, 'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[1]/div[2]/select"));

        //Dropdown List Title
        private IWebElement DropdownListTitle => GlobalDefinitions.driver.FindElement(By.XPath(".//*[contains (@class, 'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2] /div[1]/select"));

        //Degree Name
        private IWebElement AddDegree => GlobalDefinitions.driver.FindElement(By.XPath(".//*[contains (@class, 'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2]/div[2]/input"));

        //Dropdown List Year of Graduation
        private IWebElement DropdownGraduationYear => GlobalDefinitions.driver.FindElement(By.XPath(".//*[contains (@class, 'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2]/div[3]/select"));

        //Add Button
        private IWebElement AddButton => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@class='sixteen wide field']/input[1]"));

        //Cancel Button
        private IWebElement CancelButton => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@class='sixteen wide field']/input[2]"));

        //Add a new Education Qualification
        public void AddNewEducation()
        {
            GlobalDefinitions.ExcelOperations.PopulateInCollection(GlobalDefinitions.ReadJson(), "ProfileEducation");

            //Enter University Name
            addUniversity.Clear();
            addUniversity.Click();
            addUniversity.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "University"));

            //Select a country
            IList<IWebElement> optionsCountry = DropdownListCountry.FindElements(By.TagName("option"));
            int optionCountCountry = optionsCountry.Count();
            for (int i = 0; i < optionCountCountry; i++)
            {
                if (optionsCountry[i].Text == GlobalDefinitions.ExcelOperations.ReadData(1, "Country"))
                {
                    optionsCountry[i].Click();
                    break;
                }
            }

            //Select a Title
            IList<IWebElement> optionsTitle = DropdownListTitle.FindElements(By.TagName("option"));
            int optionCountTitle = optionsTitle.Count();
            for (int i = 0; i < optionCountTitle; i++)
            {
                if (optionsTitle[i].Text == GlobalDefinitions.ExcelOperations.ReadData(1, "Title"))
                {
                    optionsTitle[i].Click();
                    break;
                }

            }

            //Add a Degree
            AddDegree.Clear();
            AddDegree.Click();
            AddDegree.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Degree"));

            //Select a Year
            IList<IWebElement> optionsYear = DropdownGraduationYear.FindElements(By.TagName("option"));
            int optionCountYear = optionsYear.Count();
            for (int i = 0; i < optionCountYear; i++)
            {
                if (optionsYear[i].Text == GlobalDefinitions.ExcelOperations.ReadData(1, "Year"))
                {
                    optionsYear[i].Click();
                    break;
                }

            }

            // Click on Add Button
            AddButton.Click();
            Thread.Sleep(5000);
        }

        //Verify Education is added
        public void rowEducationPresent()
        {

            bool educationPresent = false;
            IWebElement tableElement = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));

            foreach (IWebElement row in tableRow)
            {
                var p = row.Text;
                if (row.Text.Contains(GlobalDefinitions.ExcelOperations.ReadData(1, "InstituteName")) && row.Text.Contains(GlobalDefinitions.ExcelOperations.ReadData(1, "Country")))
                {
                    educationPresent = true;
                    //SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "EducationAdded");
                    //CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    break;
                }

            }

        }

        //Deleting Education

        public void deleteEducation()
        {
            var deleteEducation = new Profile();
            IWebElement barXpath = GlobalDefinitions.driver.FindElement(By.XPath("//tr[.//td='" + GlobalDefinitions.ExcelOperations.ReadData(1, "University") + "']/td[3]/span[2]/i"));
            barXpath.Click();
            Thread.Sleep(5000);
            Global.GlobalDefinitions.driver.SwitchTo().DefaultContent();

        }
    }

}
    
