using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Utility
{
    public class Vector3
    {
        public double x;
        public double y;
        public double z;

        #region CONSTRUCTORS
        public Vector3()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion

        #region OPERATORS
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator *(Vector3 v, double scallar)
        {
            return new Vector3(v.x * scallar, v.y * scallar, v.z * scallar);
        }

        public static Vector3 operator *(double scallar, Vector3 v)
        {
            return new Vector3(v.x * scallar, v.y * scallar, v.z * scallar);
        }

        public static Vector3 operator /(Vector3 v, double scallar)
        {
            return new Vector3(v.x / scallar, v.y / scallar, v.z / scallar);
        }

        public static Vector3 operator /(double scallar, Vector3 v)
        {
            return new Vector3(v.x / scallar, v.y / scallar, v.z / scallar);
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.x, -v.y, -v.z);
        }

        #endregion

        #region MATH
        public double Dot(Vector3 vector)
        {
            return this.x * vector.x + this.y * vector.y + this.z * vector.z;
        }

        public Vector3 Cross(Vector3 vector)
        {
            double xCross = y * vector.z - z * vector.y;
            double yCross = z * vector.x - x * vector.z;
            double zCross = x * vector.y - y * vector.x;

            return new Vector3(xCross, yCross, zCross);
        }

        public static Vector3 Reflect(Vector3 vector, Vector3 normal)
        {
            double dot = normal.Dot(vector);
            return normal * (float)dot * 2 - vector;
        }


        public static Vector3 Refract(Vector3 incident,  Vector3 normal, double n1, double n2) 
        {
            double n = n1 / n2;
            double cosI = -normal.Dot(incident);
            double sinT2 = n * n * (1.0 - cosI * cosI);

            if (sinT2 > 1.0)
            {
                Console.WriteLine("Bad refraction vector!");
             
            }

            double cosT = Math.Sqrt(1.0 - sinT2);
            return incident * n + normal * (n * cosI - cosT);
        }

        /*public static Vector3 Refract(Vector3 I, Vector3 N, double ior)
        {
            double cosi = Clamp(I.Dot(N), -1, 1); 
            double etai = 1, etat = ior; 
            Vector3 n = N; 
            if (cosi < 0) 
            {
                cosi = -cosi;
            } 
            else
            { 
                double tmp = etat;
                etat = etai;
                etai = tmp;
                n= -N;
            } 
            double eta = etai / etat; 
            double k = 1 - eta * eta * (1 - cosi * cosi);
            Console.WriteLine("k " + k);
            n = eta * I + (eta * cosi - Math.Sqrt(k)) * n;
            n.Display()
            return k < 0 ? new Vector3() : n; 
        }*/
        
        public static T Clamp<T>(T aValue, T aMin, T aMax) where T : IComparable<T>
        {
            var _Result = aValue;
            if (aValue.CompareTo(aMax) > 0)
                _Result = aMax;
            else if (aValue.CompareTo(aMin) < 0)
                _Result = aMin;
            return _Result;
        }



        public double Length() //||A|| 
        {
            return Math.Sqrt(this.LengthSquared());
        }

        public double LengthSquared() //|A| 
        {
            return (Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        public Vector3 Normalized()
        {
            Vector3 v = new Vector3();
            v.x = x / (float)Length();
            v.y = y / (float)Length();
            v.z = z / (float)Length();

            return v;
        }
        #endregion

        #region UTILITY
        public void Display()
        {
            Console.WriteLine("Vector3 = (" + this.x + ", " + this.y + ", " + this.z + ")");
        }
        #endregion

    }
}
