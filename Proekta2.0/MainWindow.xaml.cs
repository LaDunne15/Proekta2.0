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
using System.IO;

namespace Proekta2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int index = 0;
        int indexbook = 0;
        ListAcc lists = new ListAcc();
        BaseOfBooks bob = new BaseOfBooks();
        List<Book> oneGenrebooks;
        List<Book> basket;
        Account seller;
        string _path;
        Discount discount;
        public MainWindow()
        {
            InitializeComponent();
        }
        public string GenreFromIndex(int a)
        {
            switch (a)
            {
                case 1: return "Бізнес і інвестиції";
                case 2: return "Біографії і мемуари";
                case 3: return "Детективи і триллери";
                case 4: return "Для дітей";
                case 5: return "Здоров'я і спорт";
                case 6: return "Історія";
                case 7: return "Комп'ютери і технології";
                case 8: return "Кулінарія і домашнє господарство";
                case 9: return "Романи";
                case 10: return "Фантастика і фентезі";
                case 11: return "Художня література";
                default: return "Невідомий жанр";
            }
        }
        private void CloseMenu(object sender, RoutedEventArgs e)
        {
            if (Menuu.Width == 250)
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 250;
                buttonAnimation.To = 0;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Menuu.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
        }

        private void Menu(object sender, RoutedEventArgs e)
        {
            if (Menuu.Width == 250)
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
            if (Basket.Width == 500)
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 500;
                buttonAnimation.To = 0;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Basket.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
            else
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 0;
                buttonAnimation.To = 500;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Basket.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Reg.Visibility = Visibility.Visible;
            if (Menuu.Width == 250)
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 250;
                buttonAnimation.To = 0;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Menuu.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
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
            books.Children.Clear();
            foreach (var i in bob.getList())
            {
                addbooktobass(i);
            }
        }
        private void addbooktobass(Book A)
        {
            Grid grid = new Grid();
            var bc = new BrushConverter();
            grid.Background = (Brush)bc.ConvertFrom("#4CCD5656");
            grid.Margin = new Thickness(5, 5, 0, 10);
            grid.Height = 300;
            grid.Width = 320;

            TextBlock tb = new TextBlock();
            tb.FontFamily = new FontFamily("Jura");
            tb.Text = A.Name;//Назва книги
            tb.Foreground = Brushes.White;
            tb.FontSize = 18;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Margin = new Thickness(8, 177, 13, 38);
            grid.Children.Add(tb);

            TextBlock tb2 = new TextBlock();
            tb2.FontFamily = new FontFamily("Jura");
            tb2.Text = A.Author;//автор
            tb2.Foreground = Brushes.White;
            tb2.Margin = new Thickness(9, 249, 9, 6);
            grid.Children.Add(tb2);

            TextBlock tb3 = new TextBlock();
            tb3.Text = (A.price*A.discount )+ "₴";
            tb3.FontFamily = new FontFamily("Jura");
            tb3.Foreground = Brushes.White;
            tb3.Margin = new Thickness(166, 129, 1, 104);
            tb3.TextAlignment = TextAlignment.Center;
            tb3.FontSize = 36;
            grid.Children.Add(tb3);

            Image image = new Image();
            image.HorizontalAlignment = HorizontalAlignment.Left;
            image.Height = 167;
            image.Margin = new Thickness(21, 0, 0, 0);
            image.VerticalAlignment = VerticalAlignment.Top;
            image.Width = 169;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory().ToString());
            bitmap.UriSource = new Uri(di.Parent.Parent.FullName + @"\images\" + A.ImagePath);
            bitmap.EndInit();

            image.Source = bitmap;

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
            BookInfo.Visibility = Visibility.Visible;
            int i=Convert.ToInt32(((Button)sender).Name.Replace("j",""));
            Book ibook = oneGenrebooks.ElementAt(i);
            IB_About.Text = ibook.About;
            IB_name.Text = ibook.Name;
            IB_Author.Text = ibook.Author;


            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory().ToString());
            bitmap.UriSource = new Uri(di.Parent.Parent.FullName + @"\images\" + ibook.ImagePath);
            bitmap.EndInit();

            IB_Image.Source = bitmap;
            IB_Count.Text = ibook.Count_Selled+"";
            IB_Genre.Text = GenreFromIndex(ibook.Genre);

            if(ibook.discount==1)
            {
                IB_Price1.Text = "";
                IB_Price2.Text = ibook.price+ "₴";
            }
            else
            {
                IB_Price1.Text = ibook.price + "₴";
                IB_Price1.TextDecorations = TextDecorations.Strikethrough;
                IB_Price2.Text = (ibook.price * ibook.discount)+ "₴";
            }
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
            if (user_index != (-1))
            {
                Reg.Visibility = Visibility.Hidden;
                Log.Text = "";
                Pass.Password = "";
                seller = lists.GetAccountByID(user_index);
                seller_name.Text = seller.Name;
                if (seller.isAdmin)
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

            if (newPass1.Password == newPass2.Password)
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
            {
                Change_Acc.Visibility = Visibility.Visible;
                _Name.Text = seller.Name;
                Login.Text = seller.Login;
                Password.Text = seller.password;
                Count.Text = seller.count_selled + "";
            }
            else
                Change_Acc.Visibility = Visibility.Hidden;
            if (Menuu.Width == 250)
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 250;
                buttonAnimation.To = 0;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Menuu.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
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
            int x1 = r.Next() % 50;
            int x2 = r.Next() % 50;
            int sum;
            int x3 = r.Next() % 2;
            if (x3 == 1)
            {
                sum = x1 + x2;
            }
            else
            {
                sum = r.Next() % 99 + 1;
            }
            MessageBoxResult messageBoxResult1 = MessageBox.Show("Хочете видалити свій акаунт? Знайте, що потім ваші дані повернути бути неможливо", "Видалити аккаунт", MessageBoxButton.YesNo);
            if (messageBoxResult1 == MessageBoxResult.Yes)
            {
                MessageBoxResult messageBoxResult2 = MessageBox.Show("Контрольне питання: " + x1 + "+" + x2 + "=" + sum + "?", "Видалити аккаунт", MessageBoxButton.YesNo);
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
            if (Menuu.Width == 250)
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 250;
                buttonAnimation.To = 0;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Menuu.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
            if (
            Change_Team.Visibility == Visibility.Hidden)
            {
                Change_Team.Visibility = Visibility.Visible;
                dataTeam.ItemsSource = null;
                dataTeam.ItemsSource = lists.getList();
            }
            else
                Change_Team.Visibility = Visibility.Hidden;
        }

        private void datagr_select(object sender, EventArgs e)
        {
            int index = dataTeam.SelectedIndex;
        }
        private void Delete_Acc(object sender, EventArgs e)
        {
            MessageBoxResult messageBoxResult2 = MessageBox.Show("Ви дійсно хочете видалити продавця " + lists.GetAccountByID(index).Name.Replace(" ", "") + " під логіном " + lists.GetAccountByID(index).Login.Replace(" ", "") + ", що продав " + lists.GetAccountByID(index).count_selled + " книг", "Видалити аккаунт", MessageBoxButton.YesNo);
            if (messageBoxResult2 == MessageBoxResult.Yes)
            {
                if (lists.GetAccountByID(index).Login != seller.Login)
                {
                    lists.DellAcc(lists.GetAccountByID(index));
                    MessageBox.Show("Продавця видалено успішно");
                    lists = new ListAcc();
                    dataTeam.ItemsSource = null;
                    dataTeam.ItemsSource = lists.getList();
                }
                else
                    MessageBox.Show("Адміністратора видалити неможливо!");
            }
        }

        private void GetGenre(object sender, RoutedEventArgs e)
        {
            books.Children.Clear();
            int g = Convert.ToInt32(((Button)sender).Name.Replace("G", ""));
            oneGenrebooks = bob.OneTypeBooks(g);
            foreach (var i in oneGenrebooks)
            {
                addbooktobass(i);
            }
            if (Menuu.Width == 250)
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 250;
                buttonAnimation.To = 0;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Menuu.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
        }

        private void ManageBook(object sender, RoutedEventArgs e)
        {
            if (Menuu.Width == 250)
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 250;
                buttonAnimation.To = 0;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Menuu.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
        }
        private void Ch_Lib(object sender, RoutedEventArgs e)
        {
            if (Menuu.Width == 250)
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = 250;
                buttonAnimation.To = 0;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.2);
                Menuu.BeginAnimation(Button.WidthProperty, buttonAnimation);
            }
            if (Change_Library.Visibility == Visibility.Hidden)
            {
                Change_Library.Visibility = Visibility.Visible;
                data2.ItemsSource = null;
                data2.ItemsSource = bob.getList();
            }
            else
                Change_Library.Visibility = Visibility.Hidden;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "(*.jpg)|*.jpg|(*.png)|*.png|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                _path = dialog.FileName;
                string[] a=_path.Split('.');
                BookPath.Text = System.IO.Path.GetFileNameWithoutExtension(_path)+"."+a[a.Length-1];
            }
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory().ToString());
            string a =  di.Parent.Parent.FullName + @"\images\" + BookPath.Text;
            int i = 0;
            if (BookName.Text == "")
            { MessageBox.Show("Дайте назву книзі!"); i++; }
            if (BookAuthor.Text == "")
            { MessageBox.Show("Дайте автору книзі!"); i++; }
            if (BookPrice.Text == "")
            { MessageBox.Show("Дайте ціну книзі!"); i++; }
            if (BookGenre.SelectedIndex == -1)
            { MessageBox.Show("Виберіть потрібний жанр!"); i++; }
            if (BookPath.Text == "")
            { MessageBox.Show("Вкажіть шлях до картинки!"); i++; }
            if (i != 0)
            {
                MessageBox.Show("Всі потрібні поля не заповненні!Книгу не додано!");
            }
            else
            {
                MessageBox.Show("Книгу додано успішно!");
                bob.AddBook(new Book(BookName.Text, BookAuthor.Text, Convert.ToDouble(BookPrice.Text),BookAbout.Text,BookGenre.SelectedIndex+1,1,BookPath.Text,0));
                File.Copy(_path, a);
                BookAbout.Text = "";
                BookAuthor.Text = "";
                BookGenre.SelectedIndex = -1;
                BookName.Text = "";
                BookPath.Text = "";
                BookPrice.Text = "";
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Book aa = bob.GetBookByID(indexbook);
            MessageBoxResult messageBoxResult2 = MessageBox.Show("Ви дійсно хочете видалити книгу '" + aa.Name.Replace(" ","") + "' - " +aa.Author.Replace(" ","")  , "Видалити аккаунт", MessageBoxButton.YesNo);
            if (messageBoxResult2 == MessageBoxResult.Yes)
            {
                    bob.DellAcc(aa);
                    MessageBox.Show("Книгу видалено успішно");
                    lists = new ListAcc();
                    dataTeam.ItemsSource = null;
                    dataTeam.ItemsSource = lists.getList();
            }
        }

        private void Data2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indexbook = data2.SelectedIndex;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            BookInfo.Visibility = Visibility.Hidden;
        }
        private void discount1(object sender, RoutedEventArgs e)
        {
            discount = new Discount(new DiscountByAuthor());
            discount.ExecuteDiscount("",DisNameA1.Text, (100-Convert.ToDouble(DisDis1.Text))/100);
            MessageBox.Show("Знижку "+DisDis1.Text+"% на всі книги "+DisNameA1.Text+" надано!");
            bob = new BaseOfBooks();
            DisNameA1.Text = "";
            DisDis1.Text = "";
        }
        private void discount2(object sender, RoutedEventArgs e)
        {
            discount = new Discount(new JustDiscount());
            discount.ExecuteDiscount(DisName2.Text, DisNameA2.Text, (100 - Convert.ToDouble(DisDis2.Text)) / 100);
            MessageBox.Show("Знижку "+DisDis2.Text+"% на книгу"+DisName2.Text+" автора "+DisNameA2.Text+" надано!");
            bob = new BaseOfBooks();
            DisNameA1.Text = "";
            DisDis1.Text = "";
            data2.ItemsSource = bob.getList();
        }
        private void discount3(object sender, RoutedEventArgs e)
        {
            discount = new Discount(new DiscountPromocode());
            discount.ExecuteDiscount(Promocode.Text,"",0);
            MessageBox.Show("Промокод "+ Promocode.Text+" додано до бази даних!");
            Promocode.Text = "";
        }
        private void discount4(object sender, RoutedEventArgs e)
        {
            discount = new Discount(new RemoveDiscount());
            discount.ExecuteDiscount("", "", 0);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Discount_System.Visibility = Visibility.Hidden;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Discount_System.Visibility = Visibility.Visible;
        }
    }
}
