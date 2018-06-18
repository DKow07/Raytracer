using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;


namespace RayTracer.Textures
{
    public abstract class Texture
    {

        public abstract RGBColor GetColor(ref HitInfo hitInfo);

    }
}
