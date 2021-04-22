using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace DemoQAAdvanced.Pages
{
    public class DatePickerPage
    {
        private readonly IWebDriver driver;
        public DatePickerPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        // Input
        [FindsBy(How = How.Id, Using = "datePickerMonthYearInput")]
        public IWebElement SelectDateButton { get; set; }

        public void SelectDate(string date)
        {
            RemoveDate();
            SelectDateButton.SendKeys(date);
            SelectDateButton.SendKeys(Keys.Enter);
        }
        public string DateInOneMonth()
        {
            var dateandtimeAddOneMonth = DateTime.Today.AddMonths(1);
            return dateandtimeAddOneMonth.ToString("MM/dd/yyyy");
        }
        public void RemoveDate()
        {
            var x = 1;
            while (x < 11)
            {
                SelectDateButton.SendKeys(Keys.Backspace);
                x += 1;
            }
        }
    }
}