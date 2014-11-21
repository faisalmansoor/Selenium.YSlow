using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Selenium.YSlow.Tests
{
    [TestFixture]
    public class YSlowStatsTests
    {
        [TestCase]
        public void Load()
        {
            var stats = JsonConvert.DeserializeObject<YSlowPageStats>(File.ReadAllText("yahoo-yslow.json"));

            Assert.AreEqual(626574, stats.TotalPageSize);
            Assert.AreEqual(81, stats.OverallScore);
            Assert.AreEqual("https%3A%2F%2Fwww.yahoo.com%2F", stats.Url);
            Assert.AreEqual(48, stats.TotalNumberOfRequests);
            Assert.AreEqual("2023538075", stats.PageSpaceId);
            Assert.AreEqual("ydefault", stats.RuleSetId);
            Assert.AreEqual(8425, stats.PageLoadTime);

            Assert.AreEqual(0, stats.RuleSet.UseCdn.Score);
            Assert.AreEqual(100, stats.RuleSet.CompressWithGzip.Score);
            Assert.AreEqual(10, stats.RuleSet.UseCookieFreeDomains.Score);
            Assert.AreEqual(100, stats.RuleSet.CssAtTop.Score);
            Assert.AreEqual(50, stats.RuleSet.ReduceDnslookups.Score);
            Assert.AreEqual(100, stats.RuleSet.RemoveDuplicateJavasScriptAndCss.Score);
            Assert.AreEqual(100, stats.RuleSet.AvoidEmptySrcOrHref.Score);
            Assert.AreEqual(100, stats.RuleSet.ConfigureETags.Score);
            Assert.AreEqual(67, stats.RuleSet.AddExpiresHeaders.Score);
            Assert.AreEqual(100, stats.RuleSet.AvoidCssExpressions.Score);
            Assert.AreEqual(0, stats.RuleSet.MakeJavaScriptAndCssExternal.Score);
            Assert.AreEqual(95, stats.RuleSet.MakeFaviconSmallAndCacheable.Score);
            Assert.AreEqual(85, stats.RuleSet.DoNotScaleImagesInHtml.Score);
            Assert.AreEqual(80, stats.RuleSet.PutJavaScriptAtBottom.Score);
            Assert.AreEqual(100, stats.RuleSet.ReduceCookieSize.Score);
            Assert.AreEqual(49, stats.RuleSet.ReduceNumberOfDomElements.Score);
            Assert.AreEqual(40, stats.RuleSet.MinifyJavaScriptAndCss.Score);
            Assert.AreEqual(100, stats.RuleSet.Avoid404.Score);
            Assert.AreEqual(100, stats.RuleSet.AvoidAlphaImageLoaderFilter.Score);
            Assert.AreEqual(84, stats.RuleSet.MakeFewerHttpRequests.Score);
            Assert.AreEqual(50, stats.RuleSet.AvoidUrlRedirects.Score);
            Assert.AreEqual(90, stats.RuleSet.MakeAjaxCacheable.Score);
            Assert.AreEqual(95, stats.RuleSet.UseGetForAjaxRequests.Score);

            Assert.AreEqual(160533, stats.TotalPageSizePrimed);
            Assert.AreEqual(22, stats.TotalNumberOfRequestsPrimed);
        }
    }
}
