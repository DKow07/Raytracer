using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Renderer;
using RayTracer.Utility;
using System.Drawing;

namespace RayTracer.Camera
{
    class PerspectiveCamera : Camera
    {

        public Vector3 eye;
        public Vector3 lookAt;
        public Vector3 up;
        public Vector3 u, v, w;
        public float distance;
        public int width;
        public int height;

        public PerspectiveCamera()
        {
            this.eye = new Vector3();
            this.lookAt = new Vector3();
            this.up = new Vector3(0, 1, 0);
            this.distance = 0f;
            this.u = new Vector3();
            this.v = new Vector3();
            this.w = new Vector3();
        }

        public PerspectiveCamera(Vector3 eye, Vector3 lookAt, float distance, int width, int height)
        {
            this.eye = eye;
            this.lookAt = lookAt;
            this.up = new Vector3(0, 1, 0);
            this.distance = distance;
            this.u = new Vector3();
            this.v = new Vector3();
            this.w = new Vector3();
            this.width = width;
            this.height = height;
            this.bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            ComputeUVW();
        }

        public void ComputeUVW()
        {
            this.w = eye - lookAt;
            this.w = this.w.Normalized();
            this.u = this.up.Cross(this.w);
            this.u = this.u.Normalized();
            this.v = this.w.Cross(this.u);
            Console.WriteLine("Compute UVW");
        }

        public Vector3 RayDirection(Vector2 point)
        {
            Vector3 dir = this.u * point.x + this.v * point.y - this.w * distance; //-distance
            dir = dir.Normalized();
            return dir;
        }

        public override Ray GetRayTo(Vector2 relativeLocation)
        {
            return new Ray(eye, RayDirection(relativeLocation)); //eye == origin
        }

        public override void RenderScene(World world)
        {
            RGBColor pixelColor;
            Ray ray = new Ray();
            double zw = 100.0;
            double x, y;

            Vector2 sp;
            Vector2 pp = new Vector2();

            ray.origin = this.eye;

            Console.WriteLine("Number objects on scene = " + world.objects.Count);
            Console.WriteLine("Number lights on scene = " + world.lights.Count);
            Console.WriteLine("Render start - perspective camera");
            for (int r = 0; r < height; r++)
            {
                if(r % 10 == 0)
                {
                    Console.WriteLine("pika " + r);
                }
                for (int c = 0; c < width; c++)
                {

                    pixelColor = RGBColor.BLACK;

                    for (int j = 0; j < world.jittered.numSamples; j++)
                    {
                        sp = world.jittered.SampleUnitSquare();
                        double tmpPixelSize = 0.2;
                        pp.x = tmpPixelSize * (c - 0.5 * width + sp.x);

                        //zaczynamy od ćwiartki II, tak to -60 i -60, więc y odwrócone
                        pp.y = tmpPixelSize * (r - 0.5 * height + sp.y);
                        pp.y = pp.y * -1;
                        ray.direction = RayDirection(pp);
                        int depthRef = 0;
                        pixelColor = pixelColor + world.tracer.ShadeRay(world, ray, ref depthRef);
                    }

                    pixelColor = pixelColor / world.jittered.numSamples;
                    bitmap.SetPixel(c, r, RGBColor.StripColor(pixelColor));
                }
            }
            bitmap.Save("renderPerspectiveBitmap.bmp");
            Console.WriteLine("Finish render");
        }

      /*  public override RGBColor ShadeRay(World world, Ray ray)
        {
            //Console.WriteLine("ShadeRay");
            HitInfo info = world.tracer.TraceRay(ray);
            if (info.HitObject == null)
            {
                return world.backgroundColor;
            }

            RGBColor finalColor = RGBColor.BLACK;
            Material.Material material = info.HitObject.Material;
            foreach (var light in world.lights)
            {
                if (world.AnyObstacleBetween(info.HitPoint, light.position))
                {
                    continue;
                }
                try
                {
                    finalColor += material.Radiance(light, info);
                }
                catch (Exception e)
                {

                }
            }
            return finalColor;
        }*/
    }
}
