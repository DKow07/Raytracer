using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Renderer;
using RayTracer.Utility;
using System.Drawing;
using System.IO;
using RayTracer.Sampler;
using RayTracer.Material;

namespace RayTracer.Camera
{
    public class OrthogonalCamera : Camera
    {
        public int width;
        public int height;

        public OrthogonalCamera(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        public override Ray GetRayTo(Vector2 relativeLocation)
        {
            return new Ray(new Vector3((float)relativeLocation.x, (float)relativeLocation.y, 0), new Vector3(0, 0, 1));
        }

        public override void RenderScene(Renderer.World world)
        {
            RGBColor pixelColor;
            Ray ray = new Ray();
            double zw = 100.0;
            double x, y;

            Vector2 sp;
            Vector2 pp = new Vector2();

            ray.direction = new Vector3(0,0,-1);

            Console.WriteLine("Number objects on scene = " + world.objects.Count);
            Console.WriteLine("Number lights on scene = " + world.lights.Count);
            Console.WriteLine("Render start - orthogonal camera");
            for(int r = 0; r < height; r++)
            {
               for(int c = 0; c < width; c++)
               {

                   pixelColor = RGBColor.BLACK;

                   for(int j = 0; j < world.jittered.numSamples; j++)
                   {
                       sp = world.jittered.SampleUnitSquare();
                       double tmpPixelSize = 0.2;
                       pp.x = tmpPixelSize * (c - 0.5 * width + sp.x);

                       //zaczynamy od ćwiartki II, tak to -60 i -60, więc y odwrócone
                       pp.y = tmpPixelSize * (r - 0.5 * height + sp.y);
                       pp.y = pp.y * -1;

                       ray.origin = new Vector3(pp.x, pp.y, zw);
                       int depthRef = 0;
                       pixelColor = pixelColor + world.tracer.ShadeRay(world, ray, ref depthRef);
                   }

                   pixelColor = pixelColor / world.jittered.numSamples;
                   //writeToFile.WriteLine( pixelColor.r + " " + pixelColor.g + " " + pixelColor.b);
                   bitmap.SetPixel(c, r, RGBColor.StripColor(pixelColor));
               }
            }
            bitmap.Save("renderBitmap.bmp");
            Console.WriteLine("Finish render");
        }

       /* public override RGBColor ShadeRay(World world, Ray ray)
        {
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
                catch(Exception e)
                {

                }
            }
            return finalColor;
        }*/
    }
}
