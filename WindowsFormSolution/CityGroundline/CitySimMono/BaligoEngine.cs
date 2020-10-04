using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using CitySimMono.Entity.Buildings;
using CitySimMono.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CitySimMono.Input;
using CitySimMono.Entity.Custom_Mouse;
using CitySimMono.World;
using Microsoft.Xna.Framework.Input;
using CitySimMono.Entity.Cars;
using GeonBit.UI;
using GeonBit.UI.Entities;


namespace CitySimMono.World
{
    /// <summary>
    /// 
    /// </summary>
    public class BaligoEngine : Game
    {
        bool pause = true;
        public static List<IRender> Cars;
        public static List<IRender> Buildings;
        public static City city;
        public static CivilianVehicle vehicle1;
        Matrix Scale;
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        List<Panel> panels = new List<Panel>();
        Paragraph targetEntityShow;
        public Panel TopPanel;
        public Panel panelShowInfo;
        public static int Height = 1920;
        public static int Width = 1080;

        private static int _selectedItemId;

        public BaligoEngine()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            int _ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int _ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.PreferredBackBufferWidth = (int)_ScreenWidth;
            _graphics.PreferredBackBufferHeight = (int)_ScreenHeight;

            _graphics.IsFullScreen = true;


            _graphics.ApplyChanges();
            Assets.LoadAssets(Content);

            Cars = new List<IRender>();
            Buildings = new List<IRender>();

            SetBorderless();

        }

        
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //IsMouseVisible = true;
            UI.Init(content: this.Content);
            Assets.LoadAssets(Content);
            UserInterface.Initialize(Content, BuiltinThemes.hd);
            InitUI();

            base.Initialize();
        }   
                //UI
        protected void InitUI()
        {
            // dropdown title
            
            #region Basic
            //int topPanelHeight = 65;
            //Bot Panel
            int topPanelHeight = 65;
            Panel botPanel = new Panel(new Vector2(0, topPanelHeight + 2), PanelSkin.Simple, Anchor.BottomCenter);
            botPanel.Padding = Vector2.Zero;
            Panel optionPanel = new Panel(new Vector2(0, 0), PanelSkin.Simple, Anchor.Center);
            optionPanel.Visible = false;
            UserInterface.Active.AddEntity(optionPanel);
            UserInterface.Active.AddEntity(botPanel);
            Button exitBtn = new Button("Exit", anchor: Anchor.BottomRight, size: new Vector2(200, -1));
            exitBtn.OnClick = (GeonBit.UI.Entities.Entity entity) => { Exit(); };
            
            //Main pannel
            TopPanel = new Panel(new Vector2(0, 0), PanelSkin.Simple, Anchor.Center);
            panels.Add(TopPanel);
            Button button_start = new Button("Start", ButtonSkin.Fancy, Anchor.Center, new Vector2(280, 100));
            button_start.OnClick = (GeonBit.UI.Entities.Entity btn) => { TopPanel.Visible = false;  };
            Button button_optionback = new Button("Back", ButtonSkin.Fancy, Anchor.BottomRight, new Vector2(280, 100));
            button_optionback.OnClick = (GeonBit.UI.Entities.Entity btn) => { optionPanel.Visible = false; TopPanel.Visible = true;  };
            Button button_options = new Button("Options", ButtonSkin.Fancy, Anchor.BottomCenter, new Vector2(280, 100), offset: new Vector2(0, 250));
            button_start.OnClick = (GeonBit.UI.Entities.Entity btn) => { TopPanel.Visible = false; };
            button_options.OnClick = (GeonBit.UI.Entities.Entity btn) => { optionPanel.Visible = true; TopPanel.Visible = false; botPanel.Visible = false; };
            Button button_Save = new Button("Save",anchor: Anchor.BottomLeft,size: new Vector2(250,-1), offset: new Vector2(250,0));
            button_Save.OnClick = (GeonBit.UI.Entities.Entity btn) => { testAI();  };
            Button button_Load = new Button("Load",anchor: Anchor.BottomLeft,size: new Vector2(250, -1), offset: new Vector2(500, 0));
            button_Load.OnClick = (GeonBit.UI.Entities.Entity btn) => { pause = !pause; };
            Button button_CreateRandomEvent = new Button("CreatRandomEvent", anchor: Anchor.BottomLeft, size: new Vector2(250, -1), offset: new Vector2(1000, 0));
            button_CreateRandomEvent.OnClick = (GeonBit.UI.Entities.Entity btn) => { };
            Button button_back = new Button("Back",anchor: Anchor.BottomLeft,size: new Vector2(150,-1 ), offset:new Vector2(1250,0));
            button_back.OnClick = (GeonBit.UI.Entities.Entity btn) => {TopPanel.Visible = true;};
            botPanel.AddChild(button_Save);
            botPanel.AddChild(button_Load);
            TopPanel.AddChild(button_options);
            TopPanel.AddChild(button_start);
            botPanel.AddChild(button_CreateRandomEvent);
            botPanel.AddChild(button_back);
            optionPanel.AddChild(button_optionback);
            TopPanel.Padding = Vector2.Zero;
            UserInterface.Active.AddEntity(TopPanel);
            //Exit Button on the TOp
            UserInterface.Active.AddEntity(exitBtn);

            // events panel for debug
            Panel eventsPanel = new Panel(new Vector2(400, 530), PanelSkin.Simple, Anchor.CenterLeft,
                new Vector2(-10, 0));
            eventsPanel.Visible = false;

            // events log (single-time events)
            eventsPanel.AddChild(new Label("Events Log:"));
            SelectList eventsLog = new SelectList(size: new Vector2(-1, 280));
            eventsLog.ExtraSpaceBetweenLines = -8;
            eventsLog.ItemsScale = 0.5f;
            eventsLog.Locked = true;
            eventsPanel.AddChild(eventsLog);

            // current events (events that happen while something is true)
            eventsPanel.AddChild(new Label("Current Events:"));
            SelectList eventsNow = new SelectList(size: new Vector2(-1, 100));
            eventsNow.ExtraSpaceBetweenLines = -8;
            eventsNow.ItemsScale = 0.5f;
            eventsNow.Locked = true;
            eventsPanel.AddChild(eventsNow);
            // paragraph to show currently active panel
            targetEntityShow = new Paragraph("test", Anchor.Auto, Color.White, scale: 0.75f);
            eventsPanel.AddChild(targetEntityShow);


            // add the events panel
            UserInterface.Active.AddEntity(eventsPanel);
            eventsLog.OnListChange = (GeonBit.UI.Entities.Entity entity) =>
            {
                SelectList list = (SelectList)entity;
                if (list.Count > 100)
                {
                    list.RemoveItem(0);
                }
            };
            // listen to all global events - one timers
            UserInterface.Active.OnClick = (GeonBit.UI.Entities.Entity entity) => { eventsLog.AddItem("Click: " + entity.GetType().Name); eventsLog.scrollToEnd(); };
            UserInterface.Active.OnRightClick = (GeonBit.UI.Entities.Entity entity) => { eventsLog.AddItem("RightClick: " + entity.GetType().Name); eventsLog.scrollToEnd(); };
            UserInterface.Active.OnMouseDown = (GeonBit.UI.Entities.Entity entity) => { eventsLog.AddItem("MouseDown: " + entity.GetType().Name); eventsLog.scrollToEnd(); };
            UserInterface.Active.OnRightMouseDown = (GeonBit.UI.Entities.Entity entity) => { eventsLog.AddItem("RightMouseDown: " + entity.GetType().Name); eventsLog.scrollToEnd(); };
            UserInterface.Active.OnMouseEnter = (GeonBit.UI.Entities.Entity entity) => { eventsLog.AddItem("MouseEnter: " + entity.GetType().Name); eventsLog.scrollToEnd(); };
            UserInterface.Active.OnMouseLeave = (GeonBit.UI.Entities.Entity entity) => { eventsLog.AddItem("MouseLeave: " + entity.GetType().Name); eventsLog.scrollToEnd(); };
            UserInterface.Active.OnMouseReleased = (GeonBit.UI.Entities.Entity entity) => { eventsLog.AddItem("MouseReleased: " + entity.GetType().Name); eventsLog.scrollToEnd(); };
            UserInterface.Active.OnMouseWheelScroll = (GeonBit.UI.Entities.Entity entity) => { eventsLog.AddItem("Scroll: " + entity.GetType().Name); eventsLog.scrollToEnd(); };
            UserInterface.Active.OnStartDrag = (GeonBit.UI.Entities.Entity entity) => { eventsLog.AddItem("StartDrag: " + entity.GetType().Name); eventsLog.scrollToEnd(); };
            UserInterface.Active.OnStopDrag = (GeonBit.UI.Entities.Entity entity) => { eventsLog.AddItem("StopDrag: " + entity.GetType().Name); eventsLog.scrollToEnd(); };
            UserInterface.Active.OnFocusChange = (GeonBit.UI.Entities.Entity entity) => { eventsLog.AddItem("FocusChange: " + entity.GetType().Name); eventsLog.scrollToEnd(); };
            UserInterface.Active.OnValueChange = (GeonBit.UI.Entities.Entity entity) => { if (entity.Parent == eventsLog) { return; } eventsLog.AddItem("ValueChanged: " + entity.GetType().Name); eventsLog.scrollToEnd(); };
            Button infoBtn = new Button("  Events", anchor: Anchor.BottomLeft, size: new Vector2(250, -1), offset: new Vector2(0, 0));
            infoBtn.AddChild(new Icon(IconType.Scroll, Anchor.CenterLeft), true);
            infoBtn.OnClick = (GeonBit.UI.Entities.Entity entity) =>
            {
                eventsPanel.Visible = !eventsPanel.Visible;
            };
            infoBtn.ToolTipText = "Show events log.";
            UserInterface.Active.AddEntity(infoBtn);
            #endregion
            //Panel show info
            panelShowInfo = new Panel(new Vector2(0, 0), PanelSkin.Simple);
            panelShowInfo.Draggable = true;
                       panels.Add(panelShowInfo);
            panelShowInfo.Visible = false;
            UserInterface.Active.AddEntity(panelShowInfo);

            Panel panelTime = new Panel(new Vector2(500,400), PanelSkin.Simple, Anchor.Center);
            panelTime.AddChild(new Paragraph("Set the time:"));
            TextInput textMulti = new TextInput(false, new Vector2(0, 0), skin: PanelSkin.Golden);
            textMulti.PlaceholderText = @"ex.12:30";
            panelTime.AddChild(textMulti);
            panelTime.Visible = false;
            UserInterface.Active.AddEntity(panelTime);
            
            Button button_Time = new Button("Time", anchor: Anchor.BottomLeft, size: new Vector2(250, -1), offset: new Vector2(750, 0));
            button_Time.OnClick = (GeonBit.UI.Entities.Entity btn) =>
            {
                panelTime.Visible = true; 
            };
            UserInterface.Active.AddEntity(button_Time);

            Button button_Time_back = new Button("Back", anchor: Anchor.BottomLeft, size: new Vector2(250, -1), offset: new Vector2(0, 0));
            button_Time_back.OnClick = (GeonBit.UI.Entities.Entity btn) => { panelTime.Visible = false; };
            Button button_Time_set= new Button("Set", anchor: Anchor.BottomLeft, size: new Vector2(250, -1), offset: new Vector2(250, 0));
            button_Time_set.OnClick = (GeonBit.UI.Entities.Entity btn) => { panelTime.Visible = false; };
            panelTime.AddChild(button_Time_back);
            panelTime.AddChild(button_Time_set);



            #region ConstructionPanel


            Panel constructionPanel = new Panel(new Vector2(0, topPanelHeight + 10), PanelSkin.Simple, Anchor.BottomCenter);
            constructionPanel.Visible = false;
            constructionPanel.SetOffset(new Vector2(0, 70));
            UserInterface.Active.AddEntity(constructionPanel);
            //Panel simulationOptionsPanel = new Panel(new Vector2(0, topPanelHeight + 2), PanelSkin.Simple, Anchor.BottomCenter);
            Button roadButton = new Button("Road", anchor: Anchor.BottomLeft, size: new Vector2(150, -1), offset: new Vector2(-30, -28))
            {
                OnClick = (GeonBit.UI.Entities.Entity btn) => { _selectedItemId = 0; }
            };
            Button PoliceStationButton = new Button("Police Station", anchor: Anchor.BottomLeft, size: new Vector2(250, -1), offset: new Vector2(120, -28))
            {
                OnClick = (GeonBit.UI.Entities.Entity btn) => { _selectedItemId = 4; }
            };
            Button HospitalButton = new Button("Hospital", anchor: Anchor.BottomLeft, size: new Vector2(250, -1), offset: new Vector2(370, -28))
            {
                OnClick = (GeonBit.UI.Entities.Entity btn) => { _selectedItemId = 11; }
            };
            Button FireDepButton = new Button("Fire Department", anchor: Anchor.BottomLeft, size: new Vector2(250, -1), offset: new Vector2(620, -28))
            {
                OnClick = (GeonBit.UI.Entities.Entity btn) => { _selectedItemId = 12; }
            };
            Button HouseButton = new Button("House", anchor: Anchor.BottomLeft, size: new Vector2(200, -1), offset: new Vector2(870, -28))
            {
                OnClick = (GeonBit.UI.Entities.Entity btn) => { _selectedItemId = 6; }
            };
            Button TrafficLightButton = new Button("Traffic Light", anchor: Anchor.BottomLeft, size: new Vector2(250, -1), offset: new Vector2(1070, -28))
            {
                OnClick = (GeonBit.UI.Entities.Entity btn) => { _selectedItemId = 8; }
            };
            Button ShopButton = new Button("Shop", anchor: Anchor.BottomLeft, size: new Vector2(150, -1), offset: new Vector2(1320, -28))
            {
                OnClick = (GeonBit.UI.Entities.Entity btn) => { _selectedItemId = 5; }
            };
            Button WorkButton = new Button("Work", anchor: Anchor.BottomLeft, size: new Vector2(150, -1), offset: new Vector2(1470, -28))
            {
                OnClick = (GeonBit.UI.Entities.Entity btn) => { _selectedItemId = 13; }
            };
            Button ResetButton = new Button("Reset", anchor: Anchor.BottomLeft, size: new Vector2(200, -1), offset: new Vector2(1620, -28))
            {
                OnClick = (GeonBit.UI.Entities.Entity btn) => { _selectedItemId = 1; }
            };

            constructionPanel.AddChild(WorkButton);
            constructionPanel.AddChild(ShopButton);
            constructionPanel.AddChild(TrafficLightButton);
            constructionPanel.AddChild(HouseButton);
            constructionPanel.AddChild(FireDepButton);
            constructionPanel.AddChild(HospitalButton);
            constructionPanel.AddChild(PoliceStationButton);
            constructionPanel.AddChild(ResetButton);
            constructionPanel.AddChild(roadButton);

            Button showConstructioButton = new Button("Constructions", anchor: Anchor.BottomLeft, size: new Vector2(250, -1), offset: new Vector2(1400, 0));
            showConstructioButton.OnClick = (GeonBit.UI.Entities.Entity btn) =>
            {
                if (constructionPanel.Visible)
                    constructionPanel.Visible = false;
                else
                    constructionPanel.Visible = true;
            };
            UserInterface.Active.AddEntity(showConstructioButton);
            #endregion


            //            
            //            DropDown dropWheater = new DropDown(new Vector2(200, 200), Anchor.TopCenter, new Vector2(400, 0));
            //
            //            dropWheater.AddItem("Sunny");
            //            dropWheater.AddItem("Rainy");
            //            dropWheater.AddItem("Cloudy");
            //            dropWheater.AddItem("Partly Cloudy");
            //            
            //            UserInterface.Active.AddEntity(dropWheater);

        }

        // whenever events log list size changes, make sure its not too long. if it is, trim it.



        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            city = new City();
            city.generatingCells();

            foreach (var building in city.MyEmptySpots)
            {
                Buildings.Add(building);
            }

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        private int _waitTime = 15;
        private float topPanelHeight;

        protected override void Update(GameTime gameTime)
        {


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (TopPanel.Visible)
                UserInterface.Active.Update(gameTime);

            else
            {
                InputManager.Update();
                UserInterface.Active.Update(gameTime);


                // Placing Road
                if (InputManager.LeftButtomDown && _waitTime == 0)
                    PlaceBuilding(_selectedItemId);
                if (InputManager.RightButtomDown && _waitTime == 0)
                    InfoShow(EmptySpotFromWorldPosition(InputManager.MouseX, InputManager.MouseY) as EmptySpot);

                /*foreach (var building in Buildings)
                {
                    building.Update(gameTime);
                }

                foreach (var car in Cars)
                {
                    car.Update(gameTime);
                }*/
                if (pause)
                {
                    foreach (Vehicle v in city.MyVehicles)
                    {
                        v.Update(gameTime);
                    }
                }

                if (UI.IsUiActive)
                {

                    UI.Update();

                    //TODO: OPTIMIZE
                    InputManager.Update();


                }

                // Do not touch
                if (_waitTime - 1 >= 0)
                    _waitTime--;
                base.Update(gameTime);
                
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            _spriteBatch.Begin();
            // clear buffer
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // GeonBit.UI: draw UI using the spriteBatch you created above

            //if (UI.IsUiActive)
            //{
            //    CustomMouse1.Draw(_spriteBatch);

            //    UI.Draw(_spriteBatch);
            //}
            
            city.Draw(_spriteBatch);

            foreach (var building in Buildings)
            {
                Texture2D textureToDraw = Assets.GetTextureById(building.TextureId);
                _spriteBatch.Draw(textureToDraw, new Vector2(building.PosX, building.PosY), null, Color.White);
            }

            foreach (var car in Cars)
            {
                Texture2D textureToDraw = Assets.GetTextureById(car.TextureId);
                _spriteBatch.Draw(textureToDraw, new Vector2(car.PosX, car.PosY), null, Color.White);
            }

            foreach (Vehicle car in city.MyVehicles)
            {
                Texture2D textureToDraw = Assets.GetTextureById(car.TextureId);
                _spriteBatch.Draw(textureToDraw, new Vector2(car.PosX, car.PosY), null, Color.White);
            }


            //CustomMouse1.Draw(_spriteBatch);

            _spriteBatch.End();
            //GraphicsDevice.Clear(Color.White);
            UserInterface.Active.Draw(_spriteBatch);

            base.Draw(gameTime);
        }


        /// <summary>
        /// This Method will set the window to full screen borderless
        /// </summary>
        private void SetBorderless()
        {
            //_graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //_graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //_graphics.ApplyChanges();
            //_graphics.PreferredBackBufferWidth = 1472;
            //_graphics.PreferredBackBufferHeight = 704;
            //Window.ClientSizeChanged += (s, e) =>
            //{
            //    _graphics.PreferredBackBufferWidth = 1123;
            //    _graphics.PreferredBackBufferHeight = 550;
            //    _graphics.ApplyChanges();
            //};

            //Full screen
            _graphics.IsFullScreen = true;

            Window.IsBorderless = false;
        }

        private void PlaceBuilding(int id)
        {

            int possitionX = (EmptySpotFromWorldPosition(InputManager.MouseX, InputManager.MouseY) as EmptySpot)
                .PosX;
            int possitionY = (EmptySpotFromWorldPosition(InputManager.MouseX, InputManager.MouseY) as EmptySpot)
                .PosY;

            if (id == 0)
            {
                var roadToRemove = city.MyRoads.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (roadToRemove != null)
                    city.MyRoads.Remove(roadToRemove); 

                var buildingToRemove = Buildings.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (buildingToRemove != null)
                    Buildings.Remove(buildingToRemove); 

                int intX = Convert.ToInt32(InputManager.MouseX), intY = Convert.ToInt32(InputManager.MouseY);
                if (city.coordinateToIndex(intX, intY) != null)
                {
                    int index;
                    index = Convert.ToInt32(city.coordinateToIndex(intX, intY));

                    if (city.MyConstructions[index] is EmptySpot)
                    {
                        city.MyConstructions[index] = new Road(city.MyConstructions[index].PosX, city.MyConstructions[index].PosY, index);

                        List<int?> adjacentConstructs = city.getAdjacentRoadsIndex2(city.MyConstructions[index].PosX, city.MyConstructions[index].PosY);

                        foreach(int? i in adjacentConstructs)
                        {
                            if (city.MyConstructions[Convert.ToInt32(i)] is Road)
                            {
                                ((Road)(city.MyConstructions[index])).MySuccessors.Add((Road)city.MyConstructions[Convert.ToInt32(i)]);
                                ((Road)city.MyConstructions[Convert.ToInt32(i)]).MySuccessors.Add(((Road)(city.MyConstructions[index])));
                            }
                        }
                        city.MyRoads2.Add((Road)city.MyConstructions[index]);
                    }
                }

                Road roadPlaced = new Road(possitionX, possitionY);
                (EmptySpotFromWorldPosition(InputManager.MouseX, InputManager.MouseY) as EmptySpot)
                    .Change(roadPlaced);
                city.MyRoads.Add(roadPlaced);
                Buildings.Add(roadPlaced);

                _waitTime = 15;
                InputManager.Update();

            // Remove construction
            }else if (id == 1)
            {
                

                var roadToRemove = city.MyRoads.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (roadToRemove != null)
                    city.MyRoads.Remove(roadToRemove); 

                var buildingToRemove = Buildings.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (buildingToRemove != null)
                    Buildings.Remove(buildingToRemove);

                EmptySpot objectPlaced = new EmptySpot(possitionX, possitionY);
                (EmptySpotFromWorldPosition(InputManager.MouseX, InputManager.MouseY) as EmptySpot)
                    .Change(objectPlaced);
                Buildings.Add(objectPlaced);

                _waitTime = 15;
                InputManager.Update();
            }else if (id == 4)
            {
                var roadToRemove = city.MyRoads.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (roadToRemove != null)
                    city.MyRoads.Remove(roadToRemove); 

                var buildingToRemove = Buildings.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (buildingToRemove != null)
                    Buildings.Remove(buildingToRemove); 

                Policestation objectPlaced = new Policestation(possitionX, possitionY);
                (EmptySpotFromWorldPosition(InputManager.MouseX, InputManager.MouseY) as EmptySpot)
                    .Change(objectPlaced);
                Buildings.Add(objectPlaced);

                _waitTime = 15;
                InputManager.Update();
            }
            else if (id == 5)
            {
                var roadToRemove = city.MyRoads.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (roadToRemove != null)
                    city.MyRoads.Remove(roadToRemove); 

                var buildingToRemove = Buildings.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (buildingToRemove != null)
                    Buildings.Remove(buildingToRemove); 

                ShopHouse objectPlaced = new ShopHouse(possitionX, possitionY);
                (EmptySpotFromWorldPosition(InputManager.MouseX, InputManager.MouseY) as EmptySpot)
                    .Change(objectPlaced);
                Buildings.Add(objectPlaced);

                _waitTime = 15;
                InputManager.Update();
            }
            else if (id == 6)
            {
                var roadToRemove = city.MyRoads.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (roadToRemove != null)
                    city.MyRoads.Remove(roadToRemove); 

                var buildingToRemove = Buildings.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (buildingToRemove != null)
                    Buildings.Remove(buildingToRemove); 

                ResidenceHouse objectPlaced = new ResidenceHouse(possitionX, possitionY);
                (EmptySpotFromWorldPosition(InputManager.MouseX, InputManager.MouseY) as EmptySpot)
                    .Change(objectPlaced);
                Buildings.Add(objectPlaced);

                _waitTime = 15;
                InputManager.Update();
            }
            else if (id == 8)
            {
                var roadToRemove = city.MyRoads.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (roadToRemove != null)
                    city.MyRoads.Remove(roadToRemove); 

                var buildingToRemove = Buildings.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (buildingToRemove != null)
                    Buildings.Remove(buildingToRemove); 

                TrafficLight objectPlaced = new TrafficLight(possitionX, possitionY);
                (EmptySpotFromWorldPosition(InputManager.MouseX, InputManager.MouseY) as EmptySpot)
                    .Change(objectPlaced);
                Buildings.Add(objectPlaced);

                _waitTime = 15;
                InputManager.Update();
            }
            else if (id == 13)
            {
                var roadToRemove = city.MyRoads.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (roadToRemove != null)
                    city.MyRoads.Remove(roadToRemove); 

                var buildingToRemove = Buildings.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (buildingToRemove != null)
                    Buildings.Remove(buildingToRemove); 

                WorkBuilding objectPlaced = new WorkBuilding(possitionX, possitionY);
                (EmptySpotFromWorldPosition(InputManager.MouseX, InputManager.MouseY) as EmptySpot)
                    .Change(objectPlaced);
                Buildings.Add(objectPlaced);

                _waitTime = 15;
                InputManager.Update();
            }
            else if (id == 12)
            {
                var roadToRemove = city.MyRoads.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (roadToRemove != null)
                    city.MyRoads.Remove(roadToRemove);

                var buildingToRemove = Buildings.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (buildingToRemove != null)
                    Buildings.Remove(buildingToRemove);

                FireDepartment objectPlaced = new FireDepartment(possitionX, possitionY);
                (EmptySpotFromWorldPosition(InputManager.MouseX, InputManager.MouseY) as EmptySpot)
                    .Change(objectPlaced);
                Buildings.Add(objectPlaced);

                _waitTime = 15;
                InputManager.Update();
            }
            else if (id == 11)
            {
                var roadToRemove = city.MyRoads.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (roadToRemove != null)
                    city.MyRoads.Remove(roadToRemove);

                var buildingToRemove = Buildings.SingleOrDefault(r => r.PosX == possitionX && r.PosY == possitionY);
                if (buildingToRemove != null)
                    Buildings.Remove(buildingToRemove);

                Hospital objectPlaced = new Hospital(possitionX, possitionY);
                (EmptySpotFromWorldPosition(InputManager.MouseX, InputManager.MouseY) as EmptySpot)
                    .Change(objectPlaced);
                Buildings.Add(objectPlaced);

                _waitTime = 15;
                InputManager.Update();
            }

        }

        public IRender EmptySpotFromWorldPosition(float x, float y)
        {
            int offset = 32;

            int newX = Convert.ToInt32(Math.Floor(x / offset));
            int newY = Convert.ToInt32(Math.Floor(y / offset));

            IRender spot;
            try
            {

                spot = city.MyEmptySpots[newX, newY];
            }
            catch (Exception e)
            {
                spot = city.MyEmptySpots[0, 0];
                
            }
            Console.WriteLine("newX: " + newX + " newY: " + newY);


            Console.WriteLine("EM-X: " + (spot as EmptySpot).PosX + " EM-Y: " + (spot as EmptySpot).PosY + "Type :" +
                              spot.GetType());

            return spot;
        }
        
        public void testAI()
        {
            city.MyVehicles.Add(new CivilianVehicle(city.MyConstructions[0], city.MyConstructions, city.MyRoads2));
        }

        public Panel InfoShow(EmptySpot selectedSpot)
        {
            //a = Buildings[0] as EmptySpot;
            //Thats selecting building panel
            panelShowInfo.Size = new Vector2(400, 600);
            string currentX = "Current X = " + selectedSpot.PosX;
            
            string currentY = "Current Y = " + selectedSpot.PosY;
           
            panelShowInfo.AddChild(new Header(currentX));
            TextInput textX = new TextInput(true);
            textX.Size = new Vector2(0, 100);
            
            panelShowInfo.AddChild(textX);
            panelShowInfo.AddChild(new Header(currentX));
            TextInput textY = new TextInput(true);
            textY.Size = new Vector2(0, 100);
            panelShowInfo.AddChild(textY);
            panelShowInfo.AddChild(new Header(currentY));
            
            if (selectedSpot.CurrentEmptySpot is Policestation)
            {
               Policestation police = (selectedSpot.CurrentEmptySpot as Policestation);
            }
          else if(selectedSpot.CurrentEmptySpot is ResidenceHouse)
            {
                ResidenceHouse residence = (selectedSpot.CurrentEmptySpot as ResidenceHouse);
            }
          else if(selectedSpot.CurrentEmptySpot is Road)
            {
                Road rd = selectedSpot.CurrentEmptySpot as Road;
                string roadinfo = " Fconst " + rd.HCost;
                

            }
            else {
                EmptySpot emp = selectedSpot.CurrentEmptySpot as EmptySpot;
            }
            panelShowInfo.Visible = true;
            Button button_ShowInfo_exit = new Button("Back", anchor: Anchor.BottomLeft, size: new Vector2(250, -1), offset: new Vector2(0, 0));
            button_ShowInfo_exit.OnClick = (GeonBit.UI.Entities.Entity btn) => { panelShowInfo.ClearChildren(); panelShowInfo.Visible = false; };
            panelShowInfo.AddChild(button_ShowInfo_exit);
            Button button_ShowInfo_apply = new Button("Apply", anchor: Anchor.BottomRight, size: new Vector2(250, -1), offset: new Vector2(0, 0));
            button_ShowInfo_apply.OnClick = (GeonBit.UI.Entities.Entity btn) => { if (selectedSpot.CurrentEmptySpot is Road) { (selectedSpot.CurrentEmptySpot as Road).PosX = Convert.ToInt32(textX.Value); (selectedSpot.CurrentEmptySpot as Road).PosY = Convert.ToInt32(textY.Value); } selectedSpot.PosX = Convert.ToInt32(textX.Value); selectedSpot.PosY = Convert.ToInt32(textY.Value); };
            panelShowInfo.AddChild(button_ShowInfo_apply);
            return panelShowInfo;
        }

    }
}
