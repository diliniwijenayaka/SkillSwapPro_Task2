using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.AbstractMethods
{
    public class ClickMenu
    {
        //click Profile Option Dashboard, Profile, Manage Listing, Manage Request


        public void clickMenuOptions(string menuOptions)
        {
            var clickMenu = new ClickMenu();
            var barXpath = "//*[@class='nav-secondary']//a[text()[normalize-space(.)='" + menuOptions + "']]";
            IWebElement _menuClickoption = clickMenu.menuBarOptions(barXpath);
            _menuClickoption.Click();

        }

        //function to find menu options 
        public IWebElement menuBarOptions(string menuOptionLocator)
        {

            var toolMenu = Global.GlobalDefinitions.driver.FindElement(By.XPath(menuOptionLocator));
            return toolMenu;

        }

        //click Profile Options Langauges, Skills, Eductaion, Certifiactions
        public void ClickSubMenuOptions(string menuOptions)
        {
            var clickMenu = new ClickMenu();
            var barXpath = "//*[@class='ui top attached tabular menu']/a[text()[normalize-space(.)='" + menuOptions + "']]";
            IWebElement _menuClickoption = clickMenu.subMenuBarOptions(barXpath);
            _menuClickoption.Click();

        }

        //function to find submenu options 
        public IWebElement subMenuBarOptions(string menuOptionLocator)
        {

            var toolMenu = Global.GlobalDefinitions.driver.FindElement(By.XPath(menuOptionLocator));
            return toolMenu;

        }
    }
}

