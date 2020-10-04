using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityGroundline
{
    public class Policestation : Construction
    {

        public Policestation(int x, int y) : base(x, y)
        {
            this.ConstructionName = "A Police Station";
        }

        public Policestation() : base()
        {

        }

        public override void drawYourSelf(Graphics g)
        {
            g.DrawImage(Properties.Resources.police, new Rectangle(this.X, this.Y, 50, 50));
        }

        public override string getInfo()
        {
            return base.getInfo();
        }
    }
}