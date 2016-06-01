using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace CheckoutKata042016
{
    public class Checkout
    {
        private int _total = 0;
        List<string>  basketitemsList = new List<string>();
        private List<Sku> priceList;

        public Checkout(List<Sku> list)
        {
            priceList = list;
        }

     public void Scan(string code)
        {
            basketitemsList.Add(code);
            _total += priceList.First(s => s.Code == code).ItemPrice;
           if (basketitemsList.Count(x => x == "A") == 3)
            {
                _total = _total - 30;
            }
            else if ((basketitemsList.Count(x => x == "B") == 2) || (basketitemsList.Count(x => x == "B") == 4))
            {
                _total = _total - 15;
            }
        }

        public void ShowTotalOn(IDisplay display)
        {
            display.show(_total);
        }
    }
}