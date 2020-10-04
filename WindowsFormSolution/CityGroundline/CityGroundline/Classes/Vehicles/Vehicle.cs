using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityGroundline
{
    public abstract class Vehicle : IVehicle
    {
        private int _X;
        private int _Y;
        private AI _MyAI;
        private string _Name;
        private int _ID;

        public Vehicle(int xx, int yy)
        {
            Random rnd = new Random();
            this._X = xx;
            this._Y = yy;
            _MyAI = new AI();
            this._ID = rnd.Next(1000, 9999);
        }

        public Vehicle(Construction SpawnningConstruction)
        {
            Random rnd = new Random();
            this._X = SpawnningConstruction.X + 13;
            this._Y = SpawnningConstruction.Y + 13;
            _MyAI = new AI();
            this._ID = rnd.Next(1000, 9999);
        }

        public int X
        {
            get { return _X; }

            set { _X = value; }
        }

        public int Y
        {
            get { return _Y; }

            set { _Y = value; }
        }

        public AI MyAI
        {
            get { return _MyAI; }

            set { _MyAI = value; }
        }

        public string Name
        {
            get { return _Name; }

            set { _Name = value; }
        }

        public int ID
        {
            get { return _ID; }

            set { _ID = value; }
        }

        public virtual string getInfo()
        {
            string info = " ";
            info += "|ID: " + this._ID;
            info += " |Name: " + this._Name;
            info += " |X: " + this._X + " Y: " + this._Y;
            return info;
        }

        public abstract void drawYourSelf(Graphics g);
    }
}