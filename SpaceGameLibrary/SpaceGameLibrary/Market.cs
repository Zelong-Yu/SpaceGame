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
            Console.WriteLine("\t\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\t\tMarket Name: "+ MarketName);
            Console.WriteLine("\t\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\t\tMarket Currency: "+MarketCurrency);
            Console.WriteLine("\t\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\t\tGood Inventory: "+MarketCurrency+GoodInventory.ToString("F"));
            Console.WriteLine("\t\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\t\tGood Sale: "+GoodSale);
            Console.WriteLine("\t\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");



        }
    }
}
