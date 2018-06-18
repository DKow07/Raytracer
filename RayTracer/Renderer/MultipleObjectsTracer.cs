using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;

namespace RayTracer.Renderer
{
    public class MultipleObjectsTracer : Tracer
    {

       

        public MultipleObjectsTracer(World world)
        {
            this.world = world;
        }

        public override HitInfo TraceRay( Ray ray,ref int depth)
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
            //Console.WriteLine("ShadeRay");
            int depthRef = 0;
            HitInfo info = this.world.tracer.TraceRay(ray, ref depthRef);
            if (info.HitObject == null)
            {
                return world.backgroundColor;
            }

            RGBColor finalColor = RGBColor.BLACK;
            Material.Material material = info.HitObject.Material;
            foreach (var light in world.lights)
            {
                if (world.AnyObstacleBetween(info.HitPoint, light.position))
                {
                    continue;
                }
                try
                {
                    finalColor += material.Radiance(info, 0);
                }
                catch (Exception e)
                {

                }
            }
            return finalColor;
        }
    }
}
