using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityGroundline
{
    public class ResidenceHouse : Construction
    {

        public ResidenceHouse(int x, int y) : base(x, y)
        {
            this.ConstructionName = "A Residence House";
        }

        public ResidenceHouse() : base()
        {

        }

        public override void drawYourSelf(Graphics g)
        {
            g.DrawImage(Properties.Resources.house_icon, new Rectangle(this.X, this.Y, 50, 50));
        }

        public override string getInfo()
        {
            return base.getInfo();
        }
    }
}