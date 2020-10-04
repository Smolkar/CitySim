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
    public class Policestation : Construction, IRender
    {

        public Policestation(int x, int y) : base(x, y)
        {
            this.ConstructionName = "A Police Station";
            TextureId = 4;
        }

        public Policestation() : base()
        {

        }

       

        public override string getInfo()
        {
            return base.getInfo();
        }

        public void Update(GameTime gmaTime)
        {
            //TODO: Spawn cars 
        }

//        public void Draw(SpriteBatch spriteBatch)
//        {
//            spriteBatch.Draw(Texture, new Vector2(X,Y), Bounds, Color.White);
//        }

        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}