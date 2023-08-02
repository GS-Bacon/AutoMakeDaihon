using System.Net;
using testapp;
using Aspose.Html;
using AngleSharp;
using System.Text.RegularExpressions;

namespace AutoMakeDaihon
{
    class AutoMakeDaihon
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var parser = new AngleSharp.Html.Parser.HtmlParser();
            string path = @"https://www.aozora.gr.jp/cards/000081/files/1946_11970.html";
            var document = new HTMLDocument(path);
            string result = document.DocumentElement.OuterHTML;
            var parsedDoc = parser.ParseDocument(result);

            var mainclass = parsedDoc.GetElementsByClassName("main_text");
            var maintext = mainclass[0].InnerHtml;
            maintext = maintext.Replace("<br>", "\\\\");
            maintext = maintext.Replace("　", "\\indent ");
            Regex reg1 = new Regex("<ruby><rb>(.*)</rb><rp>（</rp><rt>(.*)</rt><rp>）</rp></ruby>");
            Regex reg2 = new Regex("</strong>");
            Regex reg3 = new Regex("<strong class=\"SESAME_DOT\">");
            maintext = reg1.Replace(maintext, "$1", maintext.Length);
            maintext = reg2.Replace(maintext, "}", maintext.Length);
            maintext = reg3.Replace(maintext, "\\textbf{",maintext.Length);
            Console.WriteLine(maintext);
        }
    }
}