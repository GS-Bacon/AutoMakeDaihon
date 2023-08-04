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
            string URL = "https://jlp.yahooapis.jp/FuriganaService/V2/furigana";
            string PostText = "漢字かな交じり文にふりがなを振ること。";
            PostRubyAPI postRubyAPI = new PostRubyAPI(URL, PostText, "123");
            var result = postRubyAPI.PostsAPI();
            Console.WriteLine(result);
        }
    }
}