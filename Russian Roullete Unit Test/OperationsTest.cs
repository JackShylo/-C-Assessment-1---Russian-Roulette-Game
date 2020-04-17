using System;
using RussianRoulette;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Russian_Roullete_Unit_Test
{
    [TestClass]
    public class OperationsTest
    {
        Operations myOperation = new Operations();
        [TestMethod]
        public void ShouldPopBalloon()
        {
            myOperation.BadBalloon = 1;

            bool Expected = true;
            bool Actual = myOperation.PopBalloon(1);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ShouldNotPopBalloon()
        {
            myOperation.BadBalloon = 6;

            bool Expected = false;
            bool Actual = myOperation.PopBalloon(1);

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ShouldCheckPopCount()
        {
            myOperation.PopCount = 4;

            bool Expected = true;
            bool Actual = myOperation.CheckPopCount();

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ShouldNotCheckPopCount()
        {
            myOperation.PopCount = 2;

            bool Expected = false;
            bool Actual = myOperation.CheckPopCount();

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ShouldUpdateWins()
        {
            myOperation.Wins = 2;

            int Expected = 3;
            int Actual = myOperation.UpdateWins();

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ShouldUpdateLoses()
        {
            myOperation.Loses = 8;

            int Expected = 9;
            int Actual = myOperation.UpdateLoses();

            Assert.AreEqual(Expected, Actual);
        }
    }
}
