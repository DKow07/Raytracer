using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;

namespace RayTracer.Renderer
{
    public class Ray
    {
        public Vector3 origin;
        public Vector3 direction;

        public static double Epsilon = 0.00001;
        public static double Huge = double.MaxValue;

        public Ray()
        {
            this.origin = new Vector3();
            this.direction = new Vector3();
        }

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.origin = origin;
            this.direction = direction;
        }
    }
}
