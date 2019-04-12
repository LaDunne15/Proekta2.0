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

namespace Proekta2._0
{
    /// <summary>
    /// Логика взаимодействия для Book.xaml
    /// </summary>
    public partial class ItemBook : UserControl
    {
        public string Name_Book { get; set; }
        public string Author { get; set; }
        public string About { get; set; }
        public double Price { get; set; }
        public  int rationg { get; set; }
        public int discount { get; set; }

        
        public ItemBook()
        {
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ffff");
        }
    }
}
