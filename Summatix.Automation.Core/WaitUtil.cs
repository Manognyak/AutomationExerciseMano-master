using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;


namespace Summatix.Automation.Core
{
    public class WaitUtil
    {
        IWebDriver _driver;
        public WaitUtil(IWebDriver _driver)
        {
            this._driver = _driver;
        }
        

        private void Wait()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(120));
            wait.Until(driver =>
            {
                bool isAjaxFinished = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0");
                bool isLoaderHidden = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return $('.loader').is(':visible') == false");
                bool isPageLoaded = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return document.readyState == 'complete'");
                return isAjaxFinished && isLoaderHidden && isPageLoaded;
            });
            Task.Delay(500).Wait();
        }

        public void PageLoadComplete()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(120));
            wait.Until(driver =>
            {
               
                bool isPageLoaded = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return document.readyState == 'complete'");
                return isPageLoaded;
            });
            //Task.Delay(500).Wait();
        }

        public bool ElementVisible(By locator, int timeoutInSeconds = 120)
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            wait.Until(condition =>
            {
                try
                {
                    var element = _driver.FindElement(locator);
                    return element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            });

            return false;
        }

    
        public bool ElementClickable(By locatorStrategy, int timeoutInSeconds = 120)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(120);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement searchResult = null;
            bool isClickable = false;
            bool staleElement = true;

            while (staleElement)
            {
                try
                {
                    searchResult = fluentWait.Until(ExpectedConditions.ElementToBeClickable(locatorStrategy));
                    staleElement = false;
                    isClickable = true;
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }
            return isClickable;
        }

        public bool WebElementClickable(IWebElement element, int timeoutInSeconds = 120)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(120);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement searchResult = null;
            bool isClickable = false;
            bool staleElement = true;

            while (staleElement)
            {
                try
                {
                    searchResult = fluentWait.Until(ExpectedConditions.ElementToBeClickable(element));
                    staleElement = false;
                    isClickable = true;
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }
            return isClickable;
        }

        public void WaitUntilTextIsInvisible(By locatorStrategy, string text, int timeoutInSeconds = 120)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(120);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement searchResult = null;
            bool staleElement = true;

            while (staleElement)
            {
                try
                {
                    fluentWait.Until(ExpectedConditions.InvisibilityOfElementWithText(locatorStrategy, text));
                    staleElement = false;
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
                catch (NoSuchElementException)
                {
                    staleElement = true;
                }
                catch (Exception)
                {
                    staleElement = true;
                }
            }
        }

    }
}
