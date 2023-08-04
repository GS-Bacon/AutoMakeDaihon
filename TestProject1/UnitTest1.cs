using System.Security.Cryptography.X509Certificates;
using testapp;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using AutoMakeDaihon;
using static System.Net.WebRequestMethods;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json.Linq;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void TestMethod1()
        {

            ConvertHTML convertHtml=new ConvertHTML("https://www.aozora.gr.jp/cards/000081/files/1946_11970.html");
            Console.WriteLine( convertHtml.converter());
        }

        [TestMethod]
        public void APITest()
        {
            string URL = "https://jlp.yahooapis.jp/FuriganaService/V2/furigana";
            string PostText = "äøéöÇ©Ç»åÇ∂ÇËï∂Ç…Ç”ÇËÇ™Ç»ÇêUÇÈÇ±Ç∆ÅB";
            PostRubyAPI postRubyAPI = new PostRubyAPI(URL,PostText,"123");
            var result =postRubyAPI.PostsAPI();

            Console.WriteLine(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            ConvertHTML convertHTML = new ConvertHTML("https://www.aozora.gr.jp/cards/000081/files/1946_11970.html");
            string URL = "https://jlp.yahooapis.jp/FuriganaService/V2/furigana";
            string PostText = convertHTML.ConvertMainText(convertHTML.GetMainText(convertHTML.GetHTMLforURL()));
            PostRubyAPI postRubyAPI = new PostRubyAPI(URL, PostText, "123");
            var result = postRubyAPI.PostsAPI();
            var json = new ParseJson(result);
            var JsonText = json.parse();
            Console.WriteLine(JsonText);
        }
    }
}