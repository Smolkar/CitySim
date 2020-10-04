using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CitySimMono.Graphics;
using CitySimMono.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CitySimMono.Entity.Buildings
{

    [Serializable]
    public class Road : Construction, IRender, IComparable<Road>
    {
        // ID
        public string Id;

        public int ImageId;

        // Values
        public int GCost;
        public int HCost;
        public int FCost => GCost + HCost;

        //public Texture2D Texture { get; set; }

        //List of available roads
        public List<Road> MySuccessors;
        // Position in grid
        public int Row;
        public int Col;


        public Road Parent;


        // Constructor
        public Road(int xx, int yy) : base(xx, yy)
        {
            TextureId = 0;
            //Bounds = new Rectangle(0, 0, Texture.Width, Texture.Height);
            MySuccessors = new List<Road>();
            Row = xx;
            Col = yy;

            GCost = 1;
            HCost = 1000;

            Id = Row + " | " + Col;
        }

        public Road(int xx, int yy, int index) : base(xx, yy, index)
        {
            TextureId = 0;
            //Bounds = new Rectangle(0, 0, Texture.Width, Texture.Height);
            MySuccessors = new List<Road>();
            Row = xx;
            Col = yy;

            GCost = 1;
            HCost = 1000;

            Id = Row + " | " + Col;
        }


        public void setH(int dx, int dy)
        {
            this.HCost = Math.Abs(this.PosX - dx) + Math.Abs(this.PosY - dy);
        }

        public void Calc(int destX, int destY)
        {

            HCost = Math.Abs(Col - destX) +
                    Math.Abs(Row - destY);
        }


        public int CompareTo(Road other)
        {
            return this.FCost - other.FCost;
        }

        public List<Road> successorsWithoutParentRoad()
        {
            List<Road> temp = MySuccessors;
            temp.Remove(this.Parent);
            return temp;
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

        public void Init()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
