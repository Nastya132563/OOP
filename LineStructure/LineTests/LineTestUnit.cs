using Microsoft.VisualStudio.TestTools.UnitTesting;
using LineStructure;
using System.IO;
using System;

namespace LineTests

{
    [TestClass]
    public class LineTestUnit
    {
        [TestMethod]
        public void ConstructorTestMethod()
        {
            var myLine = CreateTestLine();

            double myAngle = 60.0;

            Assert.AreEqual(1.73205, myLine.VarA);
            Assert.AreEqual(1.2, myLine.VarB);
            Assert.AreEqual(myAngle, myLine.Angle);
        }

        [TestMethod]
        public void ToStringTestMethod()
        {
            Assert.AreEqual("y=1,73205x+1,2", CreateTestLine().ToString());
        }

        [TestMethod]
        public void DisplayTestMethod()
        {
            var l1 = CreateTestLine();
            var l2 = new Line(-3, -5);

            var consoleOut = new[]
            {
                "Структура Line, var A = 1,73205, var B = 1,2",
                "Структура Line, var A = -3, var B = -5",
            };

            TextWriter oldOut = Console.Out;

            StringWriter output = new StringWriter();
            Console.SetOut(output);

            l1.Display();
            l2.Display();

            Console.SetOut(oldOut);

            var outputArray = output.ToString().Split(new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(2, outputArray.Length);
            for (var i = 0; i < consoleOut.Length; i++)
                Assert.AreEqual(consoleOut[i], outputArray[i]);
        }

        [TestMethod]
        public void EqualsTestMethod()
        {
            Line l1 = new Line(-2, 4);
            Line l2 = new Line(-2, 4);

            Line l3 = new Line(-2, 5);

            Assert.AreEqual(true, l1.Equals(l2));
            Assert.AreEqual(false, l1.Equals(l3));
        }

        

        [TestMethod]
        public void PerpendicularMethod()
        {
            Line l1 = CreateTestLine();
            Line l2 = ~l1;
            Assert.AreEqual(-0.5774, l2.VarA);
            Assert.AreEqual(0, l2.VarB);
            Assert.AreEqual(-30, l2.Angle);

        }
        private Line CreateTestLine()
        {
            return new Line(1.73205, 1.2);
        }
    }
}
