using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGameLibrary
{
    public class Ship : ILocatable
    {
        public static int shipCount=0;
        int Id { get; set; }
        int x { get; set; }
        int y { get; set; }
        string name { get; set; }

        public Ship(int x, int y, string name="ship")
        {
            Id = 3;
            this.x = x;
            this.y = y;
            shipCount++;
        }
        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return name;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public bool Move(ILocatable Coord)
            {
                this.x = Coord.GetX();
                this.y = Coord.GetY();
                return true;
            }

         public bool Move(int x, int y, Map map)
         {
            if (!map.isOccupied(x, y))
            {
                this.x = x;
                this.y = y;
                map.Update();
                return true;
            }
            return false;
         }
    }
}
