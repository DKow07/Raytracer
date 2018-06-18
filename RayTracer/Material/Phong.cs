using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;
using RayTracer.Light;


namespace RayTracer.Material
{
    public class Phong : Material
    {
        RGBColor materialColor;
        double diffuseCoeff;
        double specular;
        double specularExponent;

        public Phong(RGBColor materialColor, double diffuse,
                double specular,
                double specularExponent)
        {
            this.materialColor = materialColor;
            this.diffuseCoeff = diffuse;
            this.specular = specular;
            this.specularExponent = specularExponent;
        }

        double PhongFactor(Vector3 inDirection, Vector3 normal, Vector3 toCameraDirection)
        {
            Vector3 reflected = Vector3.Reflect(inDirection, normal);
            double cosAngle = reflected.Dot(toCameraDirection);
            if (cosAngle <= 0) 
            {
                return 0; 
            }
            return Math.Pow(cosAngle, specularExponent);
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
                if (hit.World.AnyObstacleBetween(hit.HitPoint, light.position))
                {
                    continue;
                }
                RGBColor result = light.color * materialColor * diffuseFactor * diffuseCoeff;
                double phongFactor = PhongFactor(inDirection, hit.Normal, -hit.Ray.direction);
                if (phongFactor != 0)
                {
                    result += materialColor * specular * phongFactor;
                }
                totalColor += result;
            }
            
            return totalColor;
        }
    }
}
