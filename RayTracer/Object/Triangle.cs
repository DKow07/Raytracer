using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;

namespace RayTracer.Object
{
    public class Triangle : Primitive
    {
        public Vector3 v0, v1, v2;
        public Vector3 normal;

        public Triangle()
        {
            this.v0 = new Vector3();
            this.v1 = new Vector3(0, 0, 1);
            this.v2 = new Vector3(0, 1, 1);
            this.normal = new Vector3(0, 0, -1);
        }

        public Triangle(Vector3 v0, Vector3 v1, Vector3 v2)
        {
            this.v0 = v0;
            this.v1 = v1;
            this.v2 = v2;
            this.normal = CalculateNormal(v0, v1, v2);
        }

        public Triangle(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 normal)
        {
            this.v0 = v0;
            this.v1 = v1;
            this.v2 = v2;
            this.normal = normal;
        }

        private Vector3 CalculateNormal(Vector3 a, Vector3 b, Vector3 c)
        {
            Vector3 ba = b - a;
            Vector3 ca = c - a;
            normal = ba.Cross(ca);
            return normal.Normalized();
        }

        public override bool Hit(Renderer.Ray ray, ref double distance, ref Vector3 normal)
        {
            double A = v0.x - v1.x;
            double B = v0.x - v2.x;
            double C = ray.direction.x;
            double D = v0.x - ray.origin.x;

            double E = v0.y - v1.y;
            double F = v0.y - v2.y;
            double G = ray.direction.y;
            double H = v0.y - ray.origin.y;

            double I = v0.z - v1.z;
            double J = v0.z - v2.z;
            double K = ray.direction.z;
            double L = v0.z - ray.origin.z;

            //działania z równań na beta, gamma, t
            double M = F * K - G * J;
            double N = H * K - G * L;
            double P = F * L - H * J;
            double Q = G * I - E * K;
            double S = E * J - F * I;

            double invDenominator = 1.0 / (A * M + B * Q + C * S);

            double e1 = D * M - B * N - C * P;
            double beta = e1 * invDenominator;

            if (beta < 0.0)
            {
                return false;
            }

            double R = E * L - H * I;
            double e2 = A * N + D * Q + C * R;
            double gamma = e2 * invDenominator;

            if (gamma < 0.0)
            {
                return false;
            }
            if (beta + gamma > 1.0)
            {
                return false;
            }

            double e3 = A * P - B * R + D * S;
            double t = e3 * invDenominator;

            double kEpsilon = 0.000001;

            if (t < kEpsilon)
            {
                return false;
            }

            distance = t;
            normal = this.normal;


            return true;
        }

        public void Display()
        {
            Console.WriteLine("------------Triangle------------");
            this.v0.Display();
            this.v1.Display();
            this.v2.Display();            
            Console.Write("Normal = ");
            this.normal.Display();

        }
    }
}
