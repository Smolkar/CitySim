using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using CitySimMono.Entity.Buildings;
using CitySimMono.Entity.Cars;

namespace CitySimMono.Artifintel
{
    public class AI
    {
        #region
        private List<Construction> _myCityConstructions;
        private List<Road> _myCityRoads;
        private Vehicle _myVehicle;

        public List<Construction> MyCityConstructions { get { return this._myCityConstructions; } set { this._myCityConstructions = value; } }
        public List<Road> MyCityRoads { get { return this._myCityRoads; } set { this._myCityRoads = value; } }
        public Vehicle MyVehicle { get { return this._myVehicle; } set { this._myVehicle = value; } }

        #endregion

        private List<Road> _myRoute;
        private List<System.Drawing.Point> _myWayPoints;

        public AI()
        {
            _myRoute = new List<Road>();
            _myWayPoints = new List<System.Drawing.Point>();
        }

        public AI(Vehicle myVehicle, List<Construction> constructions, List<Road> roads)
        {
            this._myVehicle = myVehicle;
            this._myCityConstructions = constructions;
            this._myCityRoads = roads;

            _myRoute = new List<Road>();
            _myWayPoints = new List<System.Drawing.Point>();
        }

        public List<Road> MyRoute
        {
            get { return _myRoute; }

            set { _myRoute = value; }
        }

        public List<System.Drawing.Point> MyWayPoints
        {
            get { return _myWayPoints; }

            set { _myWayPoints = value; }
        }

        public List<Road> findAPath4(Road start, Road dest) // return Road
        {
            List<Road> openList = new List<Road>();
            List<Road> route = new List<Road>();

            Road startCpy = start.DeepCopy();
            Road destCpy = dest.DeepCopy();

            openList.Add(startCpy);

            while (openList.Any()) // 1. sort list by F 
                                   //2. add all successors of a Road obj at index 0 to openlist, calculate G H F of those successors and set all successors' parent road to obj at openlist index 0. 
                                   //3. pop off Road obj at index 0. 
                                   //4. repeat

            {
                openList.Sort(); //1
                if (openList[0].ConstructionIndex != destCpy.ConstructionIndex) // havent reached destination yet
                {
                    if (openList[0].ConstructionIndex == startCpy.ConstructionIndex) //if it at choosing start point stage just set index 0 obj's g to 0
                    {
                        openList[0].GCost = 0;
                        startCpy.setH(destCpy.PosX, destCpy.PosY);
                        //startCpy.F = startCpy.getF();
                    }

                    if (openList[0].successorsWithoutParentRoad().Any()) // if there is any successors
                    {
                        foreach (Road rs in openList[0].successorsWithoutParentRoad()) //2
                        {
                            rs.Parent = openList[0];
                            rs.GCost = rs.Parent.GCost + 1;
                            rs.setH(dest.PosX, dest.PosY);
                            //rs.F = rs.getF();
                            openList.Add(rs);
                        }
                    }
                    openList.RemoveAt(0);
                }
                else
                {
                    extractAllRoad(openList[0], ref route);
                    this.MyRoute = route;
                    return route;
                }
            }
            return null;
        }

        private void extractAllRoad(Road dest, ref List<Road> targetRoads)
        {
            if (dest.Parent != null)
            {
                extractAllRoad(dest.Parent, ref targetRoads);
            }
            targetRoads.Add(dest);
        }

        public Road DeepCopy()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return (Road)formatter.Deserialize(stream);
            }
        }

        public List<System.Drawing.Point> GetAllWayPoints(int nrOfPointsWanted, int startX, int startY, int endX, int endY)

        {

            List<System.Drawing.Point> temPoints = new List<System.Drawing.Point>();

            int ydiff = endY - startY,

                xdiff = endX - startX;

            double slope = (double)ydiff / xdiff;

            double x, y;

            --nrOfPointsWanted;

            for (double i = 0; i < nrOfPointsWanted; i++)

            {

                y = slope == 0 ? 0 : ydiff * (i / nrOfPointsWanted);

                x = slope == 0 ? xdiff * (i / nrOfPointsWanted) : y / slope;

                temPoints.Add(new System.Drawing.Point((int)Math.Round(x) + startX,

                    (int)Math.Round(y) + startY));

            }

            temPoints.Add(new System.Drawing.Point(endX, endY));

            return temPoints;

        }

        public void setWayPoints()
        {
            for (int c = 0; c < this.MyRoute.Count - 1; c++)
            {
                this.MyWayPoints.AddRange(GetAllWayPoints(9, this.MyRoute[c].PosX + 5, this.MyRoute[c].PosY + 5,
                    this.MyRoute[c + 1].PosX + 5, this.MyRoute[c + 1].PosY + 5));
            }
        }


        public void DO()
        {
            if (MyCityRoads.Count > 2)
            {
                if (MyWayPoints.Any())
                {
                    _myVehicle.PosX = MyWayPoints[0].X;
                    _myVehicle.PosY = MyWayPoints[0].Y;
                    MyWayPoints.Remove(MyWayPoints[0]);
                }
                else
                {
                    Road currentRoad, randomRoad;
                    currentRoad = getCurrentRoad(_myVehicle.PosX, _myVehicle.PosY);
                    do
                    {
                        randomRoad = getRandomDestinationRoad();
                    }
                    while (currentRoad.PosX == randomRoad.PosX && currentRoad.PosY == randomRoad.PosY);

                    if (findAPath4(currentRoad, randomRoad) != null)
                    {
                        setWayPoints();
                    }
                }
            }

        }

        private Road getCurrentRoad(int x, int y)
        {
            int currentIndex = Convert.ToInt32(coordinateToIndex(x, y));
            return (Road)this._myCityConstructions[currentIndex];
        }

        private Road getRandomDestinationRoad()
        {
            Random rr = new Random();
            int rdmIndex = rr.Next(0, _myCityRoads.Count);
            return _myCityRoads[rdmIndex];
        }

        public int? coordinateToIndex(int x, int y)
        {
            //550 1150 22 46
            int NumberOfRows = 50;
            int NumberOfColums = 26;
            int SquareSize = 32;

            if (x < 0 || y < 0)
            {
                return null;
            }
            int rowNr, coloumNr, index;
            rowNr = x / SquareSize;
            coloumNr = y / SquareSize;
            index = (coloumNr * NumberOfRows) + rowNr;
            if (index > NumberOfRows * NumberOfColums)
            {
                return null;
            }

            return index;
        }

    }
}