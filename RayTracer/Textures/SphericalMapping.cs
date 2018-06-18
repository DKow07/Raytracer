using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;

namespace RayTracer.Textures
{
    public class SphericalMapping : Mapping
    {


        public override void GetTexelCoordinates(Vector3 hitPoint, int hRes, int vRes, out int row, out int column)
        {
            double theta = Math.Acos(hitPoint.y);
            double phi = Math.Atan2(hitPoint.x, hitPoint.z);
            if(phi < 0.0)
            {
                phi += 2 * 3.14;
            }
            double u = phi * (1 / (2 * 3.14));
            double v = 1 - theta * (1 / (3.14));

            column = (int)((hRes - 1) * u);
            row = (int)((vRes - 1) * v);

            //Console.WriteLine("texel " + column + " " + row); 
            /*double u = 0.5 + Math.Atan2(hitPoint.z, hitPoint.x) * (1 / (2 * 3.14));
            double v = 0.5 - Math.Asin(hitPoint.y) * (1 / (3.14));
            column =(int)(hRes*u);
            row =(int)(vRes*v);*/
        }
    }
}
