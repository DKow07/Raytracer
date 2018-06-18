using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.Utility;
using System.Drawing;
using RayTracer.Object;

namespace RayTracer.Textures
{
    public class ImageTexture : Texture
    {

        public int hRes;
        public int vRes;
        public Bitmap imageBitmap;
        public Mapping mapping;

        public ImageTexture(Bitmap bitmap, Mapping mapping)
        {
            this.imageBitmap = bitmap;
            this.vRes = bitmap.Height;
            this.hRes = bitmap.Width;
            this.mapping = mapping;
            Console.WriteLine("ImageTexture has been initalized");
        }

        public override RGBColor GetColor(ref HitInfo hitInfo)
        {
            int row=0, column=0;
            if(!mapping.Equals(null))
            {
                mapping.GetTexelCoordinates(hitInfo.HitPoint, this.hRes, this.vRes, out row, out column);

              // Console.WriteLine("getcolor " + column + " " + row);
            }
            else
            {
                row = (int)(hitInfo.V * (vRes - 1));
                column = (int)(hitInfo.U * (hRes - 1));
            }
            //Console.WriteLine("GETCOLOR txt ");
            //RGBColor rgbColor = new RGBColor(imageBitmap.GetPixel(row, column));
            imageBitmap.GetPixel(row, column);
            //Console.WriteLine("GETCOLOR txt ");
            RGBColor rgbColor = new RGBColor(imageBitmap.GetPixel(column, row));
            //RGBColor rgbColor = new RGBColor(imageBitmap.GetPixel(row, column));
            //rgbColor.Display();
            return rgbColor;
        }
    }
}
