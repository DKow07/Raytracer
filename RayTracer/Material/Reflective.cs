using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Renderer;
using RayTracer.Utility;

namespace RayTracer.Material
{
    public class Reflective : Material
    {

        Phong direct;
        double reflectivity;
        RGBColor reflectionColor;

        public Reflective(RGBColor materialColor, double diffuse, double specular, double exponent, double reflectivity)
        {
            this.direct = new Phong(materialColor, diffuse, specular, exponent);
            this.reflectivity = reflectivity;
            this.reflectionColor = materialColor;
        }

        public RGBColor Radiance(HitInfo info, int depth)
        {
            Vector3 toCameraDirection = -info.Ray.direction;

            RGBColor radiance = direct.Radiance(info, depth);
            Vector3 reflectionDirection = Vector3.Reflect(toCameraDirection, info.Normal);
            
            Ray reflectedRay = new Ray(info.HitPoint, reflectionDirection);
            radiance += info.World.tracer.ShadeRay(info.World, reflectedRay, ref depth) * reflectionColor * reflectivity;
           
            return radiance;
        }
    }
}
