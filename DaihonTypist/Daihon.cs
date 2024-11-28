using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Fonts;
using PdfSharpCore.Pdf;


namespace DaihonTypist
{
    public class Daihon : IDaihon
    {
        public string Title { get; } = string.Empty;
        public string Body { get; } = string.Empty;
        public string Author { get; } = string.Empty;
        public IStyle Style { get; }

        public Daihon(IStyle style, string title = "", string Body = "", string Author = "")
        {
            this.Title = title;
            this.Body = Body;
            this.Author = Author;
            this.Style = style;

        }
        public void MakeImg()
        {
            // フォントリゾルバーのグローバル登録
            PdfSharpCore.Fonts.GlobalFontSettings.FontResolver = new JapaneseFontResolver();
            var document = new PdfDocument();
            document.Info.Title = "Created with PdfSharpCore";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            var font = new XFont("ipaex mincho", 20, XFontStyle.Regular);

            // Draw the text
            string text = "あいうえおかきくけこさしすせそたちつあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとあいうえおかきくけこさしすせそたちつてとてと";
            for (int i = 0; i < text.Length; i++)
            {
                gfx.DrawString(
                    text[i].ToString(), font, XBrushes.Black,
                    new XRect(-23*Math.Floor((double)i/5), i%5*1.1*font.Size+100, page.Width, page.Height),
                    XStringFormats.TopRight);
            }

            // Save the document...
            const string filename = "HelloWorld.pdf";
            document.Save(filename);
        }
    }
}
