using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitySimMono.Artifintel;
using CitySimMono.Graphics;

namespace CitySimMono.Entity.Cars
{
    public interface IVehicle : IRender
    {
        int PosX { get; set; }

        int PosY { get; set; }

        AI MyAI { get; set; }

        string Name { get; set; }

        int ID { get; set; }

        string getInfo();

    }
}
