using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;
using RayTracer.Light;

namespace RayTracer.Material
{
    public class Lambertian : Material
    {
        RGBColor materialColor;
        
        public Lambertian(RGBColor materialColor)
        {
            this.materialColor = materialColor;
        }

        public RGBColor Radiance(HitInfo hit, int depth)
        {
            RGBColor totalColor = RGBColor.BLACK;
            foreach(var light in hit.World.lights)
            {
                Vector3 inDirection = (light.position - hit.HitPoint).Normalized();
                double diffuseFactor = inDirection.Dot(hit.Normal);
                if (diffuseFactor < 0)
                {
                    continue;
                }
                if(hit.World.AnyObstacleBetween(hit.HitPoint, light.position))
                {
                    continue;
                }
                totalColor += light.color * materialColor * diffuseFactor;
            }

            return totalColor;
        }
    }
}
