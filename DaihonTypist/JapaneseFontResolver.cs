using PdfSharpCore.Fonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DaihonTypist
{
    internal class JapaneseFontResolver : IFontResolver
    {
        private static readonly string IPAex_MINCHO = "DaihonTypist.fonts.ipaexm.ttf";

        string IFontResolver.DefaultFontName => "Arial";

        public byte[] GetFont(string faceName)
        {
            switch (faceName)
            {
                case "IPAex明朝#Regular":
                    return LoadFontData(IPAex_MINCHO);
            }
            return null;
        }

        public FontResolverInfo ResolveTypeface(
                    string familyName, bool isBold, bool isItalic)
        {
            var fontName = familyName.ToLower();

            switch (fontName)
            {
                case "ipaex mincho":
                    return new FontResolverInfo("IPAex明朝#Regular");
            }

            // デフォルトのフォント
            return PlatformFontResolver.ResolveTypeface("Arial", isBold, isItalic);
        }

        // 埋め込みリソースからフォントファイルを読み込む
        private byte[] LoadFontData(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new ArgumentException("No resource with name " + resourceName);
                int count = (int)stream.Length;
                byte[] data = new byte[count];
                stream.Read(data, 0, count);
                return data;
            }
        }
    }
}
