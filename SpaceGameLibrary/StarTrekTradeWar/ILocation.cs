using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekTradeWar
{
    public interface ILocation
    {
        double X { get; set; }
        double Y { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        double DistanceTo(ILocation otherLocation);
    }
}
