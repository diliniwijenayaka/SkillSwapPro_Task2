using System;
using MarsFramework.Global;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MarsFramework.Pages
{
    public class ShareSkill
    {
        
        #region  Initialize Web Elements

        // Click on the "Share Skill" button
        private IWebElement clickShareSkills => GlobalDefinitions.driver.FindElement(By.LinkText("Share Skill"));

        //Title
        private IWebElement AddTitle => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div[1]/div[1]/input"));

        //Description
        private IWebElement AddDescription => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div/textarea"));

        //Dropdown List Select Category
        private IWebElement DropdownListCategory => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select"));

        //Dropdown List Select SubCategory
        private IWebElement DropdownListSubCategory => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div/select"));

        //Tags
        private IWebElement AddTags => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));

        //Service Type Option
        private IWebElement ServiceType => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));

        //Location Type Option
        private IWebElement LocationType => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));

        //Fill Start Date
        private IWebElement StartDate => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));

        //Fill End Date
        private IWebElement EndDate => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));

        //Click on the available day Check Box
        private IWebElement Day => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input"));

        //Fill the Starting time
        private IWebElement StartTime => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input"));

        //Fill the Ending time
        private IWebElement EndTime => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input"));

        //Skill Trade Option
        private IWebElement SkillTrade => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));

        //Add Credit Amount
        private IWebElement AddCredit => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div[1]/input"));

        //Select Active Status
        private IWebElement ActiveStatus => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));

        //Save Button
        private IWebElement SaveButton1 => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input"));

        //Locate table for AddedSkill
        private IWebElement tableElement => GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[1]/td[3]"));
        #endregion

        internal void AddSkill()
        {
            //Polulate the Excel Sheet
            GlobalDefinitions.ExcelOperations.PopulateInCollection(GlobalDefinitions.ReadJson(), "ShareSkill");
            GlobalDefinitions.wait(5);

            //Add Title
            AddTitle.Clear();
            AddTitle.Click();
            AddTitle.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Title"));

            //Add Description
            AddDescription.Clear();
            AddDescription.Click();
            AddDescription.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Description"));

            //Select a Category
            IList<IWebElement> optionsCategory = DropdownListCategory.FindElements(By.Name("categoryId"));
            int optionCountCategory = optionsCategory.Count();
            for (int i = 0; i < optionCountCategory; i++)
            {
                if (optionsCategory[i].Text == GlobalDefinitions.ExcelOperations.ReadData(1, "Category"))
                {
                    optionsCategory[i].Click();
                    break;
                }
            }

            //Select a Sub Category
            IList<IWebElement> optionsSubCategory = DropdownListSubCategory.FindElements(By.Name("subcategoryId"));
            int optionCountSubCategory = optionsSubCategory.Count();
            for (int i = 0; i < optionCountSubCategory; i++)
            {
                if (optionsSubCategory[i].Text == GlobalDefinitions.ExcelOperations.ReadData(1, "Sub Category"))
                {
                    optionsSubCategory[i].Click();
                    break;
                }
            }

            //Add a Tag
            AddTags.Clear();
            AddTags.Click();
            AddTags.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Tag"));

            //Select  Service Type
            ServiceType.Click();

            //Select Location Type
            LocationType.Click();
            Thread.Sleep(1000);

            //Add Start Date
            StartDate.Clear();
            StartDate.Click();
            StartDate.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Start Date"));

            //Add End Date
            EndDate.Clear();
            EndDate.Click();
            EndDate.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "End Date"));

            //Select an available day
            Day.Click();
            Thread.Sleep(1000);

            //Add Starting Time
            StartTime.Click();
            StartTime.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Start Time"));

            //Add Ending Time
            EndTime.Click();
            EndTime.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "End Time"));

            //Select Skill Trade
            SkillTrade.Click();
            Thread.Sleep(1000);

            //Add a Credit Amount
            AddCredit.Clear();
            AddCredit.Click();
            AddCredit.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Credit Amount"));

            //Select Active Status
            ActiveStatus.Click();
            Thread.Sleep(1000);

            //Click Save Button
            SaveButton1.Click();
            Thread.Sleep(5000);

        }

        //Verify the Skill Details are added
        public void rowPresent(string Title)
        {
            bool TitleFound = false;
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));

            foreach (IWebElement row in tableRow)
            {
                var p = row.Text;
                if (row.Text.Contains(GlobalDefinitions.ExcelOperations.ReadData(1, "Title")))
                {
                    TitleFound = true;
                    break;
                }
            }
        }

        //Deleting the added Skill

        public void DeleteSharedSkill()
        {
            var DeleteSharedSkill = new Profile();
            IWebElement barXpath = GlobalDefinitions.driver.FindElement(By.XPath("//tr[.//td='" + GlobalDefinitions.ExcelOperations.ReadData(1, "Title") + "']/td[8]/i[3]"));
            barXpath.Click();
            Thread.Sleep(5000);
            IWebElement YesButton = GlobalDefinitions.driver.FindElement(By.XPath(".//html/body/div[2]/div/div[3]/button[2]"));
            YesButton.Click();
            Thread.Sleep(5000);
            Global.GlobalDefinitions.driver.SwitchTo().DefaultContent();

        }

        //Verify the selected skill is deleted from the ManageListing

        public void ShareSkillDeleteConfirm()
        {
            bool ShareSkillPresent = false;
            IWebElement tableElement = GlobalDefinitions.driver.FindElement(By.XPath(".//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[1]/td[3]"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));
            foreach (IWebElement row in tableRow)
            {
                var p = row.Text;

                if (row.Text.Contains(GlobalDefinitions.ExcelOperations.ReadData(1, "Title")))
                {
                    ShareSkillPresent = true;               

                }
            }

            ShareSkillPresent = false;
        }
    }
}

