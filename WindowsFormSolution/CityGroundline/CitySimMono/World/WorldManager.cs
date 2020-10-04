using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CitySimMono.World
{
    class WorldManager
    {
        public static Dictionary<string, World> Maps;
        private static string currentMap;
        //All of the maps
        public static World map1;
        public static void Init()
        {
            Maps = new Dictionary<string, World>();
            currentMap = "map_1";

          

            // Add the maps
            Maps.Add("map_1", map1);
            
        }
        public static void SetCurrentWorld(string nameOfMap)
        {
            currentMap = nameOfMap;
        }
        public static World GetCurrentWorld()
        {
            return Maps[currentMap];
        }


    }
}
