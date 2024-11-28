using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharpCore;

namespace DaihonTypist
{
    public interface IStyle
    {
        string Name { get; }
        int Dpi {  get; }
        PageSize PageSize { get; }
    }
}
