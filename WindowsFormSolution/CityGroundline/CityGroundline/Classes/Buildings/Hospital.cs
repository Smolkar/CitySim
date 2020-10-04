using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CityGroundline
{
    public class Hospital : Construction
    {
        public Hospital(int x, int y) : base(x, y)
        {
            this.ConstructionName = "A Hospital";
        }

        public Hospital() : base()
        {

        }

        public override void drawYourSelf(Graphics g)
        {
            g.DrawImage(Properties.Resources.hospital, new Rectangle(this.X, this.Y, 50, 50));
        }

        public override string getInfo()
        {
            return base.getInfo();
        }
    }
}