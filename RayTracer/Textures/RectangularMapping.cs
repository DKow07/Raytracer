using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;


namespace RayTracer.Textures
{
    public class RectangularMapping : Mapping
    {
        public override void GetTexelCoordinates(Vector3 hitPoint, int hRes, int vRes, out int row, out int column)
        {
            double u = (hitPoint.z + 1) / 2;
            double v = (hitPoint.x - 1) / 2;

            u /= hRes;
            v /= vRes;

            u = Math.Abs(u);
            v = Math.Abs(v);

            column = (int)((hRes - 1) * u);
            row = (int)((vRes - 1) * v);
        }
    }
}
