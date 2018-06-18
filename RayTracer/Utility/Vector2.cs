using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Utility
{
    public class Vector2
    {

        public double x;
        public double y;

        #region CONSTRUCTORS
        public Vector2()
        {
            this.x = 0f;
            this.y = 0f;
        }

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        public static Vector2 operator * (Vector2 v, double scallar)
        {
            return new Vector2(v.x * scallar, v.y * scallar);
        }
        public static Vector2 operator *(double scallar, Vector2 v)
        {
            return new Vector2(v.x * scallar, v.y * scallar);
        }

        public void Display()
        {
            Console.WriteLine("Vector2 " + this.x + " " + this.y);
        }
    }
}
