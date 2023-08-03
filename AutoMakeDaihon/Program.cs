using System;
using System.IO;
using System.Net;
using System.Text;
using Aspose.Html;
using System.Text.RegularExpressions;
using AngleSharp.Browser;
using AutoMakeDaihon;

namespace testapp
{
    public class ConvertHTML
    {
        public string ConvetText;
        public ConvertHTML(string URL)
        {
            this.ConvetText=ConvertMainText( GetMainText(GetHTMLforURL(URL)));
        }
        private AngleSharp.Html.Dom.IHtmlDocument GetHTMLforURL(string url)//URLからHTMLファイルを取得
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var parser = new AngleSharp.Html.Parser.HtmlParser();
            var document = new HTMLDocument(@url);
            string result = document.DocumentElement.OuterHTML;
            var parsedDoc = parser.ParseDocument(result);
            return parsedDoc;
        }
        private string GetMainText(AngleSharp.Html.Dom.IHtmlDocument parsedDoc)//HTMLファイルからmain_textクラスの文章を取得
        {
            var mainclass = parsedDoc.GetElementsByClassName("main_text");
            return mainclass[0].InnerHtml;
        }

        private string ConvertMainText (string maintext)
        {
            ConvertConfig config = new ConvertConfig();
            for(var i=0;i<config.config.Count;i++)
            {
                Regex regex = new Regex(config.config[i]["before"]);
                maintext = regex.Replace(maintext, config.config[i]["after"], maintext.Length);

            }
            return maintext;
        }
    }

}