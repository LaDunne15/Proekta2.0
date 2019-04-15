using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekta2._0
{

    public interface IDiscount
    {
        void ExecuteDiscount(string A,string B,double C);
    }

    public class JustDiscount : IDiscount
    {
        public void ExecuteDiscount(string A,string B,double C)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Proekta_2;Integrated Security=True";
            string c = "UPDATE Books SET Discount_Rate=" + (C + "").Replace(",", ".") + " WHERE Name='" + A + "' AND AuthorName ='"+B+"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
    }

    public class DiscountByAuthor : IDiscount
    {
        public void ExecuteDiscount(string A, string B, double C)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Proekta_2;Integrated Security=True";
            string c = "UPDATE Books SET Discount_Rate=" + (C+"").Replace(",",".") + " WHERE AuthorName ='" + B + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }

    }

    public class DiscountPromocode : IDiscount
    {
        public void ExecuteDiscount(string A, string B, double C)
        {
            DateTime dt = DateTime.Now;
            string b=dt.Year+"-"+dt.Month+"-"+dt.Day;
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Proekta_2;Integrated Security=True";
            string c = "INSERT INTO  Promocode (NameProm,EndTime) VALUES ('" + A+"','"+b+"')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
    }

    public class RemoveDiscount : IDiscount
    {
        public void ExecuteDiscount(string A, string B, double C)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Proekta_2;Integrated Security=True";
            string c = "UPDATE Books SET Discount_Rate=1";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
    }

    public class Discount
    {
        public IDiscount ContextStrategy { get; set; }

        public Discount(IDiscount _strategy)
        {
            ContextStrategy = _strategy;
        }

        public void ExecuteDiscount(string A,string B,double C)
        {
            ContextStrategy.ExecuteDiscount(A,B,C);
        }
    }
}
