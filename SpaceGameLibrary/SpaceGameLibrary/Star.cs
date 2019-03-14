using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGameLibrary
{
    class Star : Ilocatable
    {
        int Id { get; set; }
        int x { get; set; }
        int y { get; set; }
        string name { get; set; }

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
