using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CityGroundline
{
    public class City
    {
        private List<Construction> _myConstructions;
        private List<Vehicle> _myVehicles;
        private List<Road> _myRoads;

        public City()
        {
            _myConstructions = new List<Construction>();
            _myRoads = new List<Road>();
            _myVehicles = new List<Vehicle>();
        }

        public List<Construction> MyConstructions
        {
            get
            {
                return _myConstructions;
            }

            set
            {
                _myConstructions = value;
                foreach (Construction c in this._myConstructions)
                {
                    if (c is Road)
                    {
                        _myRoads.Add((Road)c);
                    }
                }
            }
        }

        public List<Vehicle> MyVehicles
        {
            get
            {
                return this._myVehicles;
            }

            set
            {
                _myVehicles = value;
            }
        }

        public List<Road> MyRoads
        {
            get
            {
                return _myRoads;
            }

            set
            {
                MyRoads = value;
            }
        }
    }
}