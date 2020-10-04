using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CityGroundline
{
    public class PoliceVehicle : Vehicle , IVehicle
    {
        public PoliceVehicle(int xx, int yy) : base(xx, yy)
        {
            this.Name = "A police car";
        }

        public PoliceVehicle(Construction spawnBuilding) : base(spawnBuilding)
        {
            this.Name = "A police car";
        }

        public override void drawYourSelf(Graphics g)
        {
            g.DrawImage(Properties.Resources.police_car_2, this.X-16, this.Y-16);
        }

        
    }
}