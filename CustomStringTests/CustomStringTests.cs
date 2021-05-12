
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TestProject;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace CustomStringTests
{
    [TestClass()]
    public class CustomStringTests
    {

        [TestMethod()]
        public void getStringTest()
        {
            var customString = new CustomString();
            customString.setString("test");
            Assert.AreEqual(customString.getString(), "test");
        }

        [TestMethod()]
        public void setStringTest()
        {
            var customString = new CustomString();
            customString.setString("test");
            string test = customString.getString();
            Assert.AreEqual(test, "test");
         
        }

        [TestMethod()]
        public void countNumbersTest()
        {
            var customString = new CustomString();
            customString.setString("te5s3t");
            Assert.AreEqual(customString.countNumbers(), 2);
        }

        [TestMethod()]
        public void removeEveryNthCharacterTestWithSpacing()
        {
            var customString = new CustomString();
            customString.setString("this is a test");
            Assert.AreEqual(customString.removeEveryNthCharacter(2, true), "t i   s a t s ");
        }

        [TestMethod()]
        public void removeEveryNthCharacterTestWithoutSpacing()
        {
            var customString = new CustomString();
            customString.setString("this is a test");
            Assert.AreEqual(customString.removeEveryNthCharacter(2, false), "ti sats");
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void removeEveryNthCharacterTestOutOfBounds()
        {
            var customString = new CustomString();
            customString.setString("this is a test");
            customString.removeEveryNthCharacter(100, true);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void removeEveryNthCharacterTestArgumentException()
        {
            var customString = new CustomString();
            customString.setString("this is a test");
            customString.removeEveryNthCharacter(-5, true);
        }


        //Itegration Test
        [TestMethod()]
        public void googlePingTest()
        {

            var customString = new CustomString();
            customString.setString("hatbtapb:a/b/awbwawb.agboaobgalbea.bcaobma");
            //HttpClient client = new HttpClient(); //Opens client
            Console.WriteLine(customString.getString()); 
            HttpWebRequest client = (HttpWebRequest)WebRequest.Create(customString.removeEveryNthCharacter(2, false));
          

            //var result = client.GetAsync(customString.getString());
            HttpWebResponse result = (HttpWebResponse)client.GetResponse();
         
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        } 
    }
}