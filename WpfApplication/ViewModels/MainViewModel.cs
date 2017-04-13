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
        public List<Weahter> Weahter { get; set; }

        public List<PrimaryNews> primaryNews { get; set; }
        public List<EntertainmentNews> entertainmentNews { get; set; }

        private string primaryNewsUrl = @"http://news.yahoo.co.jp/pickup/rss.xml";
        private string entertainmentNewsUrl = @"https://news.yahoo.co.jp/pickup/entertainment/rss.xml";
        //private string primaryNewsUrl = @"http://news.yahoo.co.jp/pickup/rss.xml";

        public MainViewModel()
        {
            this.Weahter = new List<Weahter>()
            {
                new Weahter(){City = "札幌", TODAY = GetWeahter(1400,1),TOMORROW = GetWeahter(1400,2)},
                new Weahter(){City = "仙台", TODAY = GetWeahter(3410,1),TOMORROW = GetWeahter(3410,2)},
                new Weahter(){City = "東京", TODAY = GetWeahter(4410,1),TOMORROW = GetWeahter(4410,2)},
                new Weahter(){City = "名古屋", TODAY = GetWeahter(5110,1),TOMORROW = GetWeahter(5110,2)},
                new Weahter(){City = "大阪", TODAY = GetWeahter(6200,1),TOMORROW = GetWeahter(6200,2)},
                new Weahter(){City = "福岡", TODAY = GetWeahter(8210,1),TOMORROW = GetWeahter(8210,2)}
            };

            //関数化
            var titleList = GetNews("title",primaryNewsUrl);
            var linkList = GetNews("link",primaryNewsUrl);
            this.primaryNews = new List<PrimaryNews>()
            {
                new PrimaryNews(){Title = titleList[0],URL = linkList[0]},
                new PrimaryNews(){Title = titleList[1],URL = linkList[1]},
                new PrimaryNews(){Title = titleList[2],URL = linkList[2]},
                new PrimaryNews(){Title = titleList[3],URL = linkList[3]},
                new PrimaryNews(){Title = titleList[4],URL = linkList[4]},
                new PrimaryNews(){Title = titleList[5],URL = linkList[5]},
                new PrimaryNews(){Title = titleList[6],URL = linkList[6]},
                new PrimaryNews(){Title = titleList[7],URL = linkList[7]},
            };

            var titleList1 = GetNews("title", entertainmentNewsUrl);
            var linkList1 = GetNews("link", entertainmentNewsUrl);
            this.entertainmentNews = new List<EntertainmentNews>()
            {
                new EntertainmentNews(){Title = titleList1[0],URL = linkList1[0]},
                new EntertainmentNews(){Title = titleList1[1],URL = linkList1[1]},
                new EntertainmentNews(){Title = titleList1[2],URL = linkList1[2]},
                new EntertainmentNews(){Title = titleList1[3],URL = linkList1[3]},
                new EntertainmentNews(){Title = titleList1[4],URL = linkList1[4]},
                new EntertainmentNews(){Title = titleList1[5],URL = linkList1[5]},
                new EntertainmentNews(){Title = titleList1[6],URL = linkList1[6]},
                new EntertainmentNews(){Title = titleList1[7],URL = linkList1[7]},
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

        /// <summary>
        /// ニュースを取得する
        /// </summary>
        /// <param name="name">名前</param>
        /// <returns></returns>
        private string[] GetNews(string name,string URL)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("Content-type", "charset=UTF-8");

            Uri url = new Uri(URL);
            string result = wc.DownloadString(url);

            XDocument xdoc = XDocument.Parse(result);

            XElement element = XElement.Parse(result);


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
