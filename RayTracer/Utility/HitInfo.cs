using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Object;
using RayTracer.Renderer;

namespace RayTracer.Utility
{
    public class HitInfo
    {
        public Primitive HitObject { get; set; }
        public World World { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 HitPoint { get; set; }
        public Ray Ray { get; set; }
        public Material.Material Material { get; set; }
        public int U { get; set; }
        public int V { get; set; }
        public int Depth { get; set; }
    }
}
