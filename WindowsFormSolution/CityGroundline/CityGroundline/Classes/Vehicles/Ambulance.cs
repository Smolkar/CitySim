using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CityGroundline
{
    public class Ambulance : Vehicle
    {
        public Ambulance(int xx, int yy) : base(xx, yy)
        {
            this.Name = "A ambulance";
        }

        public Ambulance(Construction spawnBuilding) : base(spawnBuilding)
        {
            this.Name = "A ambulance";
        }

        public override void drawYourSelf(Graphics g)
        {
            g.DrawImage(Properties.Resources.ambulance_1, this.X - 16, this.Y - 16);
            //g.FillRectangle(Brushes.Black, this.X, this.Y,10,10); //this one is for testing
        }
    }
}