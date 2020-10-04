using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityGroundline
{
    [Serializable]
    public abstract class Construction
    {
        private int _x;
        private int _y;
        private int _ConstructionId;
        private string _ConstructionName;
        private Rectangle _myRectangle;
        private int _ConstructionIndex;

        public Construction(int xx, int yy)
        {
            Random rnd = new Random();
            this._ConstructionId = rnd.Next(1000, 9999);
            this._x = xx;
            this._y = yy;
            this._myRectangle = new Rectangle(this._x, this._y, 50, 50);
        }

        public Construction()
        {
            Random rnd = new Random();
            this._ConstructionId = rnd.Next(1000, 9999);
            this._x = 0;
            this._y = 0;
            this._myRectangle = new Rectangle();
        }

        public int X { get { return _x; } set { _x = value; } }

        public int Y { get { return _y; } set { _y = value; } }

        public int ConstructionId
        {
            get
            {
                return this._ConstructionId;
            }

            set
            {
                this._ConstructionId = value;
            }
        }

        public string ConstructionName
        {
            get
            {
                return this._ConstructionName;
            }

            set
            {
                this._ConstructionName = value;
            }
        }

        public Rectangle MyRectangle
        {
            get
            {
                return _myRectangle;
            }

            set
            {
                _myRectangle = value;
            }
        }

        public int ConstructionIndex
        {
            get
            {
                return this._ConstructionIndex;
            }

            set
            {
                this._ConstructionIndex = value;
            }
        }

        public abstract void drawYourSelf(Graphics g);

        public virtual string getInfo()
        {
            string info = " ";
            info += "|Index: " + this._ConstructionIndex;
            info += " |X: " + this._x + " Y: " + this._y;
            info += " |Cell Construction ID: " + this._ConstructionId;
            info += " |Cell Construction Name: " + this.ConstructionName;
            return info;

        }

        /*public virtual Construction deepCopy()
        {
            Construction other
        }*/
    }
}