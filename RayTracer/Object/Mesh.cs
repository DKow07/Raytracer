using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;
using RayTracer.Renderer;
using RayTracer.Object;

namespace RayTracer.Object
{
    public class Mesh
    {
        public List<Triangle> triangles;
        private OBJParser parser;

        public Mesh(string fileName)
        {
            triangles = new List<Triangle>();
            parser = new OBJParser();
            if(parser.LoadRawModel(fileName))
            {
                this.triangles = parser.triangles;
            }
            else
            {
                Console.WriteLine("Error while creating mesh");
            } 
        }

        public void LoadModel(string fileName)
        {
            if (parser.LoadRawModel(fileName))
            {
                this.triangles = parser.triangles;
            }
            else
            {
                Console.WriteLine("Error while creating mesh");
            }
        }

        public void AddModelToScene(World world, Material.Material material)
        {
            foreach(Triangle triangle in this.triangles)
            {
                triangle.Material = material;
                world.AddObject(triangle);
            }
        }

    }
}
