using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayTracer.Utility
{
    public class RGBColor
    {

        public double r;
        public double g;
        public double b;

        #region CONSTRUCTORS
        public RGBColor()
        {
            this.r = 0;
            this.g = 0;
            this.b = 0;
        }

        public RGBColor(double r, double g, double b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public RGBColor(Color color)
        {
            this.r = color.R;
            this.g = color.G;
            this.b = color.B;
        }
        #endregion

        #region OPERATORS
        public static RGBColor operator +(RGBColor c1, RGBColor c2)
        {
            return new RGBColor(c1.r + c2.r, c1.g + c2.g, c1.b + c2.b);
        }

        public static RGBColor operator -(RGBColor c1, RGBColor c2)
        {
            return new RGBColor(c1.r - c2.r, c1.g - c2.g, c1.b - c2.b);
        }

        public static RGBColor operator *(RGBColor c, double scallar)
        {
            return new RGBColor(c.r * scallar, c.g * scallar, c.b * scallar);
        }

        public static RGBColor operator *(RGBColor c1, RGBColor c2)
        {
            return new RGBColor(c1.r * c2.r, c1.g * c2.g, c1.b * c2.b);
        }

        public static RGBColor operator *(double scallar, RGBColor c)
        {
            return new RGBColor(c.r * scallar, c.g * scallar, c.b * scallar);
        }

        public static RGBColor operator /(RGBColor c, double scallar)
        {
            return new RGBColor(c.r / scallar, c.g / scallar, c.b / scallar);
        }

        public static RGBColor operator /(double scallar, RGBColor c)
        {
            return new RGBColor(c.r / scallar, c.g / scallar, c.b / scallar);
        }

        public static RGBColor operator +(RGBColor c, double scallar)
        {
            return new RGBColor(c.r + scallar, c.g + scallar, c.b + scallar);
        }

        public static RGBColor operator +(double scallar, RGBColor c)
        {
            return new RGBColor(c.r + scallar, c.g + scallar, c.b + scallar);
        }

        public static RGBColor operator -(RGBColor c, double scallar)
        {
            return new RGBColor(c.r - scallar, c.g - scallar, c.b - scallar);
        }

        public static RGBColor operator -(double scallar, RGBColor c)
        {
            return new RGBColor(c.r - scallar, c.g - scallar, c.b - scallar);
        }

        public static implicit operator RGBColor(Color color)
        { 
            return new RGBColor(color.R / 255.0, color.G / 255.0, color.B / 255.0); 
        }
        #endregion

        #region UTILITY
        public void Display()
        {
            Console.WriteLine("RGBColor = (" + this.r + ", " + this.g + ", " + this.b + ")");
        }

        public static Color StripColor(RGBColor colorInfo)
        {
            colorInfo.r = colorInfo.r < 0 ? 0 : colorInfo.r > 1 ? 1 : colorInfo.r;
            colorInfo.g = colorInfo.g < 0 ? 0 : colorInfo.g > 1 ? 1 : colorInfo.g;
            colorInfo.b = colorInfo.b < 0 ? 0 : colorInfo.b > 1 ? 1 : colorInfo.b;

            return Color.FromArgb((int)(colorInfo.r * 255), (int)(colorInfo.g * 255),
                                  (int)(colorInfo.b * 255));
        }
        #endregion

        public static RGBColor WHITE = Color.White;
        public static RGBColor BLACK = Color.Black;
        public static RGBColor GREEN = Color.Green;
        public static RGBColor NAVY_BLUE = Color.Navy;
        public static RGBColor SKY_BLUE = Color.SkyBlue;
        public static RGBColor AQUA = Color.Aqua;
        public static RGBColor DARK_SALMON = Color.DarkSalmon;
        public static RGBColor LIGHT_GREEN = Color.LightGreen;
        public static RGBColor RED = Color.Red;
        

    }
}
