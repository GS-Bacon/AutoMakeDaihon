using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using static System.Net.WebRequestMethods;

namespace AutoMakeDaihon
{
    public class PostRubyAPI
    {
        string url;
        string requestText;
        string APPID;

        public PostRubyAPI(string URL, string RequestText, string AppID)
        {
            this.url = URL;
            this.requestText = RequestText;
            this.APPID = AppID;
        }

        public PostRubyAPI(string RequestText)
        {
            this.url= "https://jlp.yahooapis.jp/FuriganaService/V2/furigana";
            this.requestText = RequestText;
            this.APPID = "123";

        }

        public string PostsAPI()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", $"Yahoo AppID: {APPID}");
            var pram_dic = new Dictionary<string, object>
            {
                {"id","1234-1" },
                {"jsonrpc","2.0" },
                { "method","jlp.furiganaservice.furigana"},
                {"params",new Dictionary<string,object>{{ "q",requestText},{ "grade",1}} },
            };

            var response = client.PostAsJsonAsync(url, pram_dic).Result;
            var json =  response.Content.ReadAsStringAsync().Result;
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };

            return JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(json), options);
        }
    }

}
