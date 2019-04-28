using System;
using OpenQA.Selenium;
using MarsFramework.Global;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.CommonMethods;
using System.Threading;

namespace MarsFramework.Pages   
{
    public class ProfileSkill
    {
        //Add Skill Name
        private IWebElement addSkill => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[1]/input"));

        //Cick Add Button
        private IWebElement clickAdd => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='buttons-wrapper']/input[1]"));

        //Adding New SKill
        public void addNewSkill()
        {
            //Excel sheet data for Add skill
            GlobalDefinitions.ExcelOperations.PopulateInCollection(GlobalDefinitions.ReadJson(), "AddSkill");


            //Enter value in Add skill field
            //IWebElement addSkill = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[1]/input"));
            addSkill.Clear();
            addSkill.Click();
            addSkill.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Skill"));

            //Select value for level
            IWebElement DropDownList = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2]//select"));
            IList<IWebElement> options = DropDownList.FindElements(By.TagName("option"));
            int optionCount = options.Count();
            for (int i = 0; i < optionCount; i++)
            {
                if (options[i].Text == GlobalDefinitions.ExcelOperations.ReadData(1, "SkillLevel"))
                {
                    options[i].Click();
                }

            }

            //Click Add Button after enter skill and skill level
            //IWebElement clickAdd = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='buttons-wrapper']/input[1]"));
            clickAdd.Click();
            Thread.Sleep(5000);
        }

        //Verify Skill is added
        public void rowSkillPresent()
        {

            bool skillPresent = false;
            IWebElement tableElement = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("td"));

            foreach (IWebElement row in tableRow)
            {
                var p = row.Text;
                if (row.Text.Contains(GlobalDefinitions.ExcelOperations.ReadData(1, "Skill")))
                {
                    skillPresent = true;
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "SkillAddedSuccessfully");
                    //CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");

                    break;
                }
                //else;

                skillPresent = false;
                SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "SkillNotAdded");
                //CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Failed to Add a Language Successfully");


            }
        }
    }
}


