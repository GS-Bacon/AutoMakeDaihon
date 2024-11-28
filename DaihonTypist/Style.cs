using PdfSharpCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaihonTypist
{
    public class DefaultStyle:IStyle
    {
        public string Name { get; } = "";
        public int Dpi { get; set; } = 200;
        public PageSize PageSize { get; set; } = PageSize.A4;
    }
}
