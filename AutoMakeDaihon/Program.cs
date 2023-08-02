using System;
using System.IO;
using System.Net;
using System.Text;

namespace testapp
{
    public class GetHTML
    {
        static  async Task<string> GetHTMLFile(Uri url)
        {
            HttpClient client = new HttpClient();
            var ResultHTML = await client.GetStringAsync(url);
            return ResultHTML;
        }
    }
}