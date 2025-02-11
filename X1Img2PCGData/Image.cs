using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X1Img2PCGData
{
    internal class Image
    {
        static public byte get4096B(Bitmap InSourceImage, int InPlane, int InX, int InY)
        {
            int b;
            Color c0 = InSourceImage.GetPixel(InX + 0, InY);
            Color c1 = InSourceImage.GetPixel(InX + 1, InY);
            Color c2 = InSourceImage.GetPixel(InX + 2, InY);
            Color c3 = InSourceImage.GetPixel(InX + 3, InY);
            Color c4 = InSourceImage.GetPixel(InX + 4, InY);
            Color c5 = InSourceImage.GetPixel(InX + 5, InY);
            Color c6 = InSourceImage.GetPixel(InX + 6, InY);
            Color c7 = InSourceImage.GetPixel(InX + 7, InY);
            b = (((c0.B & InPlane) != 0 ? 1 : 0) << 7)
                | (((c1.B & InPlane) != 0 ? 1 : 0) << 6)
                | (((c2.B & InPlane) != 0 ? 1 : 0) << 5)
                | (((c3.B & InPlane) != 0 ? 1 : 0) << 4)
                | (((c4.B & InPlane) != 0 ? 1 : 0) << 3)
                | (((c5.B & InPlane) != 0 ? 1 : 0) << 2)
                | (((c6.B & InPlane) != 0 ? 1 : 0) << 1)
                | (((c7.B & InPlane) != 0 ? 1 : 0) << 0);
            return (byte)b;
        }
        static public byte get4096R(Bitmap InSourceImage, int InPlane, int InX, int InY)
        {
            int r;
            Color c0 = InSourceImage.GetPixel(InX + 0, InY);
            Color c1 = InSourceImage.GetPixel(InX + 1, InY);
            Color c2 = InSourceImage.GetPixel(InX + 2, InY);
            Color c3 = InSourceImage.GetPixel(InX + 3, InY);
            Color c4 = InSourceImage.GetPixel(InX + 4, InY);
            Color c5 = InSourceImage.GetPixel(InX + 5, InY);
            Color c6 = InSourceImage.GetPixel(InX + 6, InY);
            Color c7 = InSourceImage.GetPixel(InX + 7, InY);
            r =   ((((c0.R & InPlane) != 0) ? 1 : 0) << 7)
                | ((((c1.R & InPlane) != 0) ? 1 : 0) << 6)
                | ((((c2.R & InPlane) != 0) ? 1 : 0) << 5)
                | ((((c3.R & InPlane) != 0) ? 1 : 0) << 4)
                | ((((c4.R & InPlane) != 0) ? 1 : 0) << 3)
                | ((((c5.R & InPlane) != 0) ? 1 : 0) << 2)
                | ((((c6.R & InPlane) != 0) ? 1 : 0) << 1)
                | ((((c7.R & InPlane) != 0) ? 1 : 0) << 0);
            return (byte)r;
        }
        static public byte get4096G(Bitmap InSourceImage, int InPlane, int InX, int InY)
        {
            int g;
            Color c0 = InSourceImage.GetPixel(InX + 0, InY);
            Color c1 = InSourceImage.GetPixel(InX + 1, InY);
            Color c2 = InSourceImage.GetPixel(InX + 2, InY);
            Color c3 = InSourceImage.GetPixel(InX + 3, InY);
            Color c4 = InSourceImage.GetPixel(InX + 4, InY);
            Color c5 = InSourceImage.GetPixel(InX + 5, InY);
            Color c6 = InSourceImage.GetPixel(InX + 6, InY);
            Color c7 = InSourceImage.GetPixel(InX + 7, InY);
            g = (((c0.G & InPlane) != 0 ? 1 : 0) << 7)
                | (((c1.G & InPlane) != 0 ? 1 : 0) << 6)
                | (((c2.G & InPlane) != 0 ? 1 : 0) << 5)
                | (((c3.G & InPlane) != 0 ? 1 : 0) << 4)
                | (((c4.G & InPlane) != 0 ? 1 : 0) << 3)
                | (((c5.G & InPlane) != 0 ? 1 : 0) << 2)
                | (((c6.G & InPlane) != 0 ? 1 : 0) << 1)
                | (((c7.G & InPlane) != 0 ? 1 : 0) << 0);
            return (byte)g;
        }

        public static Bitmap CutImage(Bitmap InSourceImage, int InSourceX = 0, int InSourceY = 0, int InWidth = 16, int InHeight = 16)
        {
            Bitmap cutImage = new Bitmap(InWidth, InHeight);
            for(int y = 0; y < InHeight; ++y) {
                for(int x = 0; x < InWidth; ++x) {
                    cutImage.SetPixel(x, y, InSourceImage.GetPixel(x + InSourceX, y + InSourceY));
                }
            }
            return cutImage;
        }
    }
}
