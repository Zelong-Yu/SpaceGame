using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGameLibrary
{
    class Map
    {
        int[,] MapGrid;
        List<Ilocatable> ObjectOnMap;
        public Map(List<Ilocatable> ObjectToBeAdded)
        {
            MapGrid = new int[10, 10];
            ObjectOnMap = ObjectToBeAdded;
        }

        public void Update(List<Ilocatable> L)
        {
            foreach (var item in L)
            {
                MapGrid[item.GetY(), item.GetX()] = item.GetId();
            }
            ObjectOnMap = L;

        }

        public bool isOccupied(int x, int y)
        {
            if (MapGrid[y, x] != 0)
            {
                return true;
            }
            else return false;
        }

        public void DisplayMap()
        {
            foreach (int[,] array in MapGrid)
            {

            }
        }

         
        
        
    }
}
