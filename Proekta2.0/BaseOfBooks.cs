using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekta2._0
{
    class BaseOfBooks
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Proekta_2;Integrated Security=True";
        List<Book> l = new List<Book> { };
        public BaseOfBooks(List<Book> f)
        {
            foreach (Book i in f)
                l.Add(i);
        }
        public List<Book> getList()
        {
            return l;
        }
        public BaseOfBooks()
        {
            string c = "SELECT * FROM Books";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();

                if (DD.HasRows)
                {
                    while (DD.Read())
                    {
                        string x1 = DD.GetValue(0).ToString();
                        string x2 = DD.GetValue(1).ToString();
                        double x3 = Convert.ToDouble(DD.GetValue(2));
                        string x4 = DD.GetValue(3).ToString();
                        int x5 = Convert.ToInt32(DD.GetValue(4));
                        double x6 = Convert.ToDouble(DD.GetValue(5));
                        string x7 = DD.GetValue(6).ToString();
                        int x8 = Convert.ToInt32(DD.GetValue(7));
                        l.Add(new Book(x1, x2, x3, x4, x5, x6, x7, x8));
                    }
                }
            }
        }
        public Book GetBookByID(int a)
        {
            return l.ElementAt(a);
        }

        public void DellAcc(Book A)
        {
            string c = "DELETE  FROM Books WHERE Name='" + A.Name + "' AND AuthorName ='" + A.Author + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
            l.Remove(A);
        }
        public void AddBook(Book A)
        {
            l.Add(A);
            string c = "INSERT INTO Books (Name,AuthorName,Price,About,Genre,Discount_Rate,Image_Path,Count_Selled) VALUES ('" + A.Name + "','" + A.Author + "'," + A.price + ",'" + A.About + "'," + A.Genre + "," + A.discount + ",'" + A.ImagePath + "'," + A.Count_Selled + ")";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }

        public List<Book> OneTypeBooks(int g)//повертає список книг із визначеним жанром
        {
            List<Book> A = new List<Book> { };
            foreach (Book i in l)
            {
                if (i.Genre == g)
                {
                    A.Add(i);
                }
            }
            return A;
        }

        public void DiscountUpdate(string A,string B,double C)
        {
            foreach(var i in l)
            {
                if(i.Name==A && i.Author==B)
                {
                    i.discount = C;
                }
            }
         }
        public void DiscountUpdate(string A, double C)
        {
            foreach (var i in l)
            {
                if (i.Name == A)
                {
                    i.discount = C;
                }
            }
        }
        public void DiscountUpdate()
        {
            foreach (var i in l)
            {
                    i.discount = 1;
            }
        }

        public void CHName(string A, string B,string C)
        {
            foreach (Book i in l)
            {
                if (i.Name== A && i.Author==B)
                {
                    i.Name = C;
                }
            }
            string c = "UPDATE Books SET Name='" + C + "' WHERE Name='" + A + "' AND AuthorName='"+B+"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
        public void CHAuthor(string A, string B, string C)
        {
            foreach (Book i in l)
            {
                if (i.Name == A && i.Author == B)
                {
                    i.Author = C;
                }
            }
            string c = "UPDATE Books SET AuthorName='" + C + "' WHERE Name='" + A + "' AND AuthorName='" + B + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }

        public void CHGenre(string A, string B, int C)
        {
            foreach (Book i in l)
            {
                if (i.Name == A && i.Author == B)
                {
                    i.Genre = C;
                }
            }
            string c = "UPDATE Books SET Genre='" + C + "' WHERE Name='" + A + "' AND AuthorName='" + B + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
        public void CHAbout(string A, string B, string C)
        {
            foreach (Book i in l)
            {
                if (i.Name == A && i.Author == B)
                {
                    i.About = C;
                }
            }
            string c = "UPDATE Books SET About='" + C + "' WHERE Name='" + A + "' AND AuthorName='" + B + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
        public void CHPrice(string A, string B, double C)
        {
            foreach (Book i in l)
            {
                if (i.Name == A && i.Author == B)
                {
                    i.price = C;
                }
            }
            string c = "UPDATE Books SET Price='" + C + "' WHERE Name='" + A + "' AND AuthorName='" + B + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
        public void CHImage_path(string A, string B, string C)
        {
            foreach (Book i in l)
            {
                if (i.Name == A && i.Author == B)
                {
                    i.ImagePath = C;
                }
            }
            string c = "UPDATE Books SET Image_Path='" + C + "' WHERE Name='" + A + "' AND AuthorName='" + B + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
    }
}
