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
            ConvertConfig config = new ConvertConfig();
            Console.WriteLine(config.config[0]["after"]);
        }
    }
}