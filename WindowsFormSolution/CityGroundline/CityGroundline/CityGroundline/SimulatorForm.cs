using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityGroundline
{
    public partial class SimulatorForm : Form
    {
        public static SimulatorManager _mySimulatorMgr;

        private List<Point> testPoints;
        private List<Rectangle> testRectangles;
        private CivilianVehicle testCH;
        private Rectangle currentRectangle;
        private Road testStart;
        private Road testEnd;
        private AI testAi;
        private List<Road> testRoadList;

        public SimulatorForm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            this.SetStyle(ControlStyles.Opaque, false);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            testAi = new AI();
            testRoadList = new List<Road>();


            _mySimulatorMgr = new SimulatorManager(ref pnlCanvas);
            _mySimulatorMgr.MyPanel = this.pnlCanvas;
            _mySimulatorMgr.MyGraphics = this.pnlCanvas.CreateGraphics();

            _mySimulatorMgr.MouseMoveFunctios = new SimulatorManager.mouseActionHandler(_mySimulatorMgr.detectAndDrawSquare);
            _mySimulatorMgr.MouseClickFunctions = new SimulatorManager.mouseActionHandler(_mySimulatorMgr.emptyFunction);

            //_mySimulatorMgr.MyCity.MyConstructions[124] = new Road(_mySimulatorMgr.MyCity.MyConstructions[124].X, _mySimulatorMgr.MyCity.MyConstructions[124].Y);
            //_mySimulatorMgr.MyCity.MyConstructions[128] = new Road(_mySimulatorMgr.MyCity.MyConstructions[128].X, _mySimulatorMgr.MyCity.MyConstructions[128].Y);

            //testStart = (Road)_mySimulatorMgr.MyCity.MyConstructions[124];
            //testEnd = (Road)_mySimulatorMgr.MyCity.MyConstructions[128];

            /*testPoints = new List<Point>();
            testRectangles = new List<Rectangle>();
            testCreateGrid();*/
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            _mySimulatorMgr.showAllCells(e.Graphics);
            _mySimulatorMgr.showAllVehicles(e.Graphics);
            //if (testCH != null)
            //{
            //    testCH.drawYourSelf(e.Graphics);
            //}

            if (_mySimulatorMgr.CurrentConstruction != null) //...
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 255, 0)), _mySimulatorMgr.CurrentConstruction.MyRectangle);
            }
            //testShowAllPoints(e.Graphics);
        }

        private void pnlCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            _mySimulatorMgr.MouseMoveFunctios(e.X, e.Y);
            label1.Text = _mySimulatorMgr.CurrentConsIndex.ToString();
            label2.Text = _mySimulatorMgr.MyCity.MyConstructions[_mySimulatorMgr.CurrentConsIndex].getInfo();
            //label3.Text = _mySimulatorMgr.coordinateToIndex(e.X, e.Y).ToString();

            /*List<int> adjacentRoadIndex = _mySimulatorMgr.getAdjacentRoadsIndex(e.X, e.Y);

            if (adjacentRoadIndex.Count == 2)
            {
                label4.Text = adjacentRoadIndex[0 % 4].ToString();
                label5.Text = adjacentRoadIndex[1 % 4].ToString();
            }
            else if (adjacentRoadIndex.Count == 3)
            {
                label4.Text = adjacentRoadIndex[0 % 4].ToString();
                label5.Text = adjacentRoadIndex[1 % 4].ToString();
                label6.Text = adjacentRoadIndex[2 % 4].ToString();
            }
            else
            {
                label4.Text = adjacentRoadIndex[0 % 4].ToString();
                label5.Text = adjacentRoadIndex[1 % 4].ToString();
                label6.Text = adjacentRoadIndex[2 % 4].ToString();
                label7.Text = adjacentRoadIndex[3 % 4].ToString();
            }*/
        }

        private void pnlCanvas_MouseLeave(object sender, EventArgs e)
        {
            /*pnlCanvas.Invalidate(currentRectangle);
            currentRectangle = new Rectangle();*/
            Rectangle temp = _mySimulatorMgr.CurrentConstruction.MyRectangle;
            _mySimulatorMgr.CurrentConstruction = null;
            pnlCanvas.Invalidate(temp);
            //label1.Text = _mySimulatorMgr.CurrentConsIndex.ToString();
            //label2.Text = _mySimulatorMgr.CurrentConstruction.getInfo();
        }

        private void btnDetectingMode_Click(object sender, EventArgs e)
        {
            _mySimulatorMgr.MouseMoveFunctios = new SimulatorManager.mouseActionHandler(_mySimulatorMgr.detectAndDrawSquare);
        }

        private void btnClearFunction_Click(object sender, EventArgs e)
        {
            _mySimulatorMgr.MouseMoveFunctios = new SimulatorManager.mouseActionHandler(_mySimulatorMgr.emptyFunction);
            _mySimulatorMgr.MouseClickFunctions = new SimulatorManager.mouseActionHandler(_mySimulatorMgr.emptyFunction);
        }


        private void testMouseMove(int x, int y)
        {
            Graphics gg = pnlCanvas.CreateGraphics();
            if (!currentRectangle.Contains(x, y))
            {
                foreach (Rectangle r in testRectangles)
                {
                    if (r.Contains(x, y))
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
            }
        }

        private void testShowAllRectangles(Graphics g) // showing all squares
        {
            foreach (Rectangle r in testRectangles)
            {
                g.DrawRectangle(new Pen(Color.White), r);
            }
        }

        private void testShowAllPoints(Graphics g) // showing all squares
        {
            foreach (Point p in testPoints)
            {
                //g.DrawRectangle(new Pen(Color.LightBlue),p.X,p.Y,25,25);
                g.FillEllipse(Brushes.Black, p.X, p.Y, 5, 5);
            }
        }

        private void testCreateGrid() //generating and storing all the squares
        {
            int x = 0;
            int y = 0;
            int squareLength = 25;

            for (int i = 0; i < 22; i++) //maximum 22 squares can be placed in a colum |
            {
                for (int i2 = 0; i2 < 46; i2++) //maximum 46 squares can be placed in a row -
                {
                    testPoints.Add(new Point(x, y));
                    x += squareLength;
                }
                x = 0;
                y += squareLength;
            }

            foreach (Point p in testPoints)
            {
                testRectangles.Add(new Rectangle(p, new Size(25, 25)));
            }

        }



        private void pnlCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            _mySimulatorMgr.MouseClickFunctions(e.X, e.Y);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            testAi.findAPath4((Road)_mySimulatorMgr.MyCity.MyConstructions[124], (Road)_mySimulatorMgr.MyCity.MyConstructions[128]);
            Graphics gg = pnlCanvas.CreateGraphics();
            Road Rstart, Rend;
            Rstart = (Road)_mySimulatorMgr.MyCity.MyConstructions[124];
            Rend = (Road)_mySimulatorMgr.MyCity.MyConstructions[128];
            testAi.setWayPoints();
            foreach (Point p in testAi.MyWayPoints)
            {
                gg.FillEllipse(Brushes.Azure, p.X, p.Y, 5, 5);
            }
            MessageBox.Show("lol");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //testCH.MyAI.DO(testCH);
            _mySimulatorMgr.vehiclesDO();
            label8.Text = _mySimulatorMgr.MyCity.MyVehicles[0].getInfo();
            label9.Text = _mySimulatorMgr.MyCity.MyVehicles[1].getInfo();
            //label10.Text = _mySimulatorMgr.MyCity.MyVehicles[2].getInfo();
            //label11.Text = _mySimulatorMgr.MyCity.MyVehicles[3].getInfo();
            pnlCanvas.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_mySimulatorMgr.MyPanel = pnlCanvas;
            //testStart = (Road)_mySimulatorMgr.MyCity.MyConstructions[124];
            //testEnd = (Road)_mySimulatorMgr.MyCity.MyConstructions[128];
            //testCH = new CivilianVehicle((Road)_mySimulatorMgr.MyCity.MyConstructions[124]);
            //testCH.MyAI.findAPath4(testStart, testEnd);
            //testCH.MyAI.setWayPoints();
            _mySimulatorMgr.MyCity.MyVehicles.Add(new CivilianVehicle(_mySimulatorMgr.MyCity.MyConstructions[124]));
            _mySimulatorMgr.MyCity.MyVehicles.Add(new PoliceVehicle(_mySimulatorMgr.MyCity.MyConstructions[125]));
            //_mySimulatorMgr.MyCity.MyVehicles.Add(new Ambulance(_mySimulatorMgr.MyCity.MyConstructions[126]));
            //_mySimulatorMgr.MyCity.MyVehicles.Add(new FireTruck(_mySimulatorMgr.MyCity.MyConstructions[127]));

            foreach (Construction cr in _mySimulatorMgr.MyCity.MyConstructions)
            {
                if (cr is Road)
                {
                    _mySimulatorMgr.MyCity.MyRoads.Add((Road)cr);
                }
            }
            pnlCanvas.Invalidate();
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Road> list1 = new List<Road>();
            //List<Road> list2= list1.deep
            _mySimulatorMgr.vehiclesDO();
            pnlCanvas.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Road a;
            a = ((Road)_mySimulatorMgr.MyCity.MyConstructions[124]).DeepCopy();
            ((Road)_mySimulatorMgr.MyCity.MyConstructions[124]).MySuccessors[0].G = 123;
            MessageBox.Show("a successor0 g: " + a.MySuccessors[0].G + "original successor0 G: " + ((Road)_mySimulatorMgr.MyCity.MyConstructions[124]).MySuccessors[0].G);
        }

        private void btnCreateHPL_Click(object sender, EventArgs e)
        {
            btnCreateRH.BackColor = Color.Empty;
            btnCreatePS.BackColor = Color.Empty;
            btnCreateRoad.BackColor = Color.Empty;
            btnCreateHPL.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            btnCreateFS.BackColor = Color.Empty;
            btnCreateNP.BackColor = Color.Empty;
            _mySimulatorMgr.MouseClickFunctions = new SimulatorManager.mouseActionHandler(_mySimulatorMgr.setConstruction);
            _mySimulatorMgr.ConstructionTypeSetter = new SimulatorManager.constructionTypeHolder(_mySimulatorMgr.toHPL);
        }

        private void btnCreateFS_Click(object sender, EventArgs e)
        {
            btnCreateRH.BackColor = Color.Empty;
            btnCreatePS.BackColor = Color.Empty;
            btnCreateRoad.BackColor = Color.Empty;
            btnCreateHPL.BackColor = Color.Empty;
            btnCreateFS.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            btnCreateNP.BackColor = Color.Empty;
            _mySimulatorMgr.MouseClickFunctions = new SimulatorManager.mouseActionHandler(_mySimulatorMgr.setConstruction);
            _mySimulatorMgr.ConstructionTypeSetter = new SimulatorManager.constructionTypeHolder(_mySimulatorMgr.toFS);
        }

        private void btnCreateNP_Click(object sender, EventArgs e)
        {
            btnCreateRH.BackColor = Color.Empty;
            btnCreatePS.BackColor = Color.Empty;
            btnCreateRoad.BackColor = Color.Empty;
            btnCreateHPL.BackColor = Color.Empty;
            btnCreateFS.BackColor = Color.Empty;
            btnCreateNP.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            _mySimulatorMgr.MouseClickFunctions = new SimulatorManager.mouseActionHandler(_mySimulatorMgr.setConstruction);
            _mySimulatorMgr.ConstructionTypeSetter = new SimulatorManager.constructionTypeHolder(_mySimulatorMgr.toNP);
        }

        private void btnCreateRH_Click(object sender, EventArgs e)
        {
            btnCreateRH.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            btnCreatePS.BackColor = Color.Empty;
            btnCreateRoad.BackColor = Color.Empty;
            btnCreateHPL.BackColor = Color.Empty;
            btnCreateFS.BackColor = Color.Empty;
            btnCreateNP.BackColor = Color.Empty;
            _mySimulatorMgr.MouseClickFunctions = new SimulatorManager.mouseActionHandler(_mySimulatorMgr.setConstruction);
            _mySimulatorMgr.ConstructionTypeSetter = new SimulatorManager.constructionTypeHolder(_mySimulatorMgr.toRH);
        }

        private void btnCreatePS_Click(object sender, EventArgs e)
        {
            btnCreateRH.BackColor = Color.Empty;
            btnCreatePS.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            btnCreateRoad.BackColor = Color.Empty;
            btnCreateHPL.BackColor = Color.Empty;
            btnCreateFS.BackColor = Color.Empty;
            btnCreateNP.BackColor = Color.Empty;
            _mySimulatorMgr.MouseClickFunctions = new SimulatorManager.mouseActionHandler(_mySimulatorMgr.setConstruction);
            _mySimulatorMgr.ConstructionTypeSetter = new SimulatorManager.constructionTypeHolder(_mySimulatorMgr.toPS);
        }

        private void btnCreateRoad_Click(object sender, EventArgs e)
        {
            btnCreateRH.BackColor = Color.Empty;
            btnCreatePS.BackColor = Color.Empty;
            btnCreateRoad.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            btnCreateHPL.BackColor = Color.Empty;
            btnCreateFS.BackColor = Color.Empty;
            btnCreateNP.BackColor = Color.Empty;
            _mySimulatorMgr.MouseClickFunctions = new SimulatorManager.mouseActionHandler(_mySimulatorMgr.setConstruction);
            _mySimulatorMgr.ConstructionTypeSetter = new SimulatorManager.constructionTypeHolder(_mySimulatorMgr.toRd);
        }
    }
}
