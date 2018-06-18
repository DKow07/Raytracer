using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;
using RayTracer.Renderer;

namespace RayTracer.Material
{
    public class Refractive : Material
    {
        Phong direct;
        double reflectivity;
        RGBColor reflectionColor;

        public Refractive(RGBColor materialColor, double diffuse, double specular, double exponent, double reflectivity)
        {
            this.direct = new Phong(materialColor, diffuse, specular, exponent);
            this.reflectivity = reflectivity;
            this.reflectionColor = materialColor;
        }

        public RGBColor Radiance(HitInfo info, int depth)
        {
            Vector3 toCameraDirection = -info.Ray.direction;

            RGBColor radiance = direct.Radiance(info, depth);
            if(depth % 2 == 0)
            {
                info.Normal = info.Normal * -1;
            }
            Vector3 reflectionDirection = (Vector3.Refract(toCameraDirection, info.Normal, 1, 1.5)).Normalized();
            
            Ray reflectedRay = new Ray(info.HitPoint, reflectionDirection);

            radiance += info.World.tracer.ShadeRay(info.World, reflectedRay, ref depth) * reflectionColor * reflectivity;
           
            return radiance;
        }
    }
}
