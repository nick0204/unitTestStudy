using System;
using System.Collections.Generic;
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
using test.Model;

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //new Person().ConvertToAge(new DateTime(1992, 3, 1), new DateTime(2022, 3, 1));
            Console.WriteLine(56205482 % 71000);
           // Console.WriteLine(TimeSpan.FromMilliseconds(1643016422819)); // 33253315
           // Console.WriteLine(TimeSpan.FromMilliseconds(59222800)); // 33253315
        }
    }
}
