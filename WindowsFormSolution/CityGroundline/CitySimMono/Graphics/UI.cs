using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CitySimMono.Graphics
{
    public static class UI
    {
        public static bool IsUiActive;
        public static Texture2D Gray;
        public static SpriteFont Font2;

        public static void Init(ContentManager content)
        {
            Gray = content.Load<Texture2D>("Gray");
            Font2 = content.Load<SpriteFont>("Font2");
            IsUiActive = true;
        }

        public static void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                IsUiActive = false;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Gray, new Vector2(200, 134), new Rectangle(0, 0, 750, 380), Color.Black);

            spriteBatch.DrawString(
                Font2,
                "  Press [ F1 ] to place a TrafficLights !",
                new Vector2(210, 150),
                Color.Magenta);

            spriteBatch.DrawString(
                Font2,
                "    Press [ F2 ] to place a House !",
                new Vector2(210, 250),
                Color.Magenta);
            spriteBatch.DrawString(
                Font2,
                "    Press [ F3 ] to place a Policedep!",
                new Vector2(210, 350),
                Color.Magenta);
            spriteBatch.DrawString(
                Font2,
                " Use the [ Mouse Buttons ] to build roads !",
                new Vector2(210, 450),
                Color.Magenta);

            spriteBatch.DrawString(
                Font2,
                "Press [ ENTER ]",
                new Vector2(420, 450),
                Color.LimeGreen);
        }
    }
}
