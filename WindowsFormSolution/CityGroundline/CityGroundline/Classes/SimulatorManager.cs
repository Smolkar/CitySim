using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CityGroundline
{
    public class SimulatorManager
    {
        private City _myCity;
        private Construction _currentConstruction;
        private Graphics _myGraphics;
        private Panel _myPanel;
        private int _currentConsIndex;


        public delegate void mouseActionHandler(int x, int y);

        public delegate Construction constructionTypeHolder(int x, int y);

        public constructionTypeHolder ConstructionTypeSetter;

        public mouseActionHandler MouseMoveFunctios;

        public mouseActionHandler MouseClickFunctions;

        public SimulatorManager()
        {
            _myCity = new City();
            _currentConstruction = new EmptySpot();
            generatingCells();
        }

        public SimulatorManager(ref Panel aPanel)
        {
            _myCity = new City();
            _currentConstruction = new EmptySpot();
            MyPanel = aPanel;
            MyGraphics = MyPanel.CreateGraphics();
            generatingCells();
        }


        public City MyCity
        {
            get
            {
                return _myCity;
            }

            set
            {
                _myCity = value;
            }
        }

        public Construction CurrentConstruction
        {
            get
            {
                return _currentConstruction;
            }

            set
            {
                _currentConstruction = value;
            }
        }

        public Graphics MyGraphics
        {
            get
            {
                return _myGraphics;
            }

            set
            {
                _myGraphics = value;
            }
        }

        public Panel MyPanel
        {
            get
            {
                return _myPanel;
            }
            set
            {
                _myPanel = value;
            }
        }

        public int CurrentConsIndex
        {
            get
            {
                return _currentConsIndex;
            }
            set
            {
                if (value > 252)
                {
                    this._currentConsIndex = 252;
                }
                else if (value < 0)
                {
                    this._currentConsIndex = 0;
                }
                else
                {
                    this._currentConsIndex = value;
                }
            }
        }

        public void generatingCells() //generating and storing all the squares
        {
            int x = 0;
            int y = 0;
            int squareSize = 50;

            for (int i = 0; i < 550 / squareSize; i++) //maximum 22 squares can be placed in a colum |
            {
                for (int i2 = 0; i2 < 1150 / squareSize; i2++) //maximum 46 squares can be placed in a row -
                {
                    EmptySpot temp = new EmptySpot(x, y);
                    temp.ConstructionIndex = coordinateToIndex(x, y);
                    _myCity.MyConstructions.Add(temp);
                    x += squareSize;
                }
                x = 0;
                y += squareSize;
            }

            /*foreach (Cell c in _MyConstructions)
            {
                testRectangles.Add(new Rectangle(p, new Size(25, 25)));
            }*/

        }

        public void showAllCells(Graphics g)
        {
            foreach (Construction c in _myCity.MyConstructions)
            {
                c.drawYourSelf(g);
            }
        }

        public void showAllVehicles(Graphics g)
        {
            if (_myCity.MyVehicles.Any())
            {
                foreach (Vehicle v in _myCity.MyVehicles)
                {
                    v.drawYourSelf(g);
                }
            }
        }


        public Construction getCell(int x, int y)
        {
            foreach (Construction c in this._myCity.MyConstructions)
            {
                if (c.MyRectangle.Contains(x, y))
                {
                    return c;
                }
            }
            return null;
        }


        public void detectAndDrawSquare(int x, int y)
        {
            ///*if (_CurrentConstruction == null) //first time mouse moves in the area
            //{
            //    foreach (Cell c in this.MyCity.MyConstructions) // a loop through the list MyConstructions
            //    {
            //        if (c.MyRectangle.Contains(x, y)) // found the match cell
            //        {
            //            _myGraphics.FillRectangle(Brushes.BlueViolet, c.MyRectangle);
            //            CurrentConstruction = c;
            //            break;
            //        }
            //    }
            //}
            //else    //current cell is set , now moves inside the panel
            //{
            //    if (!_CurrentConstruction.MyRectangle.Contains(x, y)) //when the mouse is not moving inside the same cell
            //    {
            //        foreach (Cell c in MyCity.MyConstructions)
            //        {
            //            if (c.MyRectangle.Contains(x, y))
            //            {
            //                MyGraphics.FillRectangle(Brushes.BlueViolet, c.MyRectangle);
            //                MyPanel.Invalidate(CurrentConstruction.MyRectangle);
            //                CurrentConstruction = c;
            //                break;
            //            }
            //        }
            //    }
            //    // if its moving in the same panel, do nothing 
            //}*/




            ///*if (!CurrentConstruction.MyRectangle.Contains(x, y))
            //{
            //    int i;
            //    for (i = 0; i < _myCity.MyConstructions.Count; i++) //for now lets just use a stupid foreach loop, but there is a smarter loop
            //    {
            //        if (_myCity.MyConstructions[i].MyRectangle.Contains(x, y))
            //        {
            //            if (CurrentConstruction.MyRectangle.IsEmpty)  //the reason chek IsEmpty is to solve "square will not be filled when first enter panel canvas" problem
            //            {                              // when the currentRectangle is empty, no need to reset that rectangle to empty color
            //                MyGraphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 255, 0)), _myCity.MyConstructions[i].MyRectangle);
            //                CurrentConstruction = _myCity.MyConstructions[i];
            //                break;
            //            }
            //            else if (!CurrentConstruction.MyRectangle.IsEmpty && CurrentConstruction != _myCity.MyConstructions[i]) // when the currentRectangle is not empty, means the mouse is not ENTERING the panel but moving inside
            //            {                                                            // when the currentRectangle(last/current rectangle) is not r, means the mouse is hovering to another rectangle.
            //                MyGraphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 255, 0)), _myCity.MyConstructions[i].MyRectangle);                 // then we need to reset last rectangle to empty color in order to keep 1 rectangle filled with color.
            //                MyPanel.Invalidate(CurrentConstruction.MyRectangle);
            //                CurrentConstruction = _myCity.MyConstructions[i];
            //                break;
            //            }
            //        }
            //    }
            //    CurrentConsIndex = i;
            //}*/
            if (this.CurrentConstruction != null)
            {
                if (!CurrentConstruction.MyRectangle.Contains(x, y))
                {
                    int idx;//index number to find the construction where the mouse at.
                    idx = coordinateToIndex(x, y);
                    if (CurrentConstruction.MyRectangle.IsEmpty)  //the reason chek IsEmpty is to solve "square will not be filled when first enter panel canvas" problem
                    {                              // when the currentRectangle is empty, no need to reset that rectangle to empty color
                        MyGraphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 255, 0)), _myCity.MyConstructions[idx].MyRectangle);
                        CurrentConstruction = _myCity.MyConstructions[idx];
                    }
                    else if (!CurrentConstruction.MyRectangle.IsEmpty && CurrentConstruction != _myCity.MyConstructions[idx]) // when the currentRectangle is not empty, means the mouse is not ENTERING the panel but moving inside
                    {                                                            // when the currentRectangle(last/current rectangle) is not r, means the mouse is hovering to another rectangle.
                        MyGraphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 255, 0)), _myCity.MyConstructions[idx].MyRectangle);                 // then we need to reset last rectangle to empty color in order to keep 1 rectangle filled with color.
                        MyPanel.Invalidate(CurrentConstruction.MyRectangle);
                        CurrentConstruction = _myCity.MyConstructions[idx];
                    }
                    CurrentConsIndex = idx;
                }
            }
            else
            {
                CurrentConstruction = _myCity.MyConstructions[coordinateToIndex(x, y)];
                //MyGraphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 255, 0)), CurrentConstruction.MyRectangle);
                MyPanel.Invalidate(CurrentConstruction.MyRectangle);
            }

            //if (!CurrentConstruction.MyRectangle.Contains(x, y))
            //{
            //    MyPanel.Invalidate(CurrentConstruction.MyRectangle);
            //    int idx;//index number to find the construction where the mouse at.
            //    idx = coordinateToIndex(x, y);
            //    CurrentConstruction = _myCity.MyConstructions[idx];
            //    CurrentConsIndex = idx;
            //    MyGraphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 255, 0)), _myCity.MyConstructions[idx].MyRectangle);
            //}

        }

        public int coordinateToIndex(int x, int y)
        {
            //550 1150 22 46
            int row, coloum, index;
            row = x / 50;
            coloum = y / 50;
            index = (coloum * 23) + row;
            if (index > 252)
            {
                index = 252;
            }
            //return "X: " + row + " Y: " + coloum + " Index: " + index;

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

        public void setConstruction(int x, int y)
        {
            Construction temp = _myCity.MyConstructions[CurrentConsIndex]; // temp is just shorter 
            if (MyCity.MyConstructions[CurrentConsIndex] is EmptySpot)
            {
                _myCity.MyConstructions[CurrentConsIndex] = ConstructionTypeSetter(temp.X, temp.Y);
                _myCity.MyConstructions[CurrentConsIndex].ConstructionIndex = coordinateToIndex(temp.X, temp.Y);
                if (!(_myCity.MyConstructions[CurrentConsIndex] is Road)) // then a building just created
                {
                    
                }
                else // a road just created
                {
                    //try to connect nearby road and maybe building??
                    _myCity.MyRoads.Add((Road)_myCity.MyConstructions[CurrentConsIndex]);
                }
            }
            else
            {

            }

        }

        public void emptyFunction(int x, int y)
        {

        }

        public Construction toRH(int x, int y) //set an empty spot to Residence house
        {
            ResidenceHouse rh = new ResidenceHouse(x, y);
            return rh;
        }

        public Construction toPS(int x, int y) //set an empty spot to Police station
        {
            Policestation ps = new Policestation(x, y);
            return ps;
        }

        public Construction toRd(int x, int y) //set an empty spot to Road
        {
            Road rd = new Road(x, y);
            List<int> adjacentRoadIndex = getAdjacentRoadsIndex(x, y);
            foreach (int i in adjacentRoadIndex)
            {
                if (this._myCity.MyConstructions[i] is Road)
                {
                    rd.MySuccessors.Add((Road)this._myCity.MyConstructions[i]);
                    ((Road)this._myCity.MyConstructions[i]).MySuccessors.Add(rd);
                }
            }
            return rd;
        }

        public Construction toHPL(int x, int y) //set an empty spot to Hospital
        {
            Hospital hpl = new Hospital(x, y);
            return hpl;
        }

        public Construction toFS(int x, int y) //set an empty spot to Fire station
        {
            FireStation fs = new FireStation(x, y);
            return fs;
        }

        public Construction toNP(int x, int y) //set an empty spot to Nuclear plant
        {
            NuclearPlant np = new NuclearPlant(x, y);
            return np;
        }

        public void vehiclesDO()
        {
            for (int c = 0; c < _myCity.MyVehicles.Count; c++)
            {
                if (!_myCity.MyVehicles[c].MyAI.MyWayPoints.Any()) // Way points run out
                {
                    Road cRoad = getCurrentRoad(_myCity.MyVehicles[c].X, _myCity.MyVehicles[c].Y);
                    Road rDest = getRandomDestination();
                    _myCity.MyVehicles[c].MyAI.findAPath4(cRoad, rDest);
                    _myCity.MyVehicles[c].MyAI.setWayPoints();
                }
                _myCity.MyVehicles[c].MyAI.DO(_myCity.MyVehicles[c]);
            }
        }

        private Road getRandomDestination()
        {
            Random rr = new Random();
            int a = rr.Next(0, _myCity.MyRoads.Count - 1);
            return _myCity.MyRoads[a];
        }

        private Road getCurrentRoad(int x, int y)
        {
            int a = coordinateToIndex(x, y);
            return (Road)_myCity.MyConstructions[a];
        }

        private Vehicle getVehicleByIndex(int indexNr)
        {
            return _myCity.MyVehicles[indexNr];
        }

    }

    /*Graphics gg = pnlCanvas.CreateGraphics();
        if (!currentRectangle.Contains(e.X, e.Y))
        {
            foreach (Rectangle r in testRectangles)
            {
                if (r.Contains(e.X, e.Y))
                {
                    if (currentRectangle.IsEmpty)  //the reason chek IsEmpty is to solve "square will not be filled when first enter panel canvas" problem
                    {                              // when the currentRectangle is empty, no need to reset that rectangle to empty color
                        gg.FillRectangle(Brushes.BlueViolet, r);
                        currentRectangle = r;
                        break;
                    }
                    else if (!currentRectangle.IsEmpty && currentRectangle != r) // when the currentRectangle is not empty, means the mouse is not ENTERING the panel but moving inside
                    {                                                            // when the currentRectangle(last/current rectangle) is not r, means the mouse is hovering to another rectangle.
                        gg.FillRectangle(Brushes.BlueViolet, r);                 // then we need to reset last rectangle to empty color in order to keep 1 rectangle filled with color.
                        pnlCanvas.Invalidate(currentRectangle);
                        currentRectangle = r;
                        break;
                    }
                }
            }
        }*/

    //delete Cell Enhance Construction

}
