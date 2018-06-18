using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;

namespace RayTracer.Sampler
{
    public class Jittered
    {

        public int numSamples;
        public int numSets;
        public List<Vector2> samples;
        public List<int> shuffledIndices;
        public long _count;
        public int jump;

        public Jittered(int numSamples)
        {
            this.numSamples = numSamples;
            samples = new List<Vector2>();
            GenerateSamples();
        }

        public Vector2 SampleUnitSquare()
        {
            Vector2 tmp = new Vector2();
            try
            {
                int i = (int)_count++ % (numSamples * numSets);
                tmp = samples[i];
            }
            catch(Exception e)
            {
               // Console.WriteLine("zero");
                tmp = samples[0];
            }
           

            return tmp;
        }

        public void GenerateSamples()
        {
            int n = (int) Math.Sqrt(this.numSamples);
            this.numSets = 1;
            int i = 0;

            for(int p = 0; p < numSets; p++)
            {
                for(int j = 0; j < n; j++)
                {
                    for(int k = 0; k < n; k++)
                    {
                      //  std::cout << "Probka nr " << i++ << std::endl;
                        Vector2 sp = new Vector2((k + RandomFloat(0.1, 0.2)) / n, (j + RandomFloat(0.1,0.2)) / n);
                        this.samples.Add(sp);
                    }
                }
            }
            Console.WriteLine("Probki wygenerowane " + this.samples.Count);
        }

        double RandomFloat(double a, double b)
        {
            Random rnd = new Random();
            double random = ((float)rnd.NextDouble()) / (float)0x7fff;
            double diff = b - a;
            double r = random * diff;
            return a + r;
        }


    }
}
