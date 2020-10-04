using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CitySimMono.Graphics;
namespace CitySimMono.Entity.Buildings
{
    

    public class TrafficLight : Road
    {
        //Properties 
        public enum Traffic_lightstates { Green, Yellow, Red };
        public const int LightDuration = 5000;
        public Traffic_lightstates State { get; set; }
        //Event
        public delegate void StateChangedResult(Traffic_lightstates newState);
        public event StateChangedResult onStateChange;
        private bool _updateTimer;
        private float _timer;
        public TrafficLight(int x, int y) : base(x, y)
        {
            _timer = 5;
            _updateTimer = false;
            State = Traffic_lightstates.Green;
            TextureId = 8;
            //Bounds = new Rectangle(X, Y, Texture.Width, Texture.Height);
            LightChange();
        }
        private void LightChange()
        {
            
            switch (State)
            {
                case Traffic_lightstates.Green:
                    State = Traffic_lightstates.Yellow;
                    TextureId = 9;
                    break;
                case Traffic_lightstates.Yellow:
                    State = Traffic_lightstates.Red;
                    TextureId = 10;
                    break;
                case Traffic_lightstates.Red:
                    State = Traffic_lightstates.Green;
                    TextureId = 8;
                    break;

                default:
                    State = Traffic_lightstates.Green;
                    TextureId = 8;
                    break;
            }
        }
        public override void Update(GameTime gameTime)
        {
            if (_updateTimer)
            {
                _timer = 5;
                _updateTimer = false;
            } else if (_timer <= 0)
            {
                _updateTimer = true;
            }

            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _timer -= delta;
            if(_timer <= 0)
            {
                LightChange();
            }
        }
       
    }
}
