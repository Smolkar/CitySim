using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CitySimMono.Entity.Buildings;
using CitySimMono.Artifintel;
using CitySimMono.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CitySimMono.World;

namespace CitySimMono.Entity.Cars
{
    public abstract class Vehicle : IVehicle , IRender
    {
        #region
        #endregion


        //Fields
        private string _Name;
        private int _ID;
        public float speed;
        private System.Drawing.Rectangle _bounds;
        public Vector2 Velocity;
        List<IRender> objects;

        //Properties
        public int PosX { get; set; }

        public int PosY { get; set; }
        public int TextureId { get; set; }

        public AI MyAI { get; set; }

        public string Name { get; set; }

        public int ID { get; set; }
   
        public System.Drawing.Rectangle Bounds { get { return this._bounds; } set { this._bounds = value; } }

        private City _city;

        public Vehicle(int xx, int yy, City city)
        {
             
            Random rnd = new Random();
            this.PosX = xx;
            this.PosY = yy;
            this.MyAI = new AI();
            this._ID = rnd.Next(1000, 9999);
            Bounds = new System.Drawing.Rectangle(PosX, PosY, 32, 32);
            objects = new List<IRender>();
            
            this._city = city;

        }

        public Vehicle(Construction SpawnningConstruction)
        {
            Random rnd = new Random();
            this.PosX = SpawnningConstruction.PosX + 13;
            this.PosY = SpawnningConstruction.PosY + 13;
            this.MyAI = new AI();
            this._ID = rnd.Next(1000, 9999);
            objects = new List<IRender>();
            
        }

        public Vehicle(Construction SpawnningConstruction,List<Construction> cityConstructions,List<Road> allCityRoads)
        {
            Random rnd = new Random();
            this.Bounds = new System.Drawing.Rectangle(0, 0, 32, 32);
            this.PosX = SpawnningConstruction.PosX + 13;
            this.PosY = SpawnningConstruction.PosY + 13;
            this.MyAI = new AI(this, cityConstructions,allCityRoads);
            this._ID = rnd.Next(1000, 9999);
            objects = new List<IRender>();

        }


        public virtual string getInfo()
        {
            string info = " ";
            info += "|ID: " + this._ID;
            info += " |Name: " + this._Name;
            info += " |X: " + this.PosX + " Y: " + this.PosY;
            return info;
        }
       
     
        public void Update(GameTime gameTime)
        {
            MyAI.DO();
            //TRAFFICLIGHT CHECK
            //foreach (var o in objects)
            //{
            //    if (o == this)
            //        continue;

            //    if (o.Bounds.X + 32 > 0 && this.IsTouchingLeft(o)) ;
            //    //TODO STOP MOVEMENT
            //    if (o.Bounds.X - 32 < 0 && this.IsTouchingRight(o)) ;
            //    //TODO STOP MOVEMENT
            //    if (o.Bounds.Y + 32 > 0 && this.IsTouchingTop(o)) ;
            //    //TODO STOP MOVEMENT
            //    if (o.Bounds.Y - 32 < 0 && this.IsTouchingBottom(o)) ;
            //    //TODO STOP MOVEMENT
            //}

        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        private void FindWayPoints()
        {
//            EmptySpot temp = (_city.getCurrentRoad(X, Y) as EmptySpot);
//            temp.X
//            Road croad = new Road();
            Road croad = (Road)_city.getCurrentRoad(PosX, PosY);
            Road rDest = _city.getRandomDestination();
            MyAI.findAPath4(croad, rDest);
            MyAI.setWayPoints();
        }

        #region Collision
        protected bool IsTouchingLeft(IRender collisionObject)
        {
            
              return   Bounds.Right + 32 > collisionObject.Bounds.Left &&
                 Bounds.Left < collisionObject.Bounds.Left &&
                 Bounds.Bottom > collisionObject.Bounds.Top &&
                 Bounds.Top < collisionObject.Bounds.Bottom;
        }
        protected bool IsTouchingRight(IRender collisionObject)
        {

            return Bounds.Left + 32 < collisionObject.Bounds.Right &&
               Bounds.Right > collisionObject.Bounds.Right &&
               Bounds.Bottom > collisionObject.Bounds.Top &&
               Bounds.Top < collisionObject.Bounds.Bottom;
        }
        protected bool IsTouchingTop(IRender collisionObject)
        {

            return Bounds.Bottom + 32 > collisionObject.Bounds.Top &&
               Bounds.Top < collisionObject.Bounds.Top &&
               Bounds.Right > collisionObject.Bounds.Left &&
               Bounds.Left < collisionObject.Bounds.Right;
        }
        protected bool IsTouchingBottom(IRender collisionObject)
        {

            return Bounds.Top + 32 < collisionObject.Bounds.Bottom &&
               Bounds.Bottom > collisionObject.Bounds.Bottom &&
               Bounds.Right > collisionObject.Bounds.Left &&
               Bounds.Left < collisionObject.Bounds.Right;
        }
        #endregion
    }
}