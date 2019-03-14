using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGameLibrary
{
    public class Map
    {
        int[,] MapGrid;
        List<ILocatable> ObjectsOnMap;
        public Map()
        {
            MapGrid = new int[10, 10];
            ObjectsOnMap = new List<ILocatable>();


            //ObjectOnMap = ObjectToBeAdded;
        }

        public void Update(List<ILocatable> L)
        {
            foreach (var item in L)
            {
                MapGrid[item.GetY(), item.GetX()] = item.GetId();
            }
            ObjectsOnMap = L;

        }

        public void Update()
        {
            MapGrid = new int[10, 10];
            foreach (var item in ObjectsOnMap)
            {
                MapGrid[item.GetY(), item.GetX()] = item.GetId();
            }

        }

        public bool Register(ILocatable item)
        {
            if (!isOccupied(item.GetX(), item.GetY()))
            {
                MapGrid[item.GetY(), item.GetX()] = item.GetId();
                ObjectsOnMap.Add(item);
                return true;
            }
            else return false;
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
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(MapGrid[i, j].ToString() + ' ');
                }
                Console.Write("\n");
            }
            
        }

         
        
        
    }
}
