using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Object;
using RayTracer.Utility;
using RayTracer.Camera;
using RayTracer.Sampler;
using RayTracer.Light;
using RayTracer.Material;
using System.Drawing;
using RayTracer.Textures;

namespace RayTracer.Renderer
{
    public class World
    {
        public List<PointLight> lights;
        public List<Primitive> objects;
        public RGBColor backgroundColor;
        public Camera.Camera camera;
        public Jittered jittered;
        public Tracer tracer;

        public void Build()
        {
            lights = new List<PointLight>();
            objects = new List<Primitive>();
            backgroundColor = RGBColor.BLACK;
            //camera = new OrthogonalCamera(600, 480);
            int sceneWidth = 240;
            int sceneHeight = 240;
            camera = new PerspectiveCamera(new Vector3(0, 0, 80), new Vector3(0,0,-1), 50, sceneWidth, sceneHeight); //50
            jittered = new Jittered(9);
            //tracer = new MultipleObjectsTracer(this);

            tracer = new Whitted(this, 10);

            Material.Material orangeMaterial = new Phong(Color.Orange, 0.8, 1, 30);
            Material.Material redMaterial = new Lambertian(Color.PowderBlue);
            Material.Material blueMaterial = new Lambertian(RGBColor.NAVY_BLUE);
            Material.Material grayMaterial = new Phong(Color.LightGray, 0.8, 1, 30);
            Material.Material yellowMaterial = new Phong(Color.Yellow, 0.8, 1, 30);
            Material.Material skyBlueMaterial = new Phong(Color.SkyBlue, 0.8, 1, 30);
            Material.Material refMat = new Reflective(RGBColor.WHITE, 0, 1, 350, 1);
            Material.Material refMat1 = new Reflective(RGBColor.WHITE, 0.5, 1, 350, 0.5);
            Material.Material lamb = new Lambertian(RGBColor.SKY_BLUE);
            Material.Material refractiveMat = new Refractive(RGBColor.WHITE, 0, 1, 350, 1);


            Quad wall1 = new Quad(new Vector3(-30, 30, 30), new Vector3(-30, -30, 30), new Vector3(-15, 15, -15), new Vector3(-15, - 15, - 15));
            //wall1.AddQuadToScene(this, skyBlueMaterial);


            Triangle t1 = new Triangle(new Vector3(-30, 30, 30), new Vector3(-30, -30, 30), new Vector3(-20, 20, -15), new Vector3(1,0,0));
            t1.Material = redMaterial;
            AddObject(t1);
            Triangle t2 = new Triangle(new Vector3(-30, -30, 30), new Vector3(-20, 20, -15), new Vector3(-20, -20, -15), new Vector3(1, 0, 0));
            t2.Material = redMaterial;
            AddObject(t2);

            Triangle t3 = new Triangle(new Vector3(30, 30, 30), new Vector3(30, -30, 30), new Vector3(20, 20, -15), new Vector3(-1, 0, 0));
            t3.Material = blueMaterial;
            AddObject(t3);
            Triangle t4 = new Triangle(new Vector3(30, -30, 30), new Vector3(20, 20, -15), new Vector3(20, -20, -15), new Vector3(-1, 0, 0));
            t4.Material = blueMaterial;
            AddObject(t4);

            Triangle t5 = new Triangle(new Vector3(-30, -30, 30), new Vector3(-20, -20, -15), new Vector3(30, -30, 30), new Vector3(0, 1, 0));
            t5.Material = grayMaterial;
            AddObject(t5);
            Triangle t6 = new Triangle(new Vector3(30, -30, 30), new Vector3(-20, -20, -15), new Vector3(20, -20, -15), new Vector3(0, 1, 0));
            t6.Material = grayMaterial;
            AddObject(t6);

            Triangle t7 = new Triangle(new Vector3(-20, 20, -15), new Vector3(-20, -20, -15), new Vector3(20, 20, -15), new Vector3(0, 0, 1));
            t7.Material = grayMaterial;
            AddObject(t7);
            Triangle t8 = new Triangle(new Vector3(20, 20, -15), new Vector3(20, -20, -15), new Vector3(-20, -20, -15), new Vector3(0, 0, 1));
            t8.Material = grayMaterial;
            AddObject(t8);

            Triangle t9 = new Triangle(new Vector3(-30, 30, 30), new Vector3(30, 30, 30), new Vector3(-20, 20, -15), new Vector3(0, -1, 0));
            t9.Material = grayMaterial;
            AddObject(t9);
            Triangle t10 = new Triangle(new Vector3(30, 30, 30), new Vector3(-20, 20, -15), new Vector3(20, 20, -15), new Vector3(0, -1, 0));
            t10.Material = grayMaterial;
            AddObject(t10);

            Sphere sphere = new Sphere(new Vector3(-5,10,10), 8);
            sphere.Material = refractiveMat;
            AddObject(sphere);

            Sphere sphere1 = new Sphere(new Vector3(10,0, 12), 5);
            sphere1.Material = orangeMaterial;
            AddObject(sphere1);

            sphere1 = new Sphere(new Vector3(-4, -6, 15), 6);
            sphere1.Material = refMat;
            AddObject(sphere1);

            Plane plane = new Plane(new Vector3(0, -5, 0), new Vector3(0, 1, 0));
            plane.Material = orangeMaterial;
            //AddObject(plane);

            Mesh mesh = new Mesh("ico.obj");
           // mesh.AddModelToScene(this, yellowMaterial);

            PointLight light = new PointLight(new Vector3(0, 17, 50), RGBColor.WHITE);
            AddLight(light);
            /*sphere = new Sphere(new Vector3(0, -10, 0), 5);
            sphere.Material = yellowMaterial;
            //AddObject(sphere);

            Triangle triangle = new Triangle(new Vector3(0, 0, 10), new Vector3(10, 0, 10), new Vector3(10, 10, 10), new Vector3(0, 0, 1));
            triangle.Material = orangeMaterial;
            //AddObject(triangle);

            Mesh mesh = new Mesh("ico.obj");
            mesh.AddModelToScene(this, yellowMaterial);

            Plane plane = new Plane(new Vector3(0,0,-40), new Vector3(0,0,1));
            Material.Material lamb2 = new Lambertian(RGBColor.DARK_SALMON);
            Material.Material refMat = new Reflective(RGBColor.GREEN, 0.8, 1, 30, 0.1);
            plane.Material = lamb2;
            AddObject(plane);*/

           // PointLight light = new PointLight(new Vector3(-25, 0, 20), Color.White);
           // AddLight(light);

           // PointLight light1 = new PointLight(new Vector3(25, 0, 20), Color.White);
           // AddLight(light1);

            

           // Sphere sphere = new Sphere(new Vector3(0, 0, 0), 10);
           /* Triangle t7 = new Triangle(new Vector3(0, 0, 0), new Vector3(10, 0, 0), new Vector3(10, 10, 0), new Vector3(0, 0, 1));
            t7.Material = grayMaterial;
       

            Bitmap textureBitmap = new Bitmap("test.png");
            RectangularMapping sphericalMapping = new RectangularMapping();
            ImageTexture imageTexture = new ImageTexture(textureBitmap, sphericalMapping);
           
            LambertianTexture textureMaterial = new LambertianTexture(imageTexture);


            t7.Material = textureMaterial;
            AddObject(t7);
            PointLight light = new PointLight(new Vector3(20, 0, 40), Color.White);
            AddLight(light);*/


        }

       /* public HitInfo TraceRay(Ray ray)
        {
           // Console.WriteLine("TraceRay");
            HitInfo result = new HitInfo();
            Vector3 normal = default(Vector3);
            double minimalDistance = Ray.Huge; 
            double lastDistance = 0; 
            foreach (var obj in objects)
            {
                if (obj.Hit(ray, ref lastDistance, ref normal) && lastDistance < minimalDistance) 
                {
                    minimalDistance = lastDistance; 
                    result.HitObject = obj;
                    result.Normal = normal; 
                }

            }
            if (result.HitObject != null) 
            {
                result.HitPoint = ray.origin + ray.direction * (float)minimalDistance;
                result.Ray = ray;
                result.World = this;
                result.Material = result.HitObject.Material;
            }
            return result;
        }
        */
        public bool AnyObstacleBetween(Vector3 pointA, Vector3 pointB)
        {
           // Console.WriteLine("AnyObstacleBetween");
            Vector3 vectorAB = pointB - pointA;
            double distAB = vectorAB.Length();
            double currDistance = Ray.Huge;
            Ray ray = new Ray(pointA, vectorAB);
            Vector3 ignored = default(Vector3);
            foreach (var obj in objects)
            {
                if (obj.Hit(ray, ref currDistance, ref ignored) && currDistance < distAB) { return true; }
            }
            // obiekt nie jest w cieniu
            return false;
        }

        public void AddLight(PointLight light)
        {
            lights.Add(light);
        }

        public void AddObject(Primitive obj)
        {
            objects.Add(obj);
        }
    }
}
