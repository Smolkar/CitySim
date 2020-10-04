using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CityGroundline
{
    public class EmptySpot : Construction
    {
        public EmptySpot(int xx, int yy) : base(xx, yy)
        {
            this.ConstructionName = " A empty spot ";
        }

        public EmptySpot() : base()
        {

        }

        public override void drawYourSelf(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.White), new Rectangle(this.X, this.Y, 50, 50));
            g.DrawString(this.ConstructionIndex.ToString(), new Font("Impact", 19), Brushes.Gray, new Rectangle(this.X, this.Y, 50, 50));
        }

        public override string getInfo()
        {
            return base.getInfo();
        }
    }
}