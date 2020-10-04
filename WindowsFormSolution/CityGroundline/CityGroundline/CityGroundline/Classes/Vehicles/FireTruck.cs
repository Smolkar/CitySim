using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CityGroundline
{
    public class FireTruck : Vehicle
    {
        public FireTruck(int xx, int yy) : base(xx, yy)
        {
            this.Name = "A fire truck";
        }

        public FireTruck(Construction spawnBuilding) : base(spawnBuilding)
        {
            this.Name = "A fire truck";
        }

        public override void drawYourSelf(Graphics g)
        {
            g.DrawImage(Properties.Resources.fire_truck, this.X - 16, this.Y - 16);
            //g.FillRectangle(Brushes.Black, this.X, this.Y,10,10); //this one is for testing
        }
    }
}