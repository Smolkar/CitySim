using Microsoft.Xna.Framework.Input;

namespace CitySimMono.Input
{
    public static class InputManager
    {
        public static float MouseX { get; private set; }
        public static float MouseY { get; private set; }

        public static bool WIsPressed { get; private set; }
        public static bool AIsPressed { get; private set; }
        public static bool DIsPressed { get; private set; }
        public static bool SIsPressed { get; private set; }

        public static bool ArrowUpIsPressed { get; private set; }
        public static bool ArrowLeftIsPressed { get; private set; }
        public static bool ArrowRightIsPressed { get; private set; }
        public static bool ArrowDownIsPressed { get; private set; }

        public static bool SpaceIsPressed { get; private set; }
        public static bool EnterIsPressed { get; private set; }
        public static bool EscapeIsPressed { get; private set; }

        public static bool LeftButtomDown { get; private set; }
        public static bool RightButtomDown { get; private set; }

        public static bool F1IsPressed { get; private set; }
        public static bool F2IsPressed { get; private set; }
        public static bool F3IsPressed { get; private set; }
        public static bool F4IsPressed { get; private set; }

        public static bool ConsoleKey { get; private set; }

        public static void Update()
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            // W A S D
            WIsPressed = currentKeyboardState.IsKeyDown(Keys.W);
            AIsPressed = currentKeyboardState.IsKeyDown(Keys.A);
            DIsPressed = currentKeyboardState.IsKeyDown(Keys.D);
            SIsPressed = currentKeyboardState.IsKeyDown(Keys.S);

            // Arrow UP LEFT RIGHT DOWN
            ArrowUpIsPressed = currentKeyboardState.IsKeyDown(Keys.Up);
            ArrowLeftIsPressed = currentKeyboardState.IsKeyDown(Keys.Left);
            ArrowRightIsPressed = currentKeyboardState.IsKeyDown(Keys.Right);
            ArrowDownIsPressed = currentKeyboardState.IsKeyDown(Keys.Down);

            // SPACE ENTER ESCAPE
            SpaceIsPressed = currentKeyboardState.IsKeyDown(Keys.Space);
            EnterIsPressed = currentKeyboardState.IsKeyDown(Keys.Enter);
            EscapeIsPressed = currentKeyboardState.IsKeyDown(Keys.Escape);

            // Mouse
            LeftButtomDown = Mouse.GetState().LeftButton == ButtonState.Pressed;
            RightButtomDown = Mouse.GetState().RightButton == ButtonState.Pressed;
            MouseX = Mouse.GetState().X;
            MouseY = Mouse.GetState().Y;

            // F1 F2 F3 F4
            F1IsPressed = currentKeyboardState.IsKeyDown(Keys.F1);
            F2IsPressed = currentKeyboardState.IsKeyDown(Keys.F2);
            F3IsPressed = currentKeyboardState.IsKeyDown(Keys.F3);
            F4IsPressed = currentKeyboardState.IsKeyDown(Keys.F4);

            // Console Key
            ConsoleKey = currentKeyboardState.IsKeyDown(Keys.OemTilde);
        }
    }
}
