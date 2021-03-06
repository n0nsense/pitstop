using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using BWMS.UITest.PageModel.Pages;

namespace BWMS.UITest.PageModel
{
    /// <summary>
    /// Represents the BWMS web-application.
    /// </summary>
    public class App : IDisposable
    {
        private bool _disposed = false;
        private readonly IWebDriver _webDriver;
        private readonly Uri _startUrl;
        private readonly MainMenu _menu;

        public MainMenu Menu
        {
            get
            {
                return _menu;
            }
        }

        public IWebDriver WebDriver
        {
            get
            {
                return _webDriver;
            }
        }


        /// <summary>
        /// Initialize a new BWMS instance.
        /// </summary>
        /// <param name="testrunId">The unique test-run Id.</param>
        /// <param name="startUrl">The Url to start.</param>
        public App(string testrunId, Uri startUrl)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            _webDriver = new ChromeDriver(dir, options);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _startUrl = startUrl;
            _menu = new MainMenu(this);
        }

        /// <summary>
        /// Open the BWMS application.
        /// </summary>
        /// <returns>An initialized <see cref="CustomerSearchPage"/> instance.</returns>
        public HomePage Start()
        {
            _webDriver.Navigate().GoToUrl(_startUrl);
            return CreatePage<HomePage>();
        }

        /// <summary>
        /// Stop the WebApp instance and close the browser.
        /// </summary>
        public void Stop()
        {
            this.Dispose();
        }

        /// <summary>
        /// Take a screenshot and save it in the specified file.
        /// </summary>
        /// <param name="outputFilename">The name of the file to output.</param>
        public void TakeScreenshot(string outputFilename)
        {
            Screenshot ss = ((ITakesScreenshot)_webDriver).GetScreenshot();
            ss.SaveAsFile(outputFilename);
        }

        /// <summary>
        /// Create a new BWMS page.
        /// </summary>
        /// <typeparam name="T">The type of the page to create.</typeparam>
        public T CreatePage<T>() where T : MainPage
        {
            return Activator.CreateInstance(typeof(T), new object[] { this }) as T;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _webDriver.Close();
            }

            _disposed = true;
        }
    }

}