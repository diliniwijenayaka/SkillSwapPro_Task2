using System;
using OpenQA.Selenium;
using MarsFramework.Global;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.AbstractMethods
{
    public class ProfileOptions
    {
        //Language and Skill Add new button
        private IWebElement languageSkillAddNew => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table/thead/tr/th[3]/div"));

        //Education Add new button
        private IWebElement educationAddNew => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table/thead/tr/th[6]/div"));

        //Certifications Add new button
        private IWebElement certificationsAddNew => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table/thead/tr/th[4]/div"));

        //Click on Add New button to enter the options Languages, Skills, Education, Certifications
        public void clickAddNew(string addNewItem)
        {
            switch (addNewItem)
            {
                case "Languages":
                case "Skills":
                    //Thread.Sleep(5000);
                    //IWebElement addNew = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table/thead/tr/th[3]/div"));
                    languageSkillAddNew.Click();
                    break;

                case "Education":
                    //Driver.TurnOnWait();
                    //IWebElement addNewEducation = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table/thead/tr/th[6]/div"));
                    educationAddNew.Click();
                    break;

                case "Certifications":
                    //Driver.TurnOnWait();
                    //IWebElement addNewCertifications = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table/thead/tr/th[4]/div"));
                    certificationsAddNew.Click();

                    break;

            }

        }
    }

}

