using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekta2._0
{
    class BasketBook
    {
        List<Book> books = new List<Book>() { };
        bool promocode = false;

        public BasketBook()
        {

        }

        public int getCount()
        {
            return books.Count-1;
        }
        public void AddBook(Book a)
        {
            books.Add(a);
        }
        public void DeleteBook(Book a)
        {
            books.Remove(a);
        }
        public void DeleteBook(int a)
        {
            books.RemoveAt(a);
        }
        public void setPromocode()
        {
            promocode = true;
        }
        public double getSumm()
        {
            double s = 0;
            foreach(var i in books)
            {
                s += i.price * i.discount;
            }
            if (promocode)
                return s * 0.9;
            else
                return s;
        }
        public Book getBookAt(int a)
        {
            return books.ElementAt(a);
        }
        public List<Book> getlist()
        {
            return books;
        }

    }
}
