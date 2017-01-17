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
            /*
            this.UserList = new List<User>()
            {
                new User(){Id = 1, DisplayName = "Tsuyoshi Tanaka", Age = 28},
                new User(){Id = 2, DisplayName = "Onishi Kenji", Age = 24},
                new User(){Id = 3, DisplayName = "Suzuki Shyun", Age = 25}
            };
            */
            this.Weahter = new List<Weahter>()
            {
                new Weahter(){City = "東京", TODAY = GetTodayWeahter(4410),TOMORROW = GetTomorrowWeater(4410)},
                new Weahter(){City = "札幌", TODAY = GetTodayWeahter(1400),TOMORROW = GetTomorrowWeater(4410)}
            };

            this.News = new List<News>()
            {
                new News(){Title=GetNewsTitle(),URL = GetNewsLink()}
            };
        }

        //今日の天気を取得する
        private string GetTodayWeahter(int CityCode)
        {
            var results = GetWeatherReportFromYahoo(CityCode);
            var Weather = results.ElementAt<string>(1).Split('】');
            return Weather[1];
        }

        //明日の天気
        private string GetTomorrowWeater(int CityCode)
        {
            var results = GetWeatherReportFromYahoo(CityCode);
            var Weather = results.ElementAt<string>(2).Split('】');
            return Weather[1];
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

        private  string[] GetNewsTitle()
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("Content-type", "charset=UTF-8");

            Uri url = new Uri(@"http://news.yahoo.co.jp/pickup/rss.xml");
            string result = wc.DownloadString(url);

            XDocument xdoc = XDocument.Parse(result);

            var nodes = xdoc.Root.Descendants("title");
            
             List<string> title = new List<string>();
           
            foreach (var node in nodes)
            {
                title.Add(node.Value);
            }

            title.RemoveAt(0);

            string[] strTitle = title.ToArray();
            return strTitle;

        }

        private string[] GetNewsLink()
        {
            WebClient wc = new WebClient();

            wc.Headers.Add("Content-type", "charset=UTF-8");
            Uri url = new Uri(@"http://news.yahoo.co.jp/pickup/rss.xml");
            string result = wc.DownloadString(url);

            XDocument xdoc = XDocument.Parse(result);

            var nodes = xdoc.Root.Descendants("link");
            List<string> link = new List<string>();

            foreach (var node in nodes)
            {
                link.Add(node.Value);
            }

            link.RemoveAt(0);

            string[] strLink = link.ToArray();
            return strLink;
        }
    }
}
