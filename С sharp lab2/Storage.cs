using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_sharp_lab2
{
    class Storage
    {
        public List<Product> storage = new List<Product>();
        

        public int Cashbox { get; set; }

        public Storage(int cash)
        {
            Cashbox = cash;
        }

    }
}
