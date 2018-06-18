using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer;
using RayTracer.Utility;
using RayTracer.Renderer;

namespace RayTracer
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World();
            Console.WriteLine("Build world");
            world.Build();
            Console.WriteLine("Render scene");
            world.camera.RenderScene(world);

            Console.ReadKey();
        }
    }
}
