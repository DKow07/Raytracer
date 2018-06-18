using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Object;
using System.IO;

namespace RayTracer.Utility
{
    public class OBJParser
    {

        public List<Vector3> vertices;
        public List<Vector2> textures;
        public List<int> indices;
        public List<Vector3> normals;
        public List<Triangle> triangles;

        public OBJParser()
        {
            vertices = new List<Vector3>();
            textures = new List<Vector2>();
            indices = new List<int>();
            normals = new List<Vector3>();
            triangles = new List<Triangle>();
        }

        public bool LoadRawModel(string fileName)
        {
            string objResult = String.Empty;
            try
            {
                StreamReader fileRead = new StreamReader(fileName);
                objResult = fileRead.ReadToEnd();
                fileRead.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error while parsing obj file");
                return false;
            }

            
            this.vertices.Clear();
            this.textures.Clear();
            this.indices.Clear();
            this.normals.Clear();
            this.triangles.Clear();

            string[] splittedObjFile = objResult.Split('\n');
            foreach(string currentLine in splittedObjFile)
            {
                string[] splittedLine = currentLine.Split(' ');

                if (currentLine.StartsWith("v "))
                {
                    try
                    {
                        Vector3 vertex = new Vector3(double.Parse(splittedLine[1].Replace(".", ",")), double.Parse(splittedLine[2].Replace(".", ",")), double.Parse(splittedLine[3].Replace(".", ",")));
                        vertices.Add(vertex);
                        Console.Write("vertex ");
                        vertex.Display();
                    }
                    catch(InvalidCastException e)
                    {
                        Console.WriteLine("Error while casting vertex");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Don't see any vertex");
                        Console.WriteLine(e.ToString());
                    }
                }
                else if(currentLine.StartsWith("vn "))
                {
                    try
                    {
                        Vector3 normal = new Vector3(Convert.ToDouble(splittedLine[1].Replace(".", ",")), Convert.ToDouble(splittedLine[2].Replace(".", ",")), Convert.ToDouble(splittedLine[3].Replace(".", ",")));
                        normals.Add(normal);
                        Console.Write("normal ");
                        normal.Display();
                    }
                    catch (InvalidCastException e)
                    {
                        Console.WriteLine("Error while casting normal");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Don't see any normal");
                    }
                }
                else if(currentLine.StartsWith("vt "))
                {
                    try
                    {
                        Vector2 texture = new Vector2(Convert.ToDouble(splittedLine[1]), Convert.ToDouble(splittedLine[2]));
                        textures.Add(texture);
                        Console.Write("texture ");
                        texture.Display();
                    }
                    catch (InvalidCastException e)
                    {
                        Console.WriteLine("Error while casting texture");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Don't see any texture");
                    }
                }
                else if(currentLine.StartsWith("f "))
                {
                    int vertexCount = splittedLine.Length-1;

                    string[] indices1 = splittedLine[1].Split('/');
                    string[] indices2 = splittedLine[2].Split('/');
                    string[] indices3 = splittedLine[3].Split('/');

                    Vector3 ind1 = new Vector3(double.Parse(indices1[0]), double.Parse(indices1[1]), double.Parse(indices1[2]));
                    Vector3 ind2 = new Vector3(double.Parse(indices2[0]), double.Parse(indices2[1]), double.Parse(indices2[2]));
                    Vector3 ind3 = new Vector3(double.Parse(indices3[0]), double.Parse(indices3[1]), double.Parse(indices3[2]));

                    switch(vertexCount)
                    {
                        case 3:
                            AddTriangle(vertices[(int)ind1.x - 1], vertices[(int)ind2.x - 1], vertices[(int)ind3.x - 1], ind1);
                            break;
                    }
                }
            }

            return true;

        }

        private void AddTriangle(Vector3 a, Vector3 b, Vector3 c, Vector3 n)
        {
            Triangle triangle = new Triangle(a, b, c);
            Console.WriteLine(normals.Count);
            if(normals.Count > 0)
            {
                triangle.normal = normals[(int)n.z-1];
            }
            else
            {
                //triangle liczy sam
            }
            triangles.Add(triangle);
            triangle.Display();
        }

    }
}
