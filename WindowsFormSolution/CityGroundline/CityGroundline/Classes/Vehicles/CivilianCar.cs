using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CityGroundline
{
    public class CivilianVehicle : Vehicle , IVehicle
    {
        public CivilianVehicle(int xx, int yy) : base(xx, yy)
        {
            this.Name = "A civilian car";
        }

        public CivilianVehicle(Construction spawnBuilding) : base(spawnBuilding)
        {
            this.Name = "A civilian car";
        }

        public override void drawYourSelf(Graphics g)
        {
            g.DrawImage(Properties.Resources.fire_truck, this.X - 13, this.Y - 13);
        }

        //public  void drawYourSelf(Graphics g)
        //{
        //      g.DrawImage(Properties.Resources.civilian_car_1_b,this.X-16,this.Y-16);
        //    //g.FillRectangle(Brushes.Black, this.X, this.Y,10,10); //this one is for testing
        //}
    }
}