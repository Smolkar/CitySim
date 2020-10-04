using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using File = System.IO.File;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using CitySimMono.Entity;
using CitySimMono.Input;
using CitySimMono.Console;
using CitySimMono.Entity.Custom_Mouse;

namespace CitySimMono.World
{
   public class World
    {
        public static Node StartNode;
        public static Node FinishNode;
        public Tile[,] WorldData;
        private const int WorldWidth = 43;
        private const int WorldHeigth = 24;
        private const int TileSize = 32;
        private readonly string pathToWorld;
        //private const string DefaultPath = "./Content/Maps/";

        public static Texture2D Box;
        public static Texture2D Road;
        public static SpriteFont Font;
        private static int _count;
        public static Node[,] Board;

        //Debug Mode
        public static bool IsConsoleActive;
        public World(string worldName)
        {
            WorldData = new Tile[WorldHeigth, WorldWidth];
            //pathToWorld = DefaultPath + worldName;

            LoadWord();
        }
        public static void Init(ContentManager content)
        {
            _count = 7;
            Board = new Node[24, 36];

            for (int row = 0; row < 24; row++)
            {
                for (int col = 0; col < 36; col++)
                {
                    Board[row, col] = new Node(row, col);
                }
            }

            Box = content.Load<Texture2D>("box");
            Road = content.Load<Texture2D>("box");
            //Font = content.Load<SpriteFont>("Content/Id");
        }

        public void LoadWord()
        {
            string[] fileData = File.ReadLines(pathToWorld).ToArray();

            int row = 0;
            int col = 0;
            foreach (var currentRow in fileData)
            {
                foreach (var currentCol in currentRow.Split(' '))
                {
                    int a = int.Parse(currentCol);
                    WorldData[row, col] = new Tile(Tile.GetTile(a));
                    col++;
                }
                col = 0;
                row++;
            }



        }
        public static void Update()
        {
            if ((Mouse.GetState().LeftButton == ButtonState.Pressed ||
                Mouse.GetState().RightButton == ButtonState.Pressed) &&
                _count == 0)
            {
                UpdateBox();
                _count = 7;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F1) && _count == 0)
            {
                SetStartPoint();
                _count = 7;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F2) && _count == 0)
            {
                SetFinishPoint();
                _count = 7;
            }

            // =================
            if (_count - 1 >= 0)
                _count--;
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            // Draw the basic shape with white and black
            for (int row = 0; row < 24; row++)
            {
                for (int col = 0; col < 36; col++)
                {
                    spriteBatch.Draw(Box, new Vector2(col * 32, row * 32), new Rectangle(0, 0, 32, 32),
                        Board[row, col].IsSolid ? Color.Green : Color.White);
                }
            }
            //if (IsConsoleActive)
            //{
            //    BaligoConsole.Draw(spriteBatch);
            //}

            // Draw Text
            //for (int row = 0; row < 24; row++)
            //{
            //    for (int col = 0; col < 36; col++)
            //    {
            //        spriteBatch.DrawString(Font, Board[row, col].FCost == 0 ? "X" : Board[row, col].FCost.ToString(),
            //            new Vector2(col * 32 + 12, row * 32 + 11), Color.LightSlateGray);
            //    }
            //}


            // Draw Start
            if (StartNode != null)
            {
                spriteBatch.Draw(Box, new Vector2(StartNode.Col * 32, StartNode.Row * 32),
                    new Rectangle(0, 0, 32, 32), Color.Blue);
            }

            // Draw Finish
            if (FinishNode != null)
            {
                spriteBatch.Draw(Box, new Vector2(FinishNode.Col * 32, FinishNode.Row * 32),
                    new Rectangle(0, 0, 32, 32), Color.Blue);
            }
        }
        public static void SetStartPoint()
        {
            int col = Mouse.GetState().X / 32;
            int row = Mouse.GetState().Y / 32;

            if (row >= 0 && row < 24 && col >= 0 && col < 36)
            {
                if (Board[row, col].IsSolid == false)
                {
                    if (row >= 0 && row < 24)
                    {
                        if (col >= 0 && col < 36)
                        {
                            StartNode = new Node(row, col);
                            //Console.WriteLine("New start point");
                        }
                    }
                }
                else
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("Invalid Start Node!");
                    //Console.ForegroundColor = ConsoleColor.White;
                }

                //if (StartNode != null && FinishNode != null)
                //{
                //    PathFinding.FindPath(StartNode, FinishNode);
                //}
            }
        }

        public static void SetFinishPoint()
        {
            int col = Mouse.GetState().X / 32;
            int row = Mouse.GetState().Y / 32;

            if (row >= 0 && row < 24 && col >= 0 && col < 36)
            {
                if (Board[row, col].IsSolid == false)
                {
                    if (row >= 0 && row < 24)
                    {
                        if (col >= 0 && col < 36)
                        {
                            FinishNode = new Node(row, col);
                            //Console.WriteLine("New Finish Node");
                        }
                    }
                }
                else
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("Invalid Finish Node!");
                    //Console.ForegroundColor = ConsoleColor.White;
                }

                //if (StartNode != null && FinishNode != null)
                //{
                //    PathFinding.FindPath(StartNode, FinishNode);
                //}
            }
        }
        public static void UpdateBox()
        {
            int col = Mouse.GetState().X / 32;
            int row = Mouse.GetState().Y / 32;

            if (row >= 0 && row < 24 && col >= 0 && col < 36)
            {
                if (row >= 0 && row < 24)
                {
                    if (col >= 0 && col < 36)
                    {
                        Board[row, col].IsSolid = !Board[row, col].IsSolid;
                        //Console.WriteLine("Pressed");
                    }
                }

                //if (StartNode != null && FinishNode != null)
                //{
                //    PathFinding.FindPath(StartNode, FinishNode);
                //}
            }
        }
    }
}
