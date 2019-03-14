using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGameLibrary
{
    public class Star : ILocatable
    {
        public static int starCount = 0;
        int Id { get; set; }
        int x { get; set; }
        int y { get; set; }
        string name { get; set; }

        public Star(int x, int y,  int Id, string name = "star")
        {
            this.Id = Id;
            this.x = x;
            this.y = y;
            starCount++;
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
    }
}
