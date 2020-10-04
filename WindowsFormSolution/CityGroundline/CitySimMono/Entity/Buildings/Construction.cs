using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CitySimMono.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CitySimMono.Entity.Buildings
{

    [Serializable]
    public abstract class Construction :IRender
    {
        //Fields

        private int _x;
        private int _y;
        private int _ConstructionId;
        //private string _ConstructionName;
        private System.Drawing.Rectangle _bounds;
        private int _constructionIndex;

        //Property

        public int PosX { get { return _x; } set { _x = value; } }
        public int PosY { get { return _y; } set { _y = value; } }
        public int TextureId { get; set; }
        public int ConstructionId { get; set; }
        public string ConstructionName { get; set; }
        public System.Drawing.Rectangle Bounds { get { return this._bounds; } set { this._bounds = value; } }
        public int ConstructionIndex { get { return this._constructionIndex; } set { this._constructionIndex = value; } }
  
        //Constructors

        public Construction(int xx, int yy)
        {
            Random rnd = new Random();
            this._ConstructionId = rnd.Next(1000, 9999);
            this._x = xx;
            this._y = yy;
            this._bounds = new System.Drawing.Rectangle(this._x, this._y, 50, 50);
        }

        public Construction(int xx, int yy,int index)
        {
            Random rnd = new Random();
            this._ConstructionId = rnd.Next(1000, 9999);
            this._constructionIndex = index;
            this._x = xx;
            this._y = yy;
            this._bounds = new System.Drawing.Rectangle(this._x, this._y, 50, 50);
        }


        public Construction()
        {
            Random rnd = new Random();
            this._ConstructionId = rnd.Next(1000, 9999);
            this._x = 0;
            this._y = 0;
            this._bounds = new System.Drawing.Rectangle();
        }
        public virtual string getInfo()
        {
            string info = " ";
            info += "|Index: " + this.ConstructionIndex;
            info += " |X: " + this._x + " Y: " + this._y;
            info += " |Cell Construction ID: " + this._ConstructionId;
            info += " |Cell Construction Name: " + this.ConstructionName;
            return info;
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}