using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CityGroundline
{
    public class NuclearPlant : Construction
    {
        public NuclearPlant(int x, int y) : base(x, y)
        {
            this.ConstructionName = "A NuclearPlant";
        }

        public NuclearPlant() : base()
        {

        }

        public override void drawYourSelf(Graphics g)
        {
            g.DrawImage(Properties.Resources.nuclear_plant, new Rectangle(this.X, this.Y, 50, 50));
        }

        public override string getInfo()
        {
            return base.getInfo();
        }
    }
}