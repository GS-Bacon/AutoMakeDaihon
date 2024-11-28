using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaihonTypist
{
    public class A4w : IPaperSize
    {
        public int Width { get; } = 297;
        public int Height { get; } = 210;
    }
    public class A4h : IPaperSize
    {
        public int Width { get; } = 210;
        public int Height { get; } = 297;
    }
}
