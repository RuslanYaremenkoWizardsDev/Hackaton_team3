using NUnit.Framework;
using System;

namespace Hackaton_team3.Tests
{
    public class LayersTests
    {
        [TestCase(21, 78, "21,78") ]
        [TestCase(1, 999, "1,999")]
        [TestCase(-10,-10,"1,1")]
        [TestCase(0,0,"1,1")]
        public void ToString_WhenTestPassed_ReturnString(int actualHorisontal, int actualVertical,string expected)
        {
            Layers actualLayers = new Layers(actualHorisontal,actualVertical);
            string actual = actualLayers.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
