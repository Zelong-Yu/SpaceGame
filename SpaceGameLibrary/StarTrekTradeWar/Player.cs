using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekTradeWar
{
    [Serializable]
    public class Player
    {
        double _age;
        decimal _money;
        double _fuel;
        bool dead;

        public ILocation location;
        public List<Item> Inventory = new List<Item>();

        public double Age { get => this._age; set => this._age = value; }
        public decimal Money { get => this._money; set => this._money = value; }
        public double Fuel { get => this._fuel; set => this._fuel = value; }

        public Player()
        {
            this.location = new Planet();
            this._age = 20;
            this._money = 1000;
            this._fuel = 100;
            this.dead = false;
        }
        public Player(ILocation location, double age = 20, Decimal money = 1000, double fuel = 100)
        {
            this.location = location;
            this._age = age;
            this._money = money;
            this._fuel = fuel;
            this.dead = false;
        }

        public void TravelTo(ILocation destination, double warpSpeed)
        {
            double distance, speed;
            TravelEstimate(destination, warpSpeed, out distance, out speed, out double TimeNeed, out double FuelNeed);

            _age += TimeNeed;

            _fuel -= FuelNeed;

            this.location = destination;
        }

        public void TravelEstimate(ILocation destination, double warpSpeed, out double distance, 
            out double speed,  out double TimeNeed, out double FuelNeed)
        {
            distance = location.DistanceTo(destination);
            speed = Utility.WarpSpeedToLightSpeed(warpSpeed);
            double fuelConsumptionPerLY = Utility.WarpSpeedToFuelConsumptionPerLY(warpSpeed);
            TimeNeed = distance / speed;
            FuelNeed = fuelConsumptionPerLY * distance;

        }

        public void BuyItem(Item item)
        {
            _money -= location.CostOf(item);
            Inventory.Add(item);
        }

        public void SellItem(Item item)
        {
            _money += location.CostOf(item);
            Inventory.Remove(item);
        }
    }
}
