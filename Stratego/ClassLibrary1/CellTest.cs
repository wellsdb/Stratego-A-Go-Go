using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Stratego;
using NUnit.Framework;

namespace StrategoTesting
{
    [TestFixture()]
    public class CellTest
    {

        [SetUp()]
        public void Setup()
        {
            //nothing yet
        }

        [Test()]
        public void TestThatCellTerrainGetsSetsAndInitializesCorrectly()
        {
            Object target1 = new Cell(0);
            Object target2 = new Cell(1);
            Object target3 = new Cell(0);
            Object target4 = new Cell(1);

            target3.setTerrain(1);
            target4.setTerrain(0);

            Assert.AreEqual(0, target1.getTerrain());
            Assert.AreEqual(1, target2.getTerrain());
            Assert.AreEqual(1, target3.getTerrain());
            Assert.AreEqual(0, target4.getTerrain());
        }

        [Test()]
        public void TestThatCellPieceSetsAndInitializesCorrectly()
        {
            //Piece testPiece1 = new Piece(4);
            //Piece testPiece2 = new Piece(5);

            Piece dummyPiece1 = mocks.Stub<Piece>();
            Piece dummyPiece2 = mocks.Stub<Piece>();

            Object target1 = new Cell(dummyPiece1);
            Object target2 = new Cell(dummyPiece2);
            Object target3 = new Cell();
            Object target4 = new Cell();

            target3.setPiece(dummyPiece1);
            target4.setPiece(dummyPiece2);

            Assert.AreSame(dummyPiece1, target1.getPiece());
            Assert.AreSame(dummyPiece2, target2.getPiece());
            Assert.AreSame(dummyPiece1, target3.getPiece());
            Assert.AreSame(dummyPiece2, target4.getPiece());
        }
    }
}