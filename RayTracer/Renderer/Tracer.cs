using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;

namespace RayTracer.Renderer
{
    public abstract class Tracer
    {
        public World world;
        public abstract HitInfo TraceRay(Ray ray,ref int depth);
        public abstract RGBColor ShadeRay(World world, Ray ray, ref int depth);

    }
}
