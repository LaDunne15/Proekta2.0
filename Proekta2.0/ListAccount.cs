﻿using System;
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
                        l.Add(new Account(Convert.ToString(x1), Convert.ToString(x2), Convert.ToString(x3),Convert.ToInt32(x4),Convert.ToBoolean(x5)));
                    }
                }
            }
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

        public void DellAcc(Account A)
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
    }
}