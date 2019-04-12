using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekta2._0
{
    class Account
    {
        public string Name;//Нік співробітника
        public string Login;//Логін співробітника
        public string password;//пароль співробітника
        public int count_selled=0;//кількість проданих книг
        public bool isAdmin;//чи є адміністратор
        public Account(string Nic, string Log, string pass,int count,bool isadmin)
        {
            Name = Nic;
            Login = Log;
            password = pass;
            count_selled = count;
            isAdmin = isadmin;
        }
        public Account(Account l)
        {
            this.Name = l.Name;
            this.Login = l.Login;
            this.password = l.password;
            this.count_selled = l.count_selled;
            this.isAdmin = l.isAdmin;
        }
        public Account(string Nic, string Log, string pass)
        {
            Name = Nic;
            Login = Log;
            password = pass;
            count_selled = 0;
            isAdmin = false;
        }
        public void ChangePass(string A)
        {
            password = A;
        }
        public void ChangeLogin(string A)
        {
            Login = A;
        }
        public void AddOne()
        {
            count_selled++;
        }

    }
}
