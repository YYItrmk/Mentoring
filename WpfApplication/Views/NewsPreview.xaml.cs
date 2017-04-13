using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication.Views
{
    /// <summary>
    /// NewsPreview.xaml の相互作用ロジック
    /// </summary>
    public partial class NewsPreview : Window
    {
        public NewsPreview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ニュースをWebBrowserで表示する
        /// </summary>
        /// <param name="URL"></param>
        public void showNews(string URL)
        {
            // IWebBrowser2 の取得 プロパティから
            var axIWebBrowser2 = typeof(WebBrowser).GetProperty
                ("AxIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            var comObj = axIWebBrowser2.GetValue(this.Browser1, null);

            // 値の設定
            comObj.GetType()
                  .InvokeMember
                  (
                     "Silent",
                     BindingFlags.SetProperty,
                     null,
                     comObj,
                    new object[] { true });
            this.Browser1.Navigate(URL);
        }
    }
}
