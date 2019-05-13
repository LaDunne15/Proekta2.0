using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekta2._0
{
    class Promocodedb
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Proekta_2;Integrated Security=True";
        public List<string> list = new List<string>() { };
        public Promocodedb()
        {
            string c = "Select A.NameProm from Promocode A Where DATEDIFF(day,a.EndTime,GETDATE())<=14";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(c, connection);
                SqlDataReader DD = command.ExecuteReader();

                if (DD.HasRows)
                {
                    while (DD.Read())
                    {
                        string x1 = DD.GetValue(0).ToString().Replace(" ","");
                        list.Add(x1);
                    }
                }
            }
        }
        public bool isChecked(string a)
        {
            bool b = false;
            foreach(var i in list)
            {
                if (i == a)
                    b = true;
            }
            return b;
        }
    }
}
