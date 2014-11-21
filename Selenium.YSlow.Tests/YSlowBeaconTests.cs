using System;
using System.Web;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace Selenium.YSlow.Tests
{
    [TestFixture]
    public class YSlowBeaconTests
    {
        [TestCase]
        public void TestYahoo()
        {
            using (var beacon = new YSlowBeacon())
            {
                var driver = new FirefoxDriver(beacon.GetRequiredFirefoxCapabilities());

                driver.Navigate().GoToUrl(new Uri("http://wwww.yahoo.com"));

                YSlowPageStats stats;
                if (!beacon.PageStats.TryTake(out stats, TimeSpan.FromSeconds(20)))
                {
                    Assert.Fail("Failed to capture yslow logs in 20 seconds");
                }

                Console.WriteLine("{0} - {1}", HttpUtility.UrlDecode(stats.Url), stats.OverallScore);

                driver.Close();
            }
        }
    }
}
