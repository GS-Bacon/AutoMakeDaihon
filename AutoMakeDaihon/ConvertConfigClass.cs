using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMakeDaihon
{
    public class ConvertConfig
    {
        public List<Dictionary<string, string>> config = new List<Dictionary<string, string>>();
        public ConvertConfig()
        {
            //改行
            this.config.Add(new Dictionary<string, string>() { { "before", "<br>" }, { "after", "\\\\" } });

            //ルビ
            this.config.Add(new Dictionary<string, string>() { { "before", "<ruby><rb>(.*)</rb><rp>（</rp><rt>(.*)</rt><rp>）</rp></ruby>" }, { "after", "$1" } });

            //太字前半
            this.config.Add(new Dictionary<string, string>() { { "before", "<strong class=\"SESAME_DOT\">" }, { "after", "\\textbf{" } });

            //太字後半
            this.config.Add(new Dictionary<string, string>() { { "before", "</strong>" }, { "after", "}" } });

            //全角スペースをインデント
            this.config.Add(new Dictionary<string, string>() { { "before", "　" }, { "after", "\\indent " } });

        }
    }
}
