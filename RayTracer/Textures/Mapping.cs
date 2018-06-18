using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;

namespace RayTracer.Textures
{
    public abstract class Mapping
    {
        public abstract void GetTexelCoordinates(Vector3 hitPoint, int hRes, int vRes, out int row, out int column);
    }
}
