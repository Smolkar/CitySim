using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CitySimMono.Entity.Buildings;
using CitySimMono.Entity.Cars;
using CitySimMono.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace CitySimMono.World
{
    public class SimulatorManager
    {
        private City _myCity;
        private EmptySpot _currentEmptySpot;
      

        public SimulatorManager(ContentManager content)
        {
            
        }

      


        public City MyCity { get; set; }



        

        public void emptyFunction(int x, int y)
        {

        }

        public Construction toRH(int x, int y) //set an empty spot to Residence house
        {
            ResidenceHouse rh = new ResidenceHouse(x, y);
            return rh;
        }

        public Construction toPS(int x, int y) //set an empty spot to Police station
        {
            Policestation ps = new Policestation(x, y);
            return ps;
        }
    }

 

}
