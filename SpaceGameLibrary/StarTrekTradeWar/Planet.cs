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

        List<(Item, decimal)> itemMarkUps= new List<(Item, decimal)>();

        public double X { get => this._x; set => this._x = value; }
        public double Y { get => this._y; set => this._y = value; }
        public string Name { get => this._name; set => this._name = value; }
        public string Description { get => this._description; set => this._description = value; }
        List<(Item, decimal)> ILocation.ItemMarkUps { get => this.itemMarkUps; set => this.itemMarkUps =value; }

        //List of mark up factors with each item on the planet

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
            this.itemMarkUps = items;
        }

        public double DistanceTo(ILocation otherLocation)
        {
            var left = Math.Pow(this.X - otherLocation.X, 2);
            var right = Math.Pow(this.Y - otherLocation.Y, 2);
            return Math.Sqrt(left + right);
        }

        public decimal CostOf(Item item)
        {
            decimal itemMarkUp = (from e in itemMarkUps
                             where e.Item1.Name == item.Name
                             select e.Item2).FirstOrDefault();
            //If the planet doesn't have Mark up rate set it to 1.
            if (itemMarkUp == 0M) itemMarkUp = 1M;
            //price fluation 80% to 120%
            Random rnd = new Random();
            int num = rnd.Next(80,120);
            itemMarkUp *= (decimal)num / 100;
            return item.Price * itemMarkUp;
            
        }
    }
}
