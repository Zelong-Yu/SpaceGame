using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGameLibrary
{
    public interface ILocatable
    {
        int GetId();
        int GetX();
        int GetY();
        string GetName();
    }
}
