using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CityGroundline
{
    public  class AI
    {
        private List<CityGroundline.Road> _myRoute;
        private List<Point> _myWayPoints;

        public AI()
        {
            _myRoute = new List<Road>();
            _myWayPoints = new List<Point>();
        }

        public List<CityGroundline.Road> MyRoute
        {
            get
            {
                return _myRoute;
            }

            set
            {
                _myRoute = value;
            }
        }

        public List<Point> MyWayPoints
        {
            get
            {
                return _myWayPoints;
            }

            set
            {
                _myWayPoints = value;
            }
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
                if (openList[0].ConstructionId != destCpy.ConstructionId) // havent reached destination yet
                {
                    if (openList[0].ConstructionId == startCpy.ConstructionId) //if it at choosing start point stage just set index 0 obj's g to 0
                    {
                        openList[0].G = 0;
                        startCpy.setH(destCpy.X, destCpy.Y);
                        startCpy.F = startCpy.getF();
                    }

                    if (openList[0].successorsWithoutParentRoad().Any()) // if there is any successors
                    {
                        foreach (Road rs in openList[0].successorsWithoutParentRoad()) //2
                        {
                            rs.ParentRoad = openList[0];
                            rs.G = rs.ParentRoad.G + 1;
                            rs.setH(dest.X, dest.Y);
                            rs.F = rs.getF();
                            openList.Add(rs);
                        }
                    }
                    openList.Remove(openList[0]);
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
            if (dest.ParentRoad != null)
            {
                extractAllRoad(dest.ParentRoad, ref targetRoads);
            }
            targetRoads.Add(dest);
        }

        public List<Point> GetAllWayPoints(int nrOfPointsWanted, int startX, int startY, int endX, int endY)

        {

            List<Point> temPoints = new List<Point>();

            int ydiff = endY - startY,

            xdiff = endX - startX;

            double slope = (double)ydiff / xdiff;

            double x, y;

            --nrOfPointsWanted;

            for (double i = 0; i < nrOfPointsWanted; i++)

            {

                y = slope == 0 ? 0 : ydiff * (i / nrOfPointsWanted);

                x = slope == 0 ? xdiff * (i / nrOfPointsWanted) : y / slope;

                temPoints.Add(new Point((int)Math.Round(x) + startX,

                (int)Math.Round(y) + startY));

            }

            temPoints.Add (new Point(endX,endY));

            return temPoints;

        }

        public void setWayPoints()
        {
            for(int c=0;c<this.MyRoute.Count-1; c++)
            {
                this.MyWayPoints.AddRange(GetAllWayPoints(9, this.MyRoute[c].X+25, this.MyRoute[c].Y+25, this.MyRoute[c + 1].X+25, this.MyRoute[c + 1].Y+25));
            }
        }


        public void DO(IVehicle myVehicle)
        {
            if (MyWayPoints.Any())
            {
                myVehicle.X = MyWayPoints[0].X;
                myVehicle.Y = MyWayPoints[0].Y;
                MyWayPoints.Remove(MyWayPoints[0]);
            }
            
        }

        //private List<Road> extractWayPoints(Road dest)
        //{
        //    List<Road> toReturn = new List<Road>();
        //    toReturn.Add(dest);
        //    if (dest.ParentRoad == null)
        //    {
        //        return toReturn;
        //    }
        //    else
        //    {
        //        toReturn.AddRange(extractWayPoints(dest.ParentRoad));
        //        return toReturn;
        //    }
        //}

        //public List<Road> findAPath(Road start , Road dest) // further optimization needed
        //{
        //    Road startCpy = start; // wheather its call by value or by reference its unknown, so cpy a obj to prevent potential problems.
        //    Road destCpy = dest;
        //    List<Road> openList = new List<Road>();
        //    List<Road> closeList = new List<Road>();

        //    startCpy.G = 0;
        //    start.setH(dest.X, dest.Y);
        //    start.F = start.getF();

        //    openList.Add(startCpy);

        //    while (openList.Any()) // 1. sort list by F 
        //                           //2. add all successors of a Road obj at index 0 to openlist, calculate G H F of those successors and set all successors' parent road to obj at openlist index 0. 
        //                           //3. pop off Road obj at index 0. 
        //                           //4. repeat

        //    {
        //        openList.Sort(); //1
        //        if (openList[0].ConstructionId != dest.ConstructionId) // havent reached destination yet
        //        {
        //            if (openList[0].ConstructionId == start.ConstructionId) //if it at choosing start point stage just set index 0 obj's g to 0
        //            {
        //                openList[0].G = 0;
        //            }

        //            if (openList[0].successorsWithoutParentRoad().Any()) // if there is any successors
        //            {
        //                foreach (Road rs in openList[0].successorsWithoutParentRoad()) //2
        //                {
        //                    rs.ParentRoad = openList[0];
        //                    rs.G = rs.ParentRoad.G + 1;
        //                    rs.setH(dest.X, dest.Y);
        //                    rs.F = rs.getF();
        //                    openList.Add(rs);
        //                }
        //            }
        //            closeList.Add(openList[0]);//3
        //            openList.Remove(openList[0]);
        //        }
        //        else
        //        {
        //            closeList.Add(openList[0]);
        //            break;
        //        }
        //    }
        //    return closeList;

        //}

        //public Road findAPath2(Road start, Road dest) // return Road
        //{
        //    Road startCpy = start; // wheather its call by value or by reference its unknown, so cpy a obj to prevent potential problems.
        //    Road destCpy = dest;
        //    List<Road> openList = new List<Road>();
        //    List<Road> closeList = new List<Road>();

        //    startCpy.G = 0;
        //    start.setH(dest.X, dest.Y);
        //    start.F = start.getF();

        //    openList.Add(startCpy);

        //    while (openList.Any()) // 1. sort list by F 
        //                           //2. add all successors of a Road obj at index 0 to openlist, calculate G H F of those successors and set all successors' parent road to obj at openlist index 0. 
        //                           //3. pop off Road obj at index 0. 
        //                           //4. repeat

        //    {
        //        openList.Sort(); //1
        //        if (openList[0].ConstructionId != dest.ConstructionId) // havent reached destination yet
        //        {
        //            if (openList[0].ConstructionId == start.ConstructionId) //if it at choosing start point stage just set index 0 obj's g to 0
        //            {
        //                openList[0].G = 0;
        //            }

        //            if (openList[0].successorsWithoutParentRoad().Any()) // if there is any successors
        //            {
        //                foreach (Road rs in openList[0].successorsWithoutParentRoad()) //2
        //                {
        //                    rs.ParentRoad = openList[0];
        //                    rs.G = rs.ParentRoad.G + 1;
        //                    rs.setH(dest.X, dest.Y);
        //                    rs.F = rs.getF();
        //                    openList.Add(rs);
        //                }
        //            }
        //            closeList.Add(openList[0]);//3
        //            openList.Remove(openList[0]);
        //        }
        //        else
        //        {
        //            return openList[0];
        //        }
        //    }
        //    return null;





        //}

        //public List<Road> findAPath3(Road start, Road dest) // return Road
        //{
        //    Road startCpy = start; // wheather its call by value or by reference its unknown, so cpy a obj to prevent potential problems.
        //    Road destCpy = dest;
        //    List<Road> openList = new List<Road>();
        //    List<Road> route = new List<Road>();

        //    openList.Add(startCpy);

        //    while (openList.Any()) // 1. sort list by F 
        //                           //2. add all successors of a Road obj at index 0 to openlist, calculate G H F of those successors and set all successors' parent road to obj at openlist index 0. 
        //                           //3. pop off Road obj at index 0. 
        //                           //4. repeat

        //    {
        //        openList.Sort(); //1
        //        if (openList[0].ConstructionId != dest.ConstructionId) // havent reached destination yet
        //        {
        //            if (openList[0].ConstructionId == start.ConstructionId) //if it at choosing start point stage just set index 0 obj's g to 0
        //            {
        //                openList[0].G = 0;
        //                start.setH(dest.X, dest.Y);
        //                start.F = start.getF();
        //            }

        //            if (openList[0].successorsWithoutParentRoad().Any()) // if there is any successors
        //            {
        //                foreach (Road rs in openList[0].successorsWithoutParentRoad()) //2
        //                {
        //                    rs.ParentRoad = openList[0];
        //                    rs.G = rs.ParentRoad.G + 1;
        //                    rs.setH(dest.X, dest.Y);
        //                    rs.F = rs.getF();
        //                    openList.Add(rs);
        //                }
        //            }
        //            openList.Remove(openList[0]);
        //        }
        //        else
        //        {
        //            return extractWayPoints(openList[0]);
        //        }
        //    }
        //    return null;
        //}

    }

}