using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;
using RayTracer.Renderer;

namespace RayTracer.Object
{
    public class Quad 
    {

        public Triangle triangle1;
        public Triangle triangle2;

        public Quad(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            this.triangle1 = new Triangle(a, b, c);
            this.triangle2 = new Triangle(b, c, d);
        }

        public void AddQuadToScene(World world, Material.Material material)
        {
            triangle1.Material = material;
            triangle2.Material = material;
            world.AddObject(triangle1);
            world.AddObject(triangle2);
        }

    }
}
