using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CitySimMono.Entity.Buildings;
using CitySimMono.Graphics;
using CitySimMono.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CitySimMono.Entity.Cars
{
    public class CivilianVehicle : Vehicle , IRender
    {
        //public Texture2D Texture { get; set; }
        public System.Drawing.Rectangle Bounds { get; set; }
        

        public CivilianVehicle(int xx, int yy, City city) : base(xx, yy,city)
        {
            TextureId = 7;
            this.Name = "A civilian car";
        }

        public CivilianVehicle(Construction spawnBuilding) : base(spawnBuilding)
        {
            
            TextureId = 7;
            this.Name = "A civilian Car";
            this.Bounds = new System.Drawing.Rectangle(0, 0, 32, 32);
        }

        public CivilianVehicle(Construction spawnBuilding, List<Construction> cityConstructions, List<Road> allCityRoads) : base(spawnBuilding,cityConstructions,allCityRoads)
        {

            TextureId = 7;
            this.Name = "A civilian Car";
            this.Bounds = new System.Drawing.Rectangle(0, 0, 32, 32);
        }


        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);

        }

        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}