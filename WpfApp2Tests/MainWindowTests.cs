using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp2;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace WpfApp2.Tests
{
    [TestClass()]
    public class MainWindowTests : WpfApp2Tests.TestSession
    {
        [TestInitialize]
        public void Initialize()
        {
            Setup();
        }

        [TestCleanup]
        public void CleanUp()
        {
            TearDown();
        }
        [TestMethod()]
        public void MainWindowTest()
        {
            var objs = session.FindElementsByClassName("Button");
            foreach (var v in objs)
            {
                if (v.Text == "Click!")
                {
                    v.Click();
                    break;
                }
            }
            var textBox = session.FindElementByClassName("TextBlock");
            Assert.AreEqual("Click", textBox.Text);
            //
            foreach (var v in objs)
            {
                if (v.Text == "hoge!")
                {
                    v.Click();
                    break;
                }
            }
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Root");
            var rootSession= new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);     // デスクトップセッション


            var window = rootSession.FindElementByName("SubWindow");
            var windowHandle = window.GetAttribute("NativeWindowHandle");
            windowHandle = (int.Parse(windowHandle)).ToString("x");

            var winOptions = new AppiumOptions();
            winOptions.AddAdditionalCapability("appTopLevelWindow", windowHandle);
            var deskSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), winOptions);      // Form1のセッション


            var subWnd = deskSession.FindElementByClassName("TextBlock");
            Assert.AreEqual("Hoge", subWnd.Text);

            deskSession.Close();

        }
    }
}