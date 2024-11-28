using System.Drawing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
namespace DaihonTypist
{
    public interface IDaihon
    {
        string Title { get; }
        string Body { get; }
        string Author { get; }
        IStyle Style { get; }
    }
}
