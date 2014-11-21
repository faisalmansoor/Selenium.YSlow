using System;
using System.Collections.Concurrent;
using Anna;
using Anna.Request;
using Newtonsoft.Json;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Selenium.YSlow
{
    public sealed class YSlowBeacon : IDisposable
    {
        public string BeaconUrl { get; private set; }
        public readonly BlockingCollection<YSlowPageStats> PageStats = new BlockingCollection<YSlowPageStats>();

        private readonly HttpServer _server;

        public YSlowBeacon(int port = 59995)
        {
            string url = string.Format("http://*:{0}/", port);

            _server = new HttpServer(url);
            _server.POST("/beacon/yslow").Subscribe(ProcessYSlowPayload);

            BeaconUrl = string.Format("http://localhost:{0}/beacon/yslow", port);
        }

        private void ProcessYSlowPayload(RequestContext ctx)
        {
            var reader = new System.IO.StreamReader(ctx.Request.InputStream, ctx.Request.ContentEncoding);

            string body = reader.ReadToEnd();

            var pagestats = JsonConvert.DeserializeObject<YSlowPageStats>(body);

            PageStats.Add(pagestats);

            reader.Close();
        }

        public DesiredCapabilities GetRequiredFirefoxCapabilities()
        {
            var profile = new FirefoxProfile();
            profile.AddExtension("Plugins/firebug-2.0.6-fx.xpi");
            profile.SetPreference("extensions.firebug.currentVersion", "2.0");
            profile.SetPreference("extensions.firebug.addonBarOpened", true);
            profile.SetPreference("extensions.firebug.console.enableSites", true);
            profile.SetPreference("extensions.firebug.script.enableSites", true);
            profile.SetPreference("extensions.firebug.net.enableSites", true);
            profile.SetPreference("extensions.firebug.previousPlacement", 1);
            profile.SetPreference("extensions.firebug.allPagesActivation", "on");
            profile.SetPreference("extensions.firebug.onByDefault", true);
            profile.SetPreference("extensions.firebug.defaultPanelName", "net");

            profile.AddExtension("Plugins/yslow-3.1.8-fx.xpi");
            profile.SetPreference("extensions.yslow.beaconUrl", BeaconUrl);
            profile.SetPreference("extensions.yslow.beaconInfo", "all");
            profile.SetPreference("extensions.yslow.optinBeacon", true);
            profile.SetPreference("extensions.yslow.autorun", true);

            var capabilities = DesiredCapabilities.Firefox();

            capabilities.SetCapability(FirefoxDriver.ProfileCapabilityName, profile);

            return capabilities;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_server != null) _server.Dispose();
            }
        }
    }
}
