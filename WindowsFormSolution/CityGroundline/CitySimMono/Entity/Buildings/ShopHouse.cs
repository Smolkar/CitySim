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
    public class ShopHouse : Construction, IRender
    {

        public ShopHouse(int x, int y) : base(x, y)
        {
            this.ConstructionName = "A Shop House";
            TextureId = 5;
        }

        public ShopHouse() : base()
        {

        }

        

        public override string getInfo()
        {
            return base.getInfo();
        }

        public  void Update(GameTime gmaTime)
        {

        }

        public  void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public  void Init()
        {
            throw new NotImplementedException();
        }
    }
}