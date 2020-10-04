using System;
using CitySimMono.World;

namespace CitySimMono
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class MainLauncher
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using (var game = new BaligoEngine())
                game.Run();
        }
    }
#endif
}
