using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceGameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGameLibrary.Tests
{
    [TestClass()]
    public class PlanetTests
    {
        [TestMethod()]
        public void DisplayHeaderTest()
        {
            Utility test = new Utility();
            test.DisplayHeader();
        }

        [TestMethod()]
        public void QuadrantTest()
        {
            Planet test = new Planet();
            test.Quadrant();
        }
    }
}