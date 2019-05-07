using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekta2._08
{
    abstract class Account
    {
        public string Name { get; set; } //Нік співробітника
        public string Login { get; set; } //Логін співробітника
        public string password { get; set; } //пароль співробітника
        public int count_selled { get; set; } //кількість проданих книг
        public bool isAdmin { get; set; } //чи є адміністратор
        public Account(string Nic, string Log, string pass, int count, bool isadmin)
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
        public virtual void ChangePass(string A)
        {
            password = A;
        }
        public virtual void ChangeLogin(string A)
        {
            Login = A;
        }
        public virtual void AddOne()
        {
            count_selled++;
        }
    }
    class ConcreteAccount : Account
    {
        public ConcreteAccount(string a, string b, string c, int d, bool e)
            : base(a,b,c,d,e)
        { }

        public ConcreteAccount(Account a)
            : base(a)
        { }

        public ConcreteAccount(string a, string b, string c)
            : base(a, b, c)
        { }
    }

    abstract class AccountDecorator : Account
    {
        protected Account pizza;
        public AccountDecorator(Account pizza) : base(pizza)
        {
            this.pizza = pizza;
        }
    }

    class Seller : AccountDecorator
    {
        public Seller(Account p)
            : base (p)
        { }
    }
    class Seller_Plus : AccountDecorator
    {
        public Seller_Plus(Account p)
            : base(p)
        { }
    }
    class Admin : AccountDecorator
    {
        public Admin(Account p)
            : base(p)
        { }
    }
}
