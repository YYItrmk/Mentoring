namespace WpfApplication.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using WpfApplication.Models;

    public class MainViewModel
    {
        public List<User> UserList { get; set; }

        public List<Weahter> Weahter { get; set; }

        public List<News> News { get; set; }

        public MainViewModel()
        {
            this.Weahter = new List<Weahter>()
            {
                new Weahter(){City = "東京", TODAY = GetWeahter(4410,1),TOMORROW = GetWeahter(4410,2)},
                new Weahter(){City = "札幌", TODAY = GetWeahter(1400,1),TOMORROW = GetWeahter(1400,2)}
            };

            this.News = new List<News>()
            {
                new News(){Title=GetNews("title"),URL = GetNews("link")}
            };
        }

        //天気を取得する
        private string GetWeahter(int cityCode,int day)
        {
            var results = GetWeatherReportFromYahoo(cityCode);
            var Weather = results.ElementAt<string>(day).Split('】');
            return Weather[1].Replace(" - "," ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityCode">都市コード</param>
        /// <returns></returns>
        private static IEnumerable<string> GetWeatherReportFromYahoo(int cityCode)
        {
            WebClient wc = new WebClient();

            ///エンコーディング形式を指定
            wc.Headers.Add("Content-type", "charset=UTF-8");

            string uriString = string.Format(
                  @"http://rss.weather.yahoo.co.jp/rss/days/{0}.xml", cityCode);
            Uri url = new Uri(uriString);
            string result = wc.DownloadString(url);

            XDocument xdoc = XDocument.Parse(result);

            var nodes = xdoc.Root.Descendants("title");
            foreach (var node in nodes)
            {
                if (node.Value.StartsWith("[PR]") == false)
                {
                    string s = node.Value.Replace(" - Yahoo!天気・災害", "");
                    yield return s;
                }
            }
        }

        private string[] GetNews(string name)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("Content-type", "charset=UTF-8");

            Uri url = new Uri(@"http://news.yahoo.co.jp/pickup/rss.xml");
            string result = wc.DownloadString(url);

            XDocument xdoc = XDocument.Parse(result);

            var nodes = xdoc.Root.Descendants(name);

            List<string> newsItems = new List<string>();

            foreach (var node in nodes)
            {
                newsItems.Add(node.Value);
            }

            newsItems.RemoveAt(0);

            string[] newsItem = newsItems.ToArray();
            return newsItem;

        }
    }
}
