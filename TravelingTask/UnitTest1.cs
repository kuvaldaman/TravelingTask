using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelingTask.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            string readPath =
                @"C:\Users\Тернт\Documents\Visual Studio 2015\Projects\TravelingTask\NotOrderedCardsTxt\1.txt";

            string fileTxt =
                File.ReadAllText(
                    @"C:\Users\Тернт\Documents\Visual Studio 2015\Projects\TravelingTask\OrderedCardsTxt\1.txt",
                    Encoding.Default);
            //act
            Program.Travel travel = new Program.Travel(readPath);

            string outputTxt = travel.text;
            double time = travel.time;
            bool leadTime = time < 2;

            //assert
            Assert.AreEqual(outputTxt, fileTxt);
            Assert.IsTrue(leadTime);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            string readPath =
                @"C:\Users\Тернт\Documents\Visual Studio 2015\Projects\TravelingTask\NotOrderedCardsTxt\2.txt";

            string fileTxt =
                File.ReadAllText(
                    @"C:\Users\Тернт\Documents\Visual Studio 2015\Projects\TravelingTask\OrderedCardsTxt\2.txt",
                    Encoding.Default);

            //act
            Program.Travel travel = new Program.Travel(readPath);

            string outputTxt = travel.text;
            double time = travel.time;
            bool leadTime = time < 2;

            //assert
            Assert.AreEqual(outputTxt, fileTxt);
            Assert.IsTrue(leadTime);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //arrange
            string readPath =
                @"C:\Users\Тернт\Documents\Visual Studio 2015\Projects\TravelingTask\NotOrderedCardsTxt\3.txt";

            string fileTxt =
                File.ReadAllText(
                    @"C:\Users\Тернт\Documents\Visual Studio 2015\Projects\TravelingTask\OrderedCardsTxt\3.txt",
                    Encoding.Default);
            //act
            Program.Travel travel = new Program.Travel(readPath);

            string outputTxt = travel.text;
            double time = travel.time;
            bool leadTime = time < 2;

            //assert
            Assert.AreEqual(outputTxt, fileTxt);
            Assert.IsTrue(leadTime);
        }
    }
}
