using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace CityGroundline
{
    [Serializable]
    public class Road : Construction, IComparable<Road>
    {
        private List<Road> _MySuccessors;
        private double _G; //
        private double _H;
        private double _F;
        private Road _ParentRoad; //parent road object is a road object to reach this road

        public Road(int x, int y):base(x,y)
        {
            this.ConstructionName = "A Road";
            _MySuccessors = new List<Road>(4);
            _G = 1;
            _H = 10000;
            _ParentRoad = null;
        }

        public Road() : base()
        {
            _MySuccessors = new List<Road>(4);
            _G = 1;
            _H = 10000;
            _ParentRoad = null;
        }

        public List<Road> MySuccessors
        {
            get
            {
                return _MySuccessors;
            }

            set
            {
                _MySuccessors = value;
            }
        }

        public double G
        {
            get
            {
                return this._G;
            }

            set
            {
                this._G = value;
            }
        }

        public double H
        {
            get
            {
                return this._H;
            }

            set
            {
                this._H = value;
            }
        }

        public Road ParentRoad
        {
            get
            {
                return this._ParentRoad;
            }

            set
            {
                this._ParentRoad = value;
            }
        }

        public double F
        {
            get
            {
                return this._F;
            }

            set
            {
                this._F = value;
            }
        }

        public override void drawYourSelf(Graphics g)
        {
            //g.DrawRectangle(new Pen(Color.Black), new Rectangle(this.X, this.Y, 50, 50));
            g.FillRectangle(new SolidBrush(Color.DarkGray), this.MyRectangle);
        }

        public double getF()
        {
            return this._G + this._H;
        }

        public void setH(int dx, int dy)
        {
            this.H = Math.Abs(this.X - dx) + Math.Abs(this.Y - dy);
        }

        public int CompareTo(Road other)
        {
            if (this.F < other.F)
            {
                return -1;
            }
            else if (this.F == other.F)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public List<Road> successorsWithoutParentRoad()
        {
            List<Road> temp = MySuccessors;
            temp.Remove(this.ParentRoad);
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




        
        //private static readonly MethodInfo CloneMethod = typeof(Object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);

        //public static bool IsPrimitive(this Type type)
        //{
        //    if (type == typeof(String)) return true;
        //    return (type.IsValueType & type.IsPrimitive);
        //}

        //public static Object Copy(this Object originalObject)
        //{
        //    return InternalCopy(originalObject, new Dictionary<Object, Object>(new ReferenceEqualityComparer()));
        //}
        //private static Object InternalCopy(Object originalObject, IDictionary<Object, Object> visited)
        //{
        //    if (originalObject == null) return null;
        //    var typeToReflect = originalObject.GetType();
        //    if (IsPrimitive(typeToReflect)) return originalObject;
        //    if (visited.ContainsKey(originalObject)) return visited[originalObject];
        //    if (typeof(Delegate).IsAssignableFrom(typeToReflect)) return null;
        //    var cloneObject = CloneMethod.Invoke(originalObject, null);
        //    if (typeToReflect.IsArray)
        //    {
        //        var arrayType = typeToReflect.GetElementType();
        //        if (IsPrimitive(arrayType) == false)
        //        {
        //            Array clonedArray = (Array)cloneObject;
        //            clonedArray.ForEach((array, indices) => array.SetValue(InternalCopy(clonedArray.GetValue(indices), visited), indices));
        //        }

        //    }
        //    visited.Add(originalObject, cloneObject);
        //    CopyFields(originalObject, visited, cloneObject, typeToReflect);
        //    RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect);
        //    return cloneObject;
        //}

        //private static void RecursiveCopyBaseTypePrivateFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect)
        //{
        //    if (typeToReflect.BaseType != null)
        //    {
        //        RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
        //        CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, info => info.IsPrivate);
        //    }
        //}

        //private static void CopyFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool> filter = null)
        //{
        //    foreach (FieldInfo fieldInfo in typeToReflect.GetFields(bindingFlags))
        //    {
        //        if (filter != null && filter(fieldInfo) == false) continue;
        //        if (IsPrimitive(fieldInfo.FieldType)) continue;
        //        var originalFieldValue = fieldInfo.GetValue(originalObject);
        //        var clonedFieldValue = InternalCopy(originalFieldValue, visited);
        //        fieldInfo.SetValue(cloneObject, clonedFieldValue);
        //    }
        //}
        //public static T Copy<T>(this T original)
        //{
        //    return (T)Copy((Object)original);
        //}

    }
}