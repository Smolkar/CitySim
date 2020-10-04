using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CitySimMono.Graphics
{
    public static class Assets
    {
        //Constructions
        public static Tile EmptySpot;
        public static Tile Road;
        public static Tile CursorNormal;
        public static Tile CursorActive;
        public static Tile PoliceStation;
        public static Tile ShopHouse;
        public static Tile ResidenceHouse;
        public static Tile CivilCar;
        public static Tile TrafficLight_Green;
        public static Tile TrafficLight_Yellow;
        public static Tile TrafficLight_Red;
        public static Tile Hospital;
        public static Tile FireDepartment;
        public static Tile WorkBuilding;

        //console
        //public static Tile ConsoleTile;
        public static void LoadAssets(ContentManager content)
        {
            // When you create a tile give:
            // 1. Texture with content.Load - Texture2D
            // 2. ID - Integer
            // 3. IsSolid - Boolean (optional)


            Road = new Tile(content.Load<Texture2D>("road"),0);
            EmptySpot = new Tile(content.Load<Texture2D>("box"), 1);
            CursorNormal = new Tile(content.Load<Texture2D>("mouse"), 2);
            CursorActive = new Tile(content.Load<Texture2D>("mouse_click"),3);
            PoliceStation = new Tile(content.Load<Texture2D>("Textures/Buildings/police"),4);
            // TODO: Find asset
            ShopHouse = new Tile(content.Load<Texture2D>("Textures/Buildings/house-icon"),5);
            ResidenceHouse = new Tile(content.Load<Texture2D>("Textures/Buildings/house-icon"), 6);
            CivilCar = new Tile(content.Load<Texture2D>("Textures/Cars/civilian_car_1_g"), 7);
            TrafficLight_Green = new Tile(content.Load<Texture2D>("Textures/Buildings/Traffic_Green"), 8);
            TrafficLight_Yellow= new Tile(content.Load<Texture2D>("Textures/Buildings/Traffic_Yellow"), 9);
            TrafficLight_Red = new Tile(content.Load<Texture2D>("Textures/Buildings/Traffic_Red"), 10);
            Hospital = new Tile(content.Load<Texture2D>("Textures/Buildings/hospital"), 11);
            FireDepartment = new Tile(content.Load<Texture2D>("Textures/Buildings/nuclear_plant"), 12);
            // TODO: Find asset
            WorkBuilding = new Tile(content.Load<Texture2D>("Textures/Buildings/house-icon"), 13);

            //console
            //ConsoleTile = new Tile(content.Load<Texture2D>("Textures/Console"), 16);

            // Info
            //BaligoConsole.WriteLine("All assets loaded !", Color.Magenta);
            //BaligoConsole.WriteLine("=======", Color.Yellow);
            //BaligoConsole.WriteLine("All assets loaded !", Color.Magenta);
            //BaligoConsole.WriteLine("=======", Color.Yellow);
        }

        public static Texture2D GetTextureById(int id)
        {
            switch (id)
            {
                case 0:
                    return Road.Texture;
                case 1:
                    return EmptySpot.Texture;
                case 2:
                    return CursorNormal.Texture;
                case 3:
                    return CursorActive.Texture;
                case 4:
                    return PoliceStation.Texture;
                case 5:
                    return ShopHouse.Texture;
                case 6:
                    return ResidenceHouse.Texture;
                case 7:
                    return CivilCar.Texture;
                case 8:
                    return TrafficLight_Green.Texture;
                case 9:
                    return TrafficLight_Yellow.Texture;
                case 10:
                    return TrafficLight_Red.Texture;
                case 11:
                    return Hospital.Texture;
                case 12:
                    return FireDepartment.Texture;
                case 13:
                    return WorkBuilding.Texture;
            }
            return EmptySpot.Texture;
        }
    }
}
