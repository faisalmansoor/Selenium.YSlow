using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Selenium.YSlow
{
    // ReSharper disable ClassNeverInstantiated.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable UnusedAutoPropertyAccessor.Global
    public class YSlowPageStats
    {
        [JsonProperty("w")]

        public int TotalPageSize { get; set; }

        [JsonProperty("o")]
        public int OverallScore { get; set; }

        [JsonProperty("u")]
        public string Url { get; set; }

        [JsonProperty("r")]
        public int TotalNumberOfRequests { get; set; }

        [JsonProperty("s")]
        public string PageSpaceId { get; set; }

        [JsonProperty("i")]
        public string RuleSetId { get; set; }

        [JsonProperty("lt")]
        public double PageLoadTime { get; set; }

        [JsonProperty("g")]
        public RuleSet RuleSet { get; set; }

        [JsonProperty("w_c")]
        public int TotalPageSizePrimed { get; set; }

        [JsonProperty("r_c")]
        public int TotalNumberOfRequestsPrimed { get; set; }

        [JsonProperty("stats")]
        public Dictionary<string, ComponentStat> ComponentStats { get; set; }

        [JsonProperty("stats_c")]
        public Dictionary<string, ComponentStat> ComponentStatsPrimed { get; set; }

        [JsonProperty("comps")]
        public List<Component> Components { get; set; }
    }

    public class RuleSet
    {
        [JsonProperty("ycdn")]
        public RuleScore UseCdn;

        [JsonProperty("ycompress")]
        public RuleScore CompressWithGzip;

        [JsonProperty("ycookiefree")]
        public RuleScore UseCookieFreeDomains;

        [JsonProperty("ycsstop")]
        public RuleScore CssAtTop;

        [JsonProperty("ydns")]
        public RuleScore ReduceDnslookups;

        [JsonProperty("ydupes")]
        public RuleScore RemoveDuplicateJavasScriptAndCss;

        [JsonProperty("yemptysrc")]
        public RuleScore AvoidEmptySrcOrHref;

        [JsonProperty("yetags")]
        public RuleScore ConfigureETags;

        [JsonProperty("yexpires")]
        public RuleScore AddExpiresHeaders;

        [JsonProperty("yexpressions")]
        public RuleScore AvoidCssExpressions;

        [JsonProperty("yexternal")]
        public RuleScore MakeJavaScriptAndCssExternal;

        [JsonProperty("yfavicon")]
        public RuleScore MakeFaviconSmallAndCacheable;

        [JsonProperty("yimgnoscale")]
        public RuleScore DoNotScaleImagesInHtml;

        [JsonProperty("yjsbottom")]
        public RuleScore PutJavaScriptAtBottom;

        [JsonProperty("ymincookie")]
        public RuleScore ReduceCookieSize;

        [JsonProperty("ymindom")]
        public RuleScore ReduceNumberOfDomElements;

        [JsonProperty("yminify")]
        public RuleScore MinifyJavaScriptAndCss;

        [JsonProperty("yno404")]
        public RuleScore Avoid404;

        [JsonProperty("ynofilter")]
        public RuleScore AvoidAlphaImageLoaderFilter;

        [JsonProperty("ynumreq")]
        public RuleScore MakeFewerHttpRequests;

        [JsonProperty("yredirects")]
        public RuleScore AvoidUrlRedirects;

        [JsonProperty("yxhr")]
        public RuleScore MakeAjaxCacheable;

        [JsonProperty("yxhrmethod")]
        public RuleScore UseGetForAjaxRequests;
    }

    public class RuleScore
    {
        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("components")]
        public List<string> Components { get; set; }
    }

    public class ComponentStat
    {
        [JsonProperty("r")]
        public int TotalNumberOfRequests { get; set; }

        [JsonProperty("w")]
        public int Weights { get; set; }
    }

    public class Component
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("resp")]
        public int Resp { get; set; }

        [JsonProperty("gzip")]
        public int Gzip { get; set; }

        [JsonProperty("cr")]
        public int Cr { get; set; }

        [JsonProperty("cs")]
        public int Cs { get; set; }

        [JsonProperty("expires")]
        public DateTime Expires { get; set; }

        [JsonProperty("etag")]
        public string ETag { get; set; }

        [JsonProperty("headers")]
        public Headers Headers { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> ExtraProperties;
    }

    public class Headers
    {
        [JsonProperty("request")]
        public Dictionary<string, string> Request;

        [JsonProperty("response")]
        public Dictionary<string, string> Response;
    }

}