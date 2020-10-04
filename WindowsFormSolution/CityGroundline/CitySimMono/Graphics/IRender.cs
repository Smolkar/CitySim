using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CitySimMono.Graphics;
using CitySimMono.Entity.Buildings;

namespace CitySimMono.Graphics
{
    public interface IRender
    {
        //Texture2D Texture { get; set; }
        int TextureId { get; set; }
        int PosX { get; set; }
        int PosY { get; set; }
        System.Drawing.Rectangle Bounds { get; set; }
        void Update(GameTime gameTime);
        //void Draw(SpriteBatch spriteBatch);
        void Init();
    }
}
