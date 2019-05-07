using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekta2._0
{
    class Seller : Account
    {
        public Seller(Account l):base(l)
            {
            }
        private static Seller instance;

        public static Seller getInstance(Account l)
        {
            if (instance == null)
                instance = new Seller(l);
            return instance;
        }
    }
}
