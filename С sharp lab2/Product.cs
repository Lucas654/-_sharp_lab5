using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_sharp_lab2
{
    class Product
    {

        public string NameProduct { get; set; }
        public int QuantityInStock { get; set; }
        public int Price { get; set; }
        public int PriceForPeople { get; set; }


        public Product(string Name, int Quantity, int Price, int PriceFP)
        {
            NameProduct = Name;
            QuantityInStock = Quantity;
            this.Price = Price;
            PriceForPeople = PriceFP;
        }

    }
}
