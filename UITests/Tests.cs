using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using ObjCRuntime;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Platform = Xamarin.UITest.Platform;

namespace UITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            if (platform == Platform.Android)
                app = ConfigureApp
                    .Android
                    .InstalledApp("com.companyname.PipelineUITest")
                    .PreferIdeSettings()
                    .EnableLocalScreenshots()
                    .StartApp();
            else
            {
                //app = AppInitializer.InstalledApp("com.angeltrax.mototrax").StartApp(platform);
            }
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }
    }
}
