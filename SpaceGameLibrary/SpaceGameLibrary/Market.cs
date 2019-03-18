using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGameLibrary
{
    public class Market
    {
        public string MarketName { get; set; }
        public string MarketCurrency { get; set; }
        public double GoodInventory { get; set; }
        public double GoodSale { get; set; }

        public void DisplayMarket()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Market Name: "+ MarketName);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Market Currency: "+MarketCurrency);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Good Inventory: "+MarketCurrency+GoodInventory);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Good Sale: "+GoodSale);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");



        }
    }
}
