using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;

namespace RayTracer.Renderer
{
    public class Whitted : Tracer
    {

        public int maxDepth;
        public static int recursionDepth;

        public Whitted(World world, int maxDepth)
        {
            this.world = world;
            this.maxDepth = maxDepth;
            recursionDepth = 0;
        }

        public override HitInfo TraceRay(Ray ray, ref int depth)
        {
            HitInfo result = new HitInfo();
            Vector3 normal = default(Vector3);
            double minimalDistance = Ray.Huge;
            double lastDistance = 0;
            foreach (var obj in this.world.objects)
            {
                if (obj.Hit(ray, ref lastDistance, ref normal) && lastDistance < minimalDistance)
                {
                    minimalDistance = lastDistance;
                    result.HitObject = obj;
                    result.Normal = normal;
                }

            }
            if (result.HitObject != null)
            {
                result.HitPoint = ray.origin + ray.direction * (float)minimalDistance;
                result.Ray = ray;
                result.World = this.world;
                result.Material = result.HitObject.Material;
            }
            return result;
        }

        public override RGBColor ShadeRay(World world, Ray ray, ref int depth)
        {
            if((depth > this.maxDepth))
            {
                return RGBColor.BLACK;
            }

            HitInfo hit = TraceRay(ray, ref depth);
            if(hit.HitObject != null)
            {
                recursionDepth++;
                depth++;
                return hit.Material.Radiance(hit, depth);
            }
            else
            {
                return world.backgroundColor;
            }
        }
    }
}
