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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proekta2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListAcc lists = new ListAcc();
        Account seller;
        int a = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Menu(object sender, RoutedEventArgs e)
        {
            a = (a + 1) % 2;
            if (a == 0)
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 250;
                buttonAnimation.To = 0;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Menuu.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
            else
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 0;
                buttonAnimation.To = 250;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Menuu.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Basket.Width == 400)
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 400;
                buttonAnimation.To = 0;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Basket.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
            else
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 0;
                buttonAnimation.To = 400;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Basket.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Reg.Visibility = Visibility.Visible;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = 420;
            buttonAnimation.To = 0;
            buttonAnimation.Duration = TimeSpan.FromSeconds(0.5);
            newAcc.BeginAnimation(Button.HeightProperty, buttonAnimation);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {


            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = 0;
            buttonAnimation.To = 420;
            buttonAnimation.Duration = TimeSpan.FromSeconds(0.5);
            newAcc.BeginAnimation(Button.HeightProperty, buttonAnimation);
        }
        void ff()
        {
            
        }
        private void addbook(object sender, RoutedEventArgs e)
        {
            Grid grid = new Grid();
            var bc = new BrushConverter();
            grid.Background = (Brush)bc.ConvertFrom("#4CCD5656");
            grid.Margin = new Thickness(5, 5, 0, 10);
            grid.Height = 300;
            grid.Width = 320;

            TextBlock tb = new TextBlock();
            tb.FontFamily = new FontFamily("Jura");
            tb.Text = "Книга";//Назва книги
            tb.Foreground = Brushes.White;
            tb.FontSize = 18;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Margin = new Thickness(8, 177, 13, 38);
            grid.Children.Add(tb);

            TextBlock tb2 = new TextBlock();
            tb2.FontFamily = new FontFamily("Jura");
            tb2.Text = "Автор";//автор
            tb2.Foreground = Brushes.White;
            tb2.Margin = new Thickness(9,249,9,6);
            grid.Children.Add(tb2);

            TextBlock tb3 = new TextBlock();
            tb3.Text = "50₴";
            tb3.FontFamily = new FontFamily("Jura");
            tb3.Foreground = Brushes.White;
            tb3.Margin = new Thickness(166, 129, 1, 104);
            tb3.TextAlignment = TextAlignment.Center;
            tb3.FontSize = 36;
            grid.Children.Add(tb3);

            Image image = new Image();
            image.HorizontalAlignment = HorizontalAlignment.Left;
            image.Height = 167;
            image.Margin = new Thickness(21, 0 ,0,0);
            image.VerticalAlignment = VerticalAlignment.Top;
            image.Width = 169;
            image.Source = new BitmapImage(new Uri(@"std_book.png",UriKind.Relative));
            grid.Children.Add(image);

            Button b = new Button();
            b.Name = "i" + books.Children.Count;
            b.HorizontalAlignment = HorizontalAlignment.Left;
            b.VerticalAlignment = VerticalAlignment.Top;
            b.Background = null;
            b.BorderBrush = null;
            b.Click += addtoBasket;
            b.Height = 300;
            b.Width = 320;
            grid.Children.Add(b);

            MaterialDesignThemes.Wpf.PackIcon i = new MaterialDesignThemes.Wpf.PackIcon();
            i.Kind = MaterialDesignThemes.Wpf.PackIconKind.About;
            i.Width = 20;
            i.Height = 20;
            i.HorizontalAlignment = HorizontalAlignment.Center;
            i.VerticalAlignment = VerticalAlignment.Center;
            i.Foreground = Brushes.White;

            Button b2 = new Button();
            b2.Background = null;
            b2.Name = "j" + books.Children.Count;
            b2.Margin = new Thickness(241, 4, 5, 254);
            b2.BorderBrush = null;
            b2.Height = Double.NaN;
            b2.Click += bookinfo;
            b2.Content = i;
            grid.Children.Add(b2);

            books.Children.Add(grid);
        }
        private void c(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(books.Children.Count + "");

        }
        private void bookinfo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(books.Children.Count + "");

        }
        private void addtoBasket(object sender, RoutedEventArgs e)
        {
            TextBlock tb = new TextBlock();
            tb.Text = ((Button)sender).Name;
            list_b.Children.Add(tb);
        }

        private void Log_in(object sender, RoutedEventArgs e)
        {
            int user_index = lists.SearchAcc(Log.Text, Pass.Password);
            if(user_index!=(-1))
            {
                Reg.Visibility = Visibility.Hidden;
                Log.Text = "";
                Pass.Password = "";
                seller = lists.GetAccountByID(user_index);
                seller_name.Text = seller.Name;
                if(seller.isAdmin)
                {
                    ManageBooks.Height = 45;
                    DeleteAcc.Visibility = Visibility.Hidden;
                    MaganeWorkTeam.Height = 45;
                }
                else
                {
                    ManageBooks.Height = 0;
                    DeleteAcc.Visibility = Visibility.Visible;
                    MaganeWorkTeam.Height = 0;
                }
            }
            else
                MessageBox.Show("Не знайдено такого продавця. Перевірте вхідні дані!");
        }

        private void newAccount(object sender, RoutedEventArgs e)
        {

            if(newPass1.Password==newPass2.Password)
            {
                if (lists.SearchAcc(newLogin.Text) == -1)
                {
                    lists.AddAccount(new Account(newName.Text, newLogin.Text, newPass1.Password));
                    MessageBox.Show("Продавець зареєстрований успішно");
                    DoubleAnimation buttonAnimation = new DoubleAnimation();
                    buttonAnimation.From = 420;
                    buttonAnimation.To = 0;
                    buttonAnimation.Duration = TimeSpan.FromSeconds(0.5);
                    newAcc.BeginAnimation(Button.HeightProperty, buttonAnimation);
                    newName.Text = "";
                    newLogin.Text = "";
                    newPass1.Password = "";
                    newPass2.Password = "";
                }
                else
                {
                    MessageBox.Show("Продавець із таким логіном вже існує!");
                }
            }
            else
            {
                MessageBox.Show("Паролі не співпадають");
            }
        }

        private void ChangeAccounts(object sender, RoutedEventArgs e)
        {
            if (
            Change_Acc.Visibility == Visibility.Hidden)
            { Change_Acc.Visibility = Visibility.Visible;
                _Name.Text = seller.Name;
                Login.Text = seller.Login;
                Password.Text = seller.password;
                Count.Text = seller.count_selled+"";
            }
            else
                Change_Acc.Visibility = Visibility.Hidden;

        }

        private void chLogin(object sender, RoutedEventArgs e)
        {
            seller.Login = chLog.Text;
            Login.Text = seller.Login;
            lists.CHLogin(seller.Name, chLog.Text);
            chLog.Text = "";
        }

        private void chPas(object sender, RoutedEventArgs e)
        {
            seller.password = chPass.Text;
            Password.Text = seller.password;
            lists.CHPass(seller.Name, chPass.Text);
            chPass.Text = "";
        }

        private void deleteAcc(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int x1=r.Next() % 50;
            int x2 = r.Next() % 50;
            int sum;
            int x3 = r.Next() % 2;
            if(x3==1)
            {
                sum = x1 + x2;
            }
            else
            {
                sum = r.Next() % 99+1;
            }
            MessageBoxResult messageBoxResult1 = MessageBox.Show("Хочете видалити свій акаунт? Знайте, що потім ваші дані повернути бути неможливо", "Видалити аккаунт", MessageBoxButton.YesNo);
            if (messageBoxResult1 == MessageBoxResult.Yes)
            {
                MessageBoxResult messageBoxResult2 = MessageBox.Show("Контрольне питання: "+x1+"+"+x2+"="+sum+"?", "Видалити аккаунт", MessageBoxButton.YesNo);
                if (messageBoxResult2 == MessageBoxResult.Yes)
                {
                    if (x3 == 1)
                    {
                        lists.DellAcc(seller);
                        MessageBox.Show("Перевірка пройдена! Аккаунт видалено! Удачі тобі в цьому житті!");
                        Change_Acc.Visibility = Visibility.Hidden;
                        Reg.Visibility = Visibility.Visible;

                    }
                else if (x3 == 0 && x1 + x2 != sum)
                    MessageBox.Show("Перевірка не пройдена! Задумайтесь!");
                    
                }
            }
        }

        private void OpenTeam(object sender, RoutedEventArgs e)
        {
            if (
            Change_Team.Visibility == Visibility.Hidden)
            {
                Change_Team.Visibility = Visibility.Visible;
            }
            else
                Change_Team.Visibility = Visibility.Hidden;
        }
    }
}
