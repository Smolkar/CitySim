using CitySimMono.Entity.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CitySimMono.Artifintel;
using CitySimMono.Entity.Cars;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using CitySimMono.Graphics;

namespace CitySimMono.World
{

    [Serializable]
    public class City 
    {
        //Fields
        //private List<EmptySpot> _myEmptySpots;

        #region winform

        private List<Construction> _myConstructions;
        private List<Road> _myRoads2;

        public List<Construction> MyConstructions { get { return this._myConstructions; } set { this._myConstructions = value; } }
        public List<Road> MyRoads2 { get { return this._myRoads2; } set { this._myRoads2 = value; } }
        #endregion

        private IRender[,] _myEmptySpots;
        private int _currentConsIndex;



        //Properties
        public int NumberOfRows { get; set; }
        public int NumberOfColums { get; set; }
        public int SquareSize { get; set; }

        public List<Vehicle> MyVehicles { get; set; }

        public List<Road> MyRoads { get; set; }

        public IRender[,] MyEmptySpots
        {
            get
            {
                return _myEmptySpots;
            }

            set
            {
                _myEmptySpots = value;
                foreach (IRender c in _myEmptySpots)
                {
                    if (c is Road)
                    {
                        MyRoads.Add((Road)c);
                    }
                }
            }
        }

        //public int CurrentConsIndex
        //{
        //    get
        //    {
        //        return _currentConsIndex;
        //    }
        //    set
        //    {
        //        if (value > 252)
        //        {
        //            this._currentConsIndex = 252;
        //        }
        //        else if (value < 0)
        //        {
        //            this._currentConsIndex = 0;
        //        }
        //        else
        //        {
        //            this._currentConsIndex = value;
        //        }
        //    }
        //}
        //public delegate void mouseActionHandler(int x, int y);

        //public delegate Construction constructionTypeHolder(int x, int y);

        //public constructionTypeHolder ConstructionTypeSetter;

        //public mouseActionHandler MouseMoveFunctios;

        //public mouseActionHandler MouseClickFunctions;

        public City()
        {
            NumberOfRows = 50;
            NumberOfColums = 26;
            SquareSize = 32;
            MyEmptySpots = new EmptySpot[NumberOfRows,NumberOfColums];

            MyConstructions = new List<Construction>();
            MyRoads2 = new List<Road>();

            MyRoads = new List<Road>();
            MyVehicles = new List<Vehicle>();
        }

        public void generatingCells() //generating and storing all the squares
        {

            for (int x = 0; x < NumberOfRows; x++) //maximum 22 squares can be placed in a colum |
            {
                
                for (int y = 0; y < NumberOfColums; y++) //maximum 46 squares can be placed in a row -
                {
                    #region
                    EmptySpot temp = new EmptySpot(x * SquareSize, y * SquareSize);
                    //temp.ConstructionIndex = coordinateToIndex(x, y); 
                    //MyEmptySpots.Add(temp);
                    //x += squareSize;
                    MyEmptySpots[x, y] = temp;
                    #endregion

                }
                //x =
            }

            for (int y = 0; y < NumberOfColums; y++) //maximum 22 squares can be placed in a colum |
            {

                for (int x = 0; x < NumberOfRows; x++) //maximum 46 squares can be placed in a row -
                {
                    int indexNr = Convert.ToInt32(coordinateToIndex(x * SquareSize, y * SquareSize));
                    EmptySpot tempEmp = new EmptySpot(x * SquareSize, y * SquareSize, indexNr);
                    MyConstructions.Add(tempEmp);

                }
                //x =
            }

            /*foreach (Cell c in _MyConstructions)
            {
                testRectangles.Add(new Rectangle(p, new Size(25, 25)));
            }*/

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Console.WriteLine(MyEmptySpots.Count);
            foreach (var myEmptySpot in MyEmptySpots)
            {
                
                //myEmptySpot.Draw(spriteBatch);
            }
        }

        public int? coordinateToIndex(int x, int y)
        {
            //550 1150 22 46
            if (x < 0 || y < 0)
            {
                return null;
            }
            int rowNr, coloumNr, index;
            rowNr = x / SquareSize;
            coloumNr = y / SquareSize;
            index = (coloumNr * NumberOfRows) + rowNr;
            if (index > NumberOfRows* NumberOfColums)
            {
                return null;
            }

            return index;
        }
        public List<int> getAdjacentRoadsIndex(int x, int y)
        {
            int row, coloum, index;
            List<int> adjacentRoads = new List<int>();
            row = x / 50;
            coloum = y / 50;
            index = (coloum * 23) + row;
            if (index > 252)
            {
                index = 252;
            }
            if (row == 0 || row == 22 || coloum == 0 || coloum == 10) // mouse at edge
            {
                if ((row == 0 && coloum == 0) || (row == 22 && coloum == 0) || (row == 0 && coloum == 10) || (row == 22 && coloum == 10)) // mouse at 4 corner of the grid map
                {
                    if (row == 0 && coloum == 0) // 1 top left corner
                    {
                        adjacentRoads.Add(index + 1);
                        adjacentRoads.Add(index + 23);
                    }

                    if (row == 22 && coloum == 0) // 2 top right corner
                    {
                        adjacentRoads.Add(index - 1);
                        adjacentRoads.Add(index + 23);
                    }

                    if (row == 0 && coloum == 10) // 3 bottom left corner
                    {
                        adjacentRoads.Add(index - 23);
                        adjacentRoads.Add(index + 1);
                    }

                    if (row == 22 && coloum == 10) // 4 bottom right corner
                    {
                        adjacentRoads.Add(index - 23);
                        adjacentRoads.Add(index - 1);
                    }

                }
                else//now its actual edge
                {
                    if (row == 0) // left vertical  edge
                    {
                        adjacentRoads.Add(index - 23);
                        adjacentRoads.Add(index + 1);
                        adjacentRoads.Add(index + 23);
                    }

                    if (row == 22) // right vertical  edge
                    {
                        adjacentRoads.Add(index - 23);
                        adjacentRoads.Add(index - 1);
                        adjacentRoads.Add(index + 23);
                    }

                    if (coloum == 0) // top horizontial edge
                    {
                        adjacentRoads.Add(index - 1);
                        adjacentRoads.Add(index + 23);
                        adjacentRoads.Add(index + 1);
                    }

                    if (coloum == 10) // bot horizontial edge
                    {
                        adjacentRoads.Add(index - 1);
                        adjacentRoads.Add(index - 23);
                        adjacentRoads.Add(index + 1);
                    }
                }

            }
            else //mouse not at border
            {
                adjacentRoads.Add(index - 23); //↑
                adjacentRoads.Add(index + 23); //↓
                adjacentRoads.Add(index - 1); //←
                adjacentRoads.Add(index + 1); //→
            }
            return adjacentRoads;
        }
        public List<int?> getAdjacentRoadsIndex2(int x, int y)
        {
            int offset = 32;

            List<int?> toBeReturn = new List<int?>();
            toBeReturn.Add(coordinateToIndex(x, y - offset)); //↑
            toBeReturn.Add(coordinateToIndex(x, y + offset)); //↓
            toBeReturn.Add(coordinateToIndex(x - offset, y)); //←
            toBeReturn.Add(coordinateToIndex(x + offset, y)); //→

            toBeReturn.RemoveAll(item => item == null);

            return toBeReturn;
        }

        private Vehicle getVehicleByIndex(int indexNr)
        {
            return MyVehicles[indexNr];
        }
        public Road getRandomDestination()
        {
            Random rr = new Random();
            int a = rr.Next(0, MyRoads.Count - 1);
            return MyRoads[a];
        }


        public IRender getCurrentRoad(float x, float y)
        {
            int offset = 32;


            int newX = Convert.ToInt32(Math.Floor(x / offset));
            int newY = Convert.ToInt32(Math.Floor(y / offset));

            Console.WriteLine("X ->>>>>> " + newX + "Y ->>>>>>>>" + newY);
            //            int a = coordinateToIndex(x, y);
            //            return (Road)MyEmptySpots[a];
            EmptySpot TESTING = MyEmptySpots[newX, newY] as EmptySpot;

            return TESTING.CurrentEmptySpot;
        }

    }
}