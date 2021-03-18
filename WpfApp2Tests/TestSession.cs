using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace WpfApp2Tests
{
    public class TestSession
    {
        protected static WindowsDriver<WindowsElement> session;
        static bool onceFlag = false;

        public static void Setup()
        {
            var options = new AppiumOptions();
            var dir = Directory.GetCurrentDirectory();
            var p = Path.Combine(dir, @"..\..\..\..\WpfApp2\bin\Debug\netcoreapp3.1\WpfApp2.exe");
            options.AddAdditionalCapability("app", p);
            session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        }

        public static void TearDown()
        {
            if (session != null)
            {
                session.Quit();
                session = null;
            }
        }

    }
}
