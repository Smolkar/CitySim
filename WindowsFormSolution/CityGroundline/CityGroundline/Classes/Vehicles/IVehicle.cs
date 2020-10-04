using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGroundline
{
    public interface IVehicle
    {
        int X { get; set; }

        int Y { get; set; }

        AI MyAI { get; set; }

        string Name { get; set; }

        int ID { get; set; }

        void drawYourSelf(Graphics g);

        string getInfo();

    }
}
