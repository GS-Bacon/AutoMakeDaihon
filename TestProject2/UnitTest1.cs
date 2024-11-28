using DaihonTypist;
namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Daihon daihon = new(new DefaultStyle());
            daihon.MakeImg();
            
        }
    }
}