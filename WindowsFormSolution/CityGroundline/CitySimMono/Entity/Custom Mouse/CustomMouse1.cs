using CitySimMono.Graphics;
using CitySimMono.Input;
using CitySimMono.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CitySimMono.Entity.Custom_Mouse
{
    public static class CustomMouse1
    {
        public static void Draw(SpriteBatch spriteBatch)
        {
            int currentX = Mouse.GetState().X;
            int currentY = Mouse.GetState().Y;

            spriteBatch.Draw(
                InputManager.LeftButtomDown
                    ? Assets.CursorActive.Texture
                    : Assets.CursorNormal.Texture, new Vector2(currentX, currentY), null, Color.White);
        }
    }
}
