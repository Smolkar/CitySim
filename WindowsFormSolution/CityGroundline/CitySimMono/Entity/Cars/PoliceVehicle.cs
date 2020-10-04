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
    public class PoliceVehicle : Vehicle , IRender
    {
        public PoliceVehicle(int xx, int yy, City city) : base(xx, yy, city)
        {
            this.Name = "A police car";
        }

        public PoliceVehicle(Construction spawnBuilding) : base(spawnBuilding)
        {
            this.Name = "A police car";
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
