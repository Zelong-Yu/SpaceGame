using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekTradeWar
{
    [Serializable]
    class Item : IPricable
    {
        string _name;
        string _description;
        decimal _price;
        public string Name { get => this._name; set => this._name = value; }
        public string Description { get => this._description; set => this._description = value; }
        public decimal Price { get => this._price; set => this._price = value; }

        public Item()
        {
            this._name = "Default Item";
            this._description = "Default Description";
            this._price = 0;
        }

        public Item(string name, decimal price, string description = "" )
        {
            _name = name;
            _description = description;
            _price = price;
        }
    }
}
