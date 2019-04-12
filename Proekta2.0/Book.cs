using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekta2._0
{
    public class Book
    {
        public string Name, Author; //Назва книги і її автор
        public double price;// ціна книги
        public string About;// коротко про книгу
        public int Genre;// ID жанру
        public double discount;//коеф знижки
        public Book(string A, string B, double C, string D, int E,double F)
        {
            Name = A;
            Author = B;
            price = C;
            About = D;
            Genre = E;
            discount = F;
        }
    }
}
