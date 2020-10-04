using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityGroundline
{
    public class ShopHouse : Construction
    {

        public ShopHouse(int x, int y) : base(x, y)
        {
            this.ConstructionName = "A Shop House";
        }

        public ShopHouse() : base()
        {

        }

        public override void drawYourSelf(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override string getInfo()
        {
            return base.getInfo();
        }
    }
}