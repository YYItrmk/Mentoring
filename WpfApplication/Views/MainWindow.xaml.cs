namespace WpfApplication.Views
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using WpfApplication.ViewModels;

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var a = DataGrid2.SelectedItem;
            //不明
            //var b = a.GetType().GetMember("URL").ElementAt(0);
            if (a != null)
            {
               return;
            }                     
            NewsPreview page = new NewsPreview();
            //ここが不明
            //NavigationService.Navigate(page);
        }
        
        /// <summary>
        /// 更新ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = new MainViewModel();
        }
    }
}
