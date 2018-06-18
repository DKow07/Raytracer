using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;
using RayTracer.Renderer;

namespace RayTracer.Object
{
    public class Sphere : Primitive
    {

        private double radius;
        private Vector3 origin;

        #region CONSTRUCTORS
        public Sphere()
        {
            this.origin = new Vector3();
            this.radius = 1;
        }

        public Sphere(Vector3 origin)
        {
            this.origin = origin;
            this.radius = 1;
        }

        public Sphere(Vector3 origin, double radius)
        {
            this.origin = origin;
            this.radius = radius;
        }

        public Sphere(double x, double y, double z, double radius)
        {
            this.origin = new Vector3(x, y, z);
            this.radius = radius;
        }
        #endregion

        #region GETTERS_AND_SETTERS
        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if(radius < 0)
                {
                    Console.WriteLine("Radius can't be smaller than 0");
                    return;
                }
                this.radius = value;
            }
        }

        public Vector3 Origin
        {
            get
            {
                return this.origin;
            }
            set
            {
                this.origin = value;
            }
        }
        #endregion

        #region MATH
        public override bool Hit(Ray ray, ref double distance, ref Vector3 normal)
        {
            double t;
            Vector3 tmp = ray.origin - this.origin;
            double a = (ray.direction).Dot(ray.direction);
            double b = 2.0 * tmp.Dot(ray.direction);
            double c = tmp.Dot(tmp) - this.radius * this.radius;
            double disc = b * b - 4.0 * a * c;

            double kEpsilon = Ray.Epsilon;

            if (disc < 0.0)
            {
                return false;
            }
            else
            {
                double e = Math.Sqrt(disc);
                double denom = 2.0 * a;
                t = (-b - e) / denom;

                if (t > kEpsilon)
                {
                    Vector3 hitPoint = (ray.origin + ray.direction * (double)t);
                    normal = (hitPoint - this.origin).Normalized();
                    distance = t;
                    return true;
                }

                t = (-b + e) / denom;

                if (t > kEpsilon)
                {
                    
                    Vector3 hitPoint = (ray.origin + ray.direction * (double)t);
                    normal = (hitPoint - this.origin).Normalized();
                    distance = t;
                    return true;
                }

            }

            return false;
        }
        #endregion
    }
}
