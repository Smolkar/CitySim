using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CitySimMono.Entity.Custom_Mouse;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using CitySimMono.Graphics;
using CitySimMono.Input;
using CitySimMono.Graphics;

namespace CitySimMono.Entity.Buildings
{
    public class EmptySpot : Construction , IRender
    {
        //TypeConstructions

        public IRender CurrentEmptySpot;

        //Sprite Sheet
        //protected Texture2D ConstructionTexture;

        //Mouse Position
        public MouseState MousePosition { get; set; }
        //public Texture2D Texture { get; set; }

        public System.Drawing.Rectangle CollisionBox;
      

        public EmptySpot(int xx, int yy) : base(xx,yy)
        {
            // Box = content.Load<>
            this.TextureId = 1;
            //this.Bounds = new Rectangle(0,0, Texture.Width, Texture.Height);
        }

        public EmptySpot(int xx, int yy,int index) : base(xx, yy,index)
        {
            // Box = content.Load<>
            this.TextureId = 1;
            //this.Bounds = new Rectangle(0,0, Texture.Width, Texture.Height);
        }

        public override string getInfo()
        {
            return base.getInfo();
        }

        

        public void Update(GameTime gmaTime)
        {
            if(CurrentEmptySpot != null)
                CurrentEmptySpot.Update(gmaTime);

        }

//        public void Draw(SpriteBatch spriteBatch)
//        {
//            spriteBatch.Draw(Texture, new Vector2(X, Y), null, Color.White);
//        }

        public void Change(IRender construction)
        {
            CurrentEmptySpot = construction;
            TextureId = CurrentEmptySpot.TextureId;
        }
        

        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}