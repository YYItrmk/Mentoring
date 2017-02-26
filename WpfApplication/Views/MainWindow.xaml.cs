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
            /*
            var elem = e.MouseDevice.DirectlyOver as FrameworkElement;
           
            var array = elem.Parent.ToString().Split(':');
                    
             //暫定
             if (array[1] != " http")
              {
                return;
              }
              string url = array[1]+":"+array[2];
              Process.Start(url);
             */

            NewsPreview page = new NewsPreview();
            NavigationService.Navigate(page);


        }
    }
}
