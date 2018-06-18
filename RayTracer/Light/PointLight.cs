using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;
using alglib;

namespace RayTracer.Light
{
    public class PointLight
    {
        public Vector3 position;
        public RGBColor color;

        public PointLight(Vector3 position, RGBColor color)
        {
            this.position = position;
            this.color = color;
        }
    }
}
