using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CityGroundline
{
    public class FireStation : Construction
    {
        public FireStation(int x, int y) : base(x, y)
        {
            this.ConstructionName = "A FireStation";
        }

        public FireStation() : base()
        {

        }

        public override void drawYourSelf(Graphics g)
        {
            g.DrawImage(Properties.Resources.fire_station, new Rectangle(this.X, this.Y, 50, 50));
        }

        public override string getInfo()
        {
            return base.getInfo();
        }
    }
}