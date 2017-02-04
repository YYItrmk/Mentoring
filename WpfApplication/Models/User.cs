namespace WpfApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /*
    public class User
    {
        public bool IsSelected { get; set; }

        public int Id { get; set; }

        public string DisplayName { get; set; }

        public int Age { get; set; }

        
    }
    */

    /// <summary>
    /// 天気
    /// </summary>
    public class Weahter
    {
        //都市名
        public string City { get; set; }

        //今日の天気
        public string TODAY { get; set; }

        //明日の天気
        public string TOMORROW { get; set; }
    }
    
    /// <summary>
    /// ニュース
    /// </summary>
    public class News
    {
        //タイトル
        public string Title { get; set; }
        
        //URL
        public string URL { get; set; }
    }
}
