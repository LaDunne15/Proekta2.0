using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace Proekta2._0
{
    class ListAcc
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Proekta_2;Integrated Security=True";
        List<Account> l = new List<Account> { };
        public ListAcc(List<Account> f)
        {
            foreach (Account i in f)
                l.Add(i);
        }
        public ListAcc()
        {
            string c = "SELECT * FROM Accounts";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();

                if (DD.HasRows)
                {
                    while (DD.Read())
                    {
                        object x1 = DD.GetValue(0);
                        object x2 = DD.GetValue(1);
                        object x3 = DD.GetValue(2);
                        object x4 = DD.GetValue(3);
                        object x5 = DD.GetValue(4);
                        l.Add(new Account(Convert.ToString(x1).Trim(), Convert.ToString(x2).Trim(), Convert.ToString(x3).Trim(),Convert.ToInt32(x4),Convert.ToBoolean(x5)));
                    }
                }
            }
        }
        public List<Account> getList()
        {
            return l;
        }
        public int SearchAcc(string A, string B)//перевіряє, чи знайдений такий акаунт, якзо не знайдений, то повертвє -1
        {
            int Searched = -1;
            int j= 0;
            foreach(var i in l)
            {
                if (i.Login.Replace(" ", "") == A && i.password.Replace(" ", "") == B)
                {
                    Searched = j;
                }
                j++;
            }
            return Searched;
        }
        public int SearchAcc(string Login)//перевіряє, чи знайдений такий акаунт, якзо не знайдений, то повертвє -1
        {
            int Searched = -1;
            int j = 0;
            foreach (var i in l)
            {
                if (i.Login.Replace(" ", "") == Login)
                {
                    Searched = j;
                }
                j++;
            }
            return Searched;
        }
        public Account GetAccountByID(int a)
        {
            return l.ElementAt(a);
        }
        public void CHPass(string A, string B)
        {
            foreach (Account i in l)
            {
                if (i.password.Replace(" ", "") == A)
                    i.ChangePass(B);
            }
            string c = "UPDATE Accounts SET Password="+B+" WHERE Name='"+A+"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
        public void CHLogin(string A, string B)
        {
            foreach (Account i in l)
            {
                if (i.Login.Replace(" ", "") == A)
                    i.ChangeLogin(B);
            }
            string c = "UPDATE Accounts SET Login=" + B + " WHERE Name='" + A + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
        public void DelAcc(Account A)
        {
            string c = "DELETE  FROM Accounts WHERE Name='"+A.Name+"' AND Login='"+A.Login+"' AND Password='"+A.password+"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
            l.Remove(A);
        }
        public void AddAccount(Account a)
        {
            l.Add(a);
            string c = "INSERT INTO Accounts (Name,Login,Password,Count,isAdmin) VALUES ('" + a.Name + "','" + a.Login + "','" + a.password + "','" + 0 + "','False')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
        public void Sell(int a,Account b)
        {
            foreach (Account i in l)
            {
                if (i.Login==b.Login)
                {
                    int a1 = i.count_selled;
                    i.count_selled += a;
                    if(a1<500 && i.count_selled>=500)
                    {
                        MessageBox.Show(i.Name+", ви щойно продали понад 500 книг. Будь ласка, перезайдіть!");
                    }
                }
            }
            string c = "UPDATE Accounts SET Count=Count+" + a + " WHERE Name='" + b.Name + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
        public void setAdmin(int a)
        {
            foreach( var i in l)
            {
                i.isAdmin = false;
            }
            GetAccountByID(a).isAdmin = true;
            string c = "UPDATE Accounts SET isAdmin = 0 UPDATE Accounts set isAdmin = 1 where Login = '"+GetAccountByID(a).Login+"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();
            }
        }
    }
}
