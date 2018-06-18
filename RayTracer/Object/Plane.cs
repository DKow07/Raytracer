using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;
using RayTracer.Renderer;
using RayTracer.Material;


namespace RayTracer.Object
{
    public class Plane : Primitive
    {
        public Vector3 position;
        public Vector3 normal;

        public Plane()
        {
            this.position = new Vector3(0.0f, 0.0f, 0.0f);
            this.normal = new Vector3(0.0f, 0.0f, 0.0f);
        }

        public Plane(Vector3 position, Vector3 normal)
        {
            this.position = position;
            this.normal = normal;
        }

        public override bool Hit(Ray ray, ref double distance, ref Vector3 normal)
        {
            double t = (this.position - ray.origin).Dot(this.normal) / (ray.direction.Dot(this.normal));

            double kEpsilon = Ray.Epsilon;

            if (t > kEpsilon)
            {
                distance = t;
                normal = this.normal;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
