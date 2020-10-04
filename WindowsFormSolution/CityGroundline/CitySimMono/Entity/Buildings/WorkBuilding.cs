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
    public class WorkBuilding : Construction, IRender
    {

        public WorkBuilding(int x, int y) : base(x, y)
        {
            this.ConstructionName = "A Residence House";
            TextureId = 13;
        }

        public WorkBuilding() : base()
        {

        }


        public override string getInfo()
        {
            return base.getInfo();
        }

        public void Update(GameTime gmaTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}