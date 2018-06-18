using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;
using RayTracer.Renderer;
using RayTracer.Material;

namespace RayTracer.Object
{
    abstract public class Primitive
    {

        public RGBColor color;

        public abstract bool Hit(Ray ray, ref double distance, ref Vector3 normal);
        public Material.Material Material { get; set; }


    }
}
