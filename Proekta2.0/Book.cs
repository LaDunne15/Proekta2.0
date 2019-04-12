using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekta2._0
{
    public class Book
    {
        public string Name { get; set; }
        public string Author {get;set;} //Назва книги і її автор
        public double price { get; set; } // ціна книги
        public string About { get; set; } // коротко про книгу
        public int Genre { get; set; } // ID жанру
        public double discount { get; set; } //коеф знижки
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
