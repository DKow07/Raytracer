using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;
using RayTracer.Textures;
using RayTracer.Light;

namespace RayTracer.Material
{
    public class LambertianTexture : Material
    {

        //RGBColor materialColor;
        Texture texture;
        public LambertianTexture(Texture texture)
        {
            this.texture = texture;
        }
        public RGBColor Radiance( HitInfo hit, int depth)
        {
            RGBColor totalColor = RGBColor.BLACK;
            foreach (var light in hit.World.lights)
            {
                Vector3 inDirection = (light.position - hit.HitPoint).Normalized();
                double diffuseFactor = inDirection.Dot(hit.Normal);
                if (diffuseFactor < 0)
                {
                    continue;
                }
                if (hit.World.AnyObstacleBetween(hit.HitPoint, light.position))
                {
                    continue;
                }
                totalColor += texture.GetColor(ref hit);
            }


            return totalColor;
        }
    }
}
