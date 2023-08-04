using System;
using System.IO;
using System.Net;
using System.Text;
using Aspose.Html;
using System.Text.RegularExpressions;
using AngleSharp.Browser;
using AutoMakeDaihon;
using Newtonsoft.Json.Linq;
using Scriban.Runtime.Accessors;

namespace testapp
{
    public class ConvertHTML
    {
        public string url;
        public ConvertHTML(string URL)
        {
            this.url=URL;
        }

        public string converter()
        {
            return AddRuby(ConvertMainText(GetMainText(GetHTMLforURL())));
        }
        public AngleSharp.Html.Dom.IHtmlDocument GetHTMLforURL()//URLからHTMLファイルを取得
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; //よくわからん
            var parser = new AngleSharp.Html.Parser.HtmlParser(); //HTMLパーサー
            var document = new HTMLDocument(@url);
            string result = document.DocumentElement.OuterHTML;
            var parsedDoc = parser.ParseDocument(result);
            return parsedDoc;
        }
        public string GetMainText(AngleSharp.Html.Dom.IHtmlDocument parsedDoc)//HTMLファイルからmain_textクラスの文章を取得
        {
            var mainclass = parsedDoc.GetElementsByClassName("main_text");
            return mainclass[0].InnerHtml;
        }
        public string ConvertMainText(string maintext)//HTMLタグをLatexコマンドに変換
        {
            ConvertConfig config = new ConvertConfig();
            for (var i = 0; i < config.config.Count; i++)
            {
                Regex regex = new Regex(config.config[i]["before"]);
                maintext = regex.Replace(maintext, config.config[i]["after"], maintext.Length);

            }
            return maintext;
        }
        public string AddRuby(string text) //YahooルビAPIから返ってきたJsonをLatexの\rubyに変換
        {
            string maintext = null;
            PostRubyAPI postRubyAPI = new PostRubyAPI(text);
            string FuriganaText = postRubyAPI.PostsAPI();
            ParseJson parseJson = new ParseJson(FuriganaText);
            var result = parseJson.parse().SelectToken("result.word");
            foreach (JToken word in (JArray)result)
            {

                object _vsurface = ((JValue)word.SelectToken("surface")).Value;
                string _vsurfaces = Convert.ToString(_vsurface);

                if (word.SelectToken("furigana") != null)　//フリガナが設定されている
                {
                object _vfurigana = ((JValue)word.SelectToken("furigana")).Value;
                string _vfuriganas = Convert.ToString(_vfurigana);

                    if (word.SelectToken("subword") != null)//カナ交じりで変換されるとsubwordが設定される
                    {

                        foreach (JToken subword in (JArray)word.SelectToken("subword"))
                        {
                            object _vb = ((JValue)subword.SelectToken("surface")).Value;
                            string _va = Convert.ToString(_vb);
                            object _vc = ((JValue)subword.SelectToken("furigana")).Value;
                            string _vd = Convert.ToString(_vc);

                            if (System.Text.RegularExpressions.Regex.IsMatch(_va,
                                @"[\p{IsCJKUnifiedIdeographs}" +
                                @"\p{IsCJKCompatibilityIdeographs}" +
                                @"\p{IsCJKUnifiedIdeographsExtensionA}]|" +
                                @"[\uD840-\uD869][\uDC00-\uDFFF]|\uD869[\uDC00-\uDEDF]"))//漢字が含まれていたらtureを返す正規表現らしい
                            {
                                maintext += "\\ruby{" + _va + "}" + "{" + _vd + "}";
                            }
                            else
                            {
                                maintext += _va;//漢字が含まれていなければルビを振らない
                            }
                        }

                    }
                    else
                    {
                        maintext += "\\ruby{" + _vsurfaces + "}" + "{" + _vfuriganas + "}";//カナ混じりでないならば漢字にルビを振る
                    }
                }
                else
                {
                    maintext += _vsurfaces;
                }
            }
            return maintext;

        }
    }
}