using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardHook01
{
    class ColorUtil
    {
        /// <summary>
        /// Convert a value into 0 ~ 255 for the color
        /// </summary>
        /// <param name="lower">lower bound</param>
        /// <param name="higher">higher bound</param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static int ScaleTo255(ulong lower, ulong higher, ulong value) {
            if (higher <= lower || value == 0)
                return 255;
            ulong range = higher - lower;
            int t = Convert.ToInt32(((double)(value - lower) / range) * 255);
            return 255 - t;
        }

        private static Color HalfRainBow(ulong lower, ulong higher, ulong value)
        {
            int r = 255, g = 255, b = 255;
            if (!(higher <= lower || value == 0 || higher < 0 || lower < 0))
            {
                ulong segment = (higher - lower + 1) / 4;
                ulong s1Start = lower;
                ulong s2Start = s1Start + segment;
                ulong s3Start = s2Start + segment;
                ulong s4Start = s3Start + segment;
                if (value >= s1Start && value < s2Start)
                {
                    double ratio = (double)(value - s1Start) / segment;
                    //int redSub = Convert.ToInt32(ratio * 128);
                    int redSub = Convert.ToInt32(ratio * 255);
                    int blueSub = Convert.ToInt32(ratio * 255);
                    r -= redSub;
                    b -= blueSub;
                    g = 255;
                } 
                else if (value < s3Start)
                {
                    double ratio = (double)(value - s2Start) / segment;
                    r = Convert.ToInt32(ratio * 255);
                    g = 255;
                    b = 0;
                }
                else if (value < s4Start)
                {
                    double ratio = (double)(value - s3Start) / segment;
                    int greenSub = Convert.ToInt32(128 * ratio);
                    int blueAdd = Convert.ToInt32(greenSub * 1.5);
                    r = 255;
                    g = 255 - greenSub;
                    b = blueAdd;
                }
                else
                {
                    double ratio = (double)(value - s4Start) / segment;
                    r = 255;
                    g = 127;
                    b = 192;
                    int greenSub = Convert.ToInt32(ratio * 125);
                    int blueSub = Convert.ToInt32(greenSub * 1.51);
                    g -= greenSub;
                    b -= blueSub;
                }
            }
            if (r < 0)
                r = 0;
            if (g < 0)
                g = 0;
            if (b < 0)
                b = 0;
            if (r > 255)
                r = 255;
            if (g > 255)
                g = 255;
            if (b > 255)
                b = 255;
            return Color.FromArgb(r, g, b);
        }

        private static Color FullRainbow(ulong lower, ulong higher, ulong value)
        {
            int r = 255, g = 255, b = 255;
            if (!(higher <= lower || value == 0 || higher < 0 || lower < 0))
            {
                ulong segment = (higher - lower + 1) / 6;
                ulong s1Start = lower;
                ulong s2Start = s1Start + segment;
                ulong s3Start = s2Start + segment;
                ulong s4Start = s3Start + segment;
                ulong s5Start = s4Start + segment;
                ulong s6Start = s5Start + segment;
                if (value >= s1Start && value < s2Start)
                {
                    // blue
                    double ratio = (double)(value - s1Start) / segment;
                    int redSub = Convert.ToInt32(ratio * 255);
                    int greenSub = Convert.ToInt32(ratio * 255);
                    r -= redSub;
                    g -= greenSub;
                    b = 255;
                }
                else if (value < s3Start)
                {
                    // cyan
                    double ratio = (double)(value - s2Start) / segment;
                    int greenAdd = Convert.ToInt32(ratio * 255);
                    r = 0;
                    g = greenAdd;
                    b = 255;
                }
                else if (value < s4Start)
                {
                    // green
                    double ratio = (double)(value - s3Start) / segment;
                    int blueSub = Convert.ToInt32(ratio * 255);
                    r = 0;
                    g = 255;
                    b -= blueSub;
                }
                else if (value < s5Start)
                {
                    // yellow
                    double ratio = (double)(value - s4Start) / segment;
                    int redAdd = Convert.ToInt32(ratio * 255);
                    r = redAdd;
                    g = 255;
                    b = 0;
                }
                else if (value < s6Start)
                {
                    // red
                    double ratio = (double)(value - s5Start) / segment;
                    int greenSub = Convert.ToInt32(ratio * 255);
                    r = 255;
                    g -= greenSub;
                    b = 0;
                }
                else
                {
                    // magenta
                    double ratio = (double)(value - s6Start) / segment;
                    int blueAdd = Convert.ToInt32(ratio * 255);
                    r = 255;
                    g = 0;
                    b = blueAdd;
                }
            }
            if (r < 0)
                r = 0;
            if (g < 0)
                g = 0;
            if (b < 0)
                b = 0;
            if (r > 255)
                r = 255;
            if (g > 255)
                g = 255;
            if (b > 255)
                b = 255;
            return Color.FromArgb(r, g, b);
        }

        public static Color RedTone(ulong lower, ulong higher, ulong value)
        {
            int otherValue = ScaleTo255(lower, higher, value);
            return Color.FromArgb(255, otherValue, otherValue);
        }

        public static Color GreenTone(ulong lower, ulong higher, ulong value)
        {
            int otherValue = ScaleTo255(lower, higher, value);
            return Color.FromArgb(otherValue, 255, otherValue);
        }

        public static Color BlueTone(ulong lower, ulong higher, ulong value)
        {
            int otherValue = ScaleTo255(lower, higher, value);
            return Color.FromArgb(otherValue, otherValue, 255);
        }

        public static Color YellowTone(ulong lower, ulong higher, ulong value)
        {
            int otherValue = ScaleTo255(lower, higher, value);
            return Color.FromArgb(255, 255, otherValue);
        }

        public static Color CyanTone(ulong lower, ulong higher, ulong value)
        {
            int otherValue = ScaleTo255(lower, higher, value);
            return Color.FromArgb(otherValue, 255, 255);
        }

        public static Color MagentaTone(ulong lower, ulong higher, ulong value)
        {
            int otherValue = ScaleTo255(lower, higher, value);
            return Color.FromArgb(255, otherValue, 255);
        }

        public static Color HalfRainbowTone(ulong lower, ulong higher, ulong value)
        {
            return HalfRainBow(lower, higher, value);
        }

        public static Color FullRainbowTone(ulong lower, ulong higher, ulong value)
        {
            return FullRainbow(lower, higher, value);
        }

        public static Color BlackAndWhiteTone(ulong lower, ulong higher, ulong value)
        {
            int otherValue = ScaleTo255(lower, higher, value);
            return Color.FromArgb(otherValue, otherValue, otherValue);
        }

        public delegate Color ColorTone(ulong lower, ulong higher, ulong value);

        public static Color DisplayColor(int choice, ulong lower, ulong higher, ulong value)
        {
            ColorTone ColorToneFunction;
            switch (choice)
            {
                case 0:
                    ColorToneFunction = new ColorTone(RedTone);
                    break;
                case 1:
                    ColorToneFunction = new ColorTone(GreenTone);
                    break;
                case 2:
                    ColorToneFunction = new ColorTone(BlueTone);
                    break;
                case 3:
                    ColorToneFunction = new ColorTone(YellowTone);
                    break;
                case 4:
                    ColorToneFunction = new ColorTone(CyanTone);
                    break;
                case 5:
                    ColorToneFunction = new ColorTone(MagentaTone);
                    break;
                case 6:
                    ColorToneFunction = new ColorTone(HalfRainbowTone);
                    break;
                case 7:
                    ColorToneFunction = new ColorTone(FullRainbowTone);
                    break;
                case 8:
                    ColorToneFunction = new ColorTone(BlackAndWhiteTone);
                    break;
                default:
                    ColorToneFunction = new ColorTone(HalfRainbowTone);
                    break;
            }
            return ColorToneFunction(lower, higher, value);
        }

        public static Color GetTextColorBasedOnBackground(Color background)
        {
            double r, g, b;
            double sr = (double)background.R / 255;
            double sg = (double)background.G / 255;
            double sb = (double)background.B / 255;
            if (sr <= 0.03928)
                r = sr / 12.92;
            else
                r = Math.Pow(((sr + 0.055) / 1.055), 2.4);
            if (sg <= 0.03928)
                g = sg / 12.92;
            else
                g = Math.Pow(((sg + 0.055) / 1.055), 2.4);
            if (sb <= 0.03928)
                b = sb / 12.92;
            else
                b = Math.Pow(((sb + 0.055) / 1.055), 2.4);
            double l = 0.2126 * r + 0.7152 * g + 0.0722 * b;
            if (((l + 0.05) / (0.0 + 0.05)) > ((1.0 + 0.05) / (l + 0.05)))
                return Color.Black;
            return Color.White;
        }
    }
}
