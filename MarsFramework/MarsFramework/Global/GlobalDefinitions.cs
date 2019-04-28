using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MarsFramework.Global
{
    class GlobalDefinitions
    {
        //Initialise the browser
        public static IWebDriver driver { get; set; }

        #region WaitforElement 

        public static void wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
        }
        #endregion

        public static string ReadJson()
        {
            var WebClient = new WebClient();
            var json = WebClient.DownloadString(@"D:\Project_Automation\MarsFrameworkCore\MarsCoreFramework\MarsCoreFramework\MarsCoreFramework\Global\MarsResource.json");
            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            var path = result.Urls.ExcelPath;
            return path;

        }
        //Read Browser
        public static string ReadBrowserJson()
        {
            var WebClient = new WebClient();
            var Browserjson = WebClient.DownloadString(@"D:\Project_Automation\MarsFrameworkCore\MarsCoreFramework\MarsCoreFramework\MarsCoreFramework\Global\MarsResource.json");
            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(Browserjson);
            var path = result.Urls.Browserjson;
            return path;

        }

        #region Excel 
        public class ExcelOperations
        {
            static List<DataCollection> dataCol = new List<DataCollection>();
            private static DataTable ExcelToDataTable(string filename, string sheetName)
            {
                try
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);

                    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    //excelReader.IsFirstRowAsColumnNames = true; //Does not work any more

                    DataSet resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });

                    DataTableCollection table = resultSet.Tables;
                    DataTable resultTable = table[sheetName];
                    return resultTable;
                }
                catch (Exception e)
                {
                    throw;
                }


            }
            public class DataCollection
            {

                public int rowNumber { get; set; }
                public string colName { get; set; }
                public string colValue { get; set; }
            }

            public static void ClearData()
            {
                dataCol.Clear();
            }

            public static void PopulateInCollection(string filename, string sheetName)
            {
                ExcelOperations.ClearData();
                DataTable table = ExcelToDataTable(filename, sheetName);
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        DataCollection dtTable = new DataCollection()
                        {
                            rowNumber = row,
                            colName = table.Columns[col].ColumnName,
                            colValue = table.Rows[row - 1][col].ToString()

                        };
                        dataCol.Add(dtTable);
                    }
                }
            }

            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {
                    string data = (from colData in dataCol where colData.colName == columnName && colData.rowNumber == rowNumber select colData.colValue).SingleOrDefault();
                    //  string data = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).Select(x => x.colValue).SingleOrDefault();
                    return data.ToString();
                }
                catch (Exception e)
                {
                    return null;

                }
            }

#endregion

#region screenshots
public class SaveScreenShotClass
            {
                public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
                {
                    var folderLocation = (Base.ScreenshotPath);

                    if (!System.IO.Directory.Exists(folderLocation))
                    {
                        System.IO.Directory.CreateDirectory(folderLocation);
                    }

                    var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                    var fileName = new StringBuilder(folderLocation);

                    fileName.Append(ScreenShotFileName);
                    fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                    //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
                    fileName.Append(".jpeg");
                    screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                    return fileName.ToString();
                }
            }
            #endregion
        }
    }

}