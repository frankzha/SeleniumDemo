﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymond.Costco.Web.AutoTest.Library
{
    public class Base
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public Base(IWebDriver d, WebDriverWait w)
        {
            if (d is null || w is null)
            {
                throw new NullReferenceException("Page Init error");
            }

            this.driver = d;
            this.wait = w;
        }

        public bool WaitAndVerifyLoadingCompletion(IWebElement webElement)
        {
            return wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete") && this.WaitForAjax() && webElement.Enabled );
        }
        public bool WaitForAjax()
        {
            while (true)
            {
                var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete)
                    return true;
                System.Threading.Thread.Sleep(100);
            }
        }

        public void ScrollIntoView(IWebElement webElement)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
            System.Threading.Thread.Sleep(500);
        }

        public void MouseOver(IWebElement webElement)
        {
            string javaScript = "var evObj = document.createEvent('MouseEvents');" +
                    "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                    "arguments[0].dispatchEvent(evObj);";
            
            ((IJavaScriptExecutor)driver).ExecuteScript(javaScript, webElement);
            System.Threading.Thread.Sleep(500);
        }
    }
}
