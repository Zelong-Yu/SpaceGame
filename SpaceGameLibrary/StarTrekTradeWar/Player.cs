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

        public double Age { get => this._age; set => this._age = value; }
        public decimal Money { get => this._money; set => this._money = value; }
        public double Fuel { get => this._fuel; set => this._fuel = value; }

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
            var distance = location.DistanceTo(destination);
            var speed = Utility.WarpSpeedToLightSpeed(warpSpeed);
            var fuelConsumptionPerLY = Utility.WarpSpeedToFuelConsumptionPerLY(warpSpeed);

            _age += distance / speed;

            _fuel -= fuelConsumptionPerLY * distance;

            this.location = destination;
        }

    }
}
