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
    using WpfApplication.Models;
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
        
        /// <summary>
        /// 更新ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = new MainViewModel();
        }
        
        /// <summary>
        /// ニュースプレビューの呼び出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrimaryNews NewsItems = DataGrid2.SelectedItem as PrimaryNews;  
            var NewsPreview = new NewsPreview(); 
            NewsPreview.showNews(NewsItems.URL);
            NewsPreview.Show();
        }

        /// <summary>
        /// ニュースプレビューの呼び出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           EntertainmentNews NewsItems = DataGrid3.SelectedItem as EntertainmentNews;
            var NewsPreview = new NewsPreview();
            NewsPreview.showNews(NewsItems.URL);
            NewsPreview.Show();
        }
    }
}
