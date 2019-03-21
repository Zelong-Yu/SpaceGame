using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekTradeWar
{
    [Serializable]
    class Planet : ILocation
    {
        string _name;
        string _description;

        double _x;
        double _y;
        public double X { get => this._x; set => this._x = value; }
        public double Y { get => this._y; set => this._y = value; }
        public string Name { get => this._name; set => this._name = value; }
        public string Description { get => this._description; set => this._description = value; }

        //List of mark up factors with each item on the planet
        public List<(Item, decimal)> ItemMarkUps= new List<(Item, decimal)>();

        public Planet()
        {
            this._name = "Default Planet";
            this._description = "Default Description";
            this._x = 0;
            this._y = 0;
        }
        public Planet(string name, string description, double x, double y, List<(Item, decimal)> items)
        {
            this._name = name;
            this._description = description;
            this._x = x;
            this._y = y;
            this.ItemMarkUps = items;
        }

        public double DistanceTo(ILocation otherLocation)
        {
            var left = Math.Pow(this.X - otherLocation.X, 2);
            var right = Math.Pow(this.Y - otherLocation.Y, 2);
            return Math.Sqrt(left + right);
        }

        public decimal Costof(Item item)
        {

            
        }
    }
}
