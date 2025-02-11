using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X1Img2PCGData
{
    internal class PCG
    {
        public static byte[] ToByte(Bitmap InSourceImage, string InLetter)
        {
            List<byte> data = new List<byte>();
            StringBuilder sb = new StringBuilder();

            InLetter = InLetter.Replace("\r\n", "\n");
            InLetter = InLetter.Replace("\r", "\n");
            var letterSet = InLetter.ToArray().Distinct().ToHashSet();
            sb.AppendLine($"    {letterSet.Count}, // char data size");
            data.Add((byte)letterSet.Count);

            HashSet<char> dupCheck = new HashSet<char>();
            int charWidth = 8;
            int charHeight = 8;
            int x = 0;
            int y = 0;
            foreach(char ch in InLetter) {
                if(ch == '\n') {
                    x = 0;
                    ++y;
                } else {
                    if(!dupCheck.Contains(ch)) {
                        dupCheck.Add(ch);
                        using(Bitmap src = Image.CutImage(InSourceImage, x * charWidth, y * charHeight, charWidth, charHeight)) {
                            sb.AppendLine($"    {(int)ch}, // {ch}");
                            data.Add((byte)ch);
                            sb.Append("    ");
                            for(int srcY = 0;  srcY < charHeight; ++srcY) {
                                byte b0 = Image.get4096B(src, 0x80, 0, srcY);
                                sb.Append($"0x{b0.ToString("X2")}, ");
                                data.Add(b0);
                            }
                            sb.AppendLine();
                            sb.Append("    ");
                            for(int srcY = 0;  srcY < charHeight; ++srcY) {
                                byte b0 = Image.get4096R(src, 0x80, 0, srcY);
                                sb.Append($"0x{b0.ToString("X2")}, ");
                                data.Add(b0);
                            }
                            sb.AppendLine();
                            sb.Append("    ");
                            for(int srcY = 0;  srcY < charHeight; ++srcY) {
                                byte b0 = Image.get4096G(src, 0x80, 0, srcY);
                                sb.Append($"0x{b0.ToString("X2")}, ");
                                data.Add(b0);
                            }
                            sb.AppendLine();
                        }
                    }
                    ++x;
                }
            }
            return data.ToArray();
        }
    }
}
