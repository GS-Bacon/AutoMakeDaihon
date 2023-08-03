using System.Security.Cryptography.X509Certificates;
using testapp;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using AutoMakeDaihon;

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
            Console.WriteLine( convertHtml.ConvetText);
        }
    }
}