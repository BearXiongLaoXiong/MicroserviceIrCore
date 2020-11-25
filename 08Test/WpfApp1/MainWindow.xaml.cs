using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textbox1.Text = @"http://pic2prod-10011668.cos.ap-shanghai.myqcloud.com/C835A37C-3A62-4AE6-B8A2-51472B7AC82A-0-50218288.jpg";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var url = textbox1.Text;
            var fileExtension = System.IO.Path.GetExtension(url);
            string path = $@"{Environment.CurrentDirectory}\{Guid.NewGuid().GetHashCode()}{(fileExtension.Length > 0 ? fileExtension : ".jpg")}";
            var api = new TencentCloudApi();
            var result = await api.GetAsync(url, path);
            if (result)
                img1.Source = new BitmapImage(new Uri(path));
            else MessageBox.Show("下载失败");
        }
    }
}
