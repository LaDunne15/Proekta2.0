using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekta2._0
{
    class BasketBook
    {
        public IBasketState State { get; set; }
        List<Book> books;
        public BasketBook(IBasketState ws)
        {
            State = ws;
            books = new List<Book>() { };
        }
        public void setPromocode()
        {
            State.setPromocode(this);
        }
        public double getSumm()
        {
            double s = 0;
            foreach (var i in books)
            {
                s += i.price * i.discount;
            }
            if (State.ishavediscount())
                return s * 0.9;
            else
                return s;
        }
        public Book getBookAt(int a)
        {
            return books[a - 1];
        }
        public List<Book> getlist()
        {
            return books;
        }
        public int getCount()
        {
            return books.Count;
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
    }

    interface IBasketState
    {
        void setPromocode(BasketBook basket);
        bool ishavediscount();
    }

    class BasketWithDiscount : IBasketState
    {
        public void setPromocode(BasketBook basket)
        {
            basket.State = new BasketWithDiscount();
        }
        public bool ishavediscount()
        {
            return true;
        }
    }
    class BasketWithoutDiscount : IBasketState
    {
        public void setPromocode(BasketBook basket)
        {
            basket.State = new BasketWithDiscount();
        }
        public bool ishavediscount()
        {
            return false;
        }
    }
}
