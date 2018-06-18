using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;
using RayTracer.Renderer;
using System.Drawing;

namespace RayTracer.Camera
{
    public abstract class Camera
    {

        public float pixelSize;
        public Bitmap bitmap;

        public abstract Ray GetRayTo(Vector2 relativeLocation);

        public abstract void RenderScene(World world);

        //public abstract RGBColor ShadeRay(World world, Ray ray);
        

    }
}
