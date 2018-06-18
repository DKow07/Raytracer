using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Light;
using RayTracer.Utility;

namespace RayTracer.Material
{
    public interface Material
    {
        RGBColor Radiance(HitInfo info, int depth);
    }
}
