using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stratego;
using NUnit.Framework;
using Rhino.Mocks;

namespace StrategoTesting
{
    [TestFixture()]
    public class CellTest
    {
        private MockRepository mocks;

        [SetUp()]
        public void Setup()
        {
            mocks = new MockRepository();
        }

        [Test()]
        public void TestThatCellTerrainGetsSetsAndInitializesCorrectly()
        {
            Cell target1 = new Cell(Cell.Terrain.Land);
            Cell target2 = new Cell(Cell.Terrain.Lake);
            Cell target3 = new Cell(Cell.Terrain.Land);
            Cell target4 = new Cell(Cell.Terrain.Lake);

            target3.setTerrain(Cell.Terrain.Lake);
            target4.setTerrain(Cell.Terrain.Land);
            
            Piece piece1 = new Piece(Piece.Team.red, Piece.Rank.lieutenant);
            Piece piece2 = new Piece(Piece.Team.blue, Piece.Rank.marshal);

            Cell target5 = new Cell (Cell.Terrain.Lake, piece1);
            Cell target6 = new Cell (Cell.Terrain.Land, piece2);

            Assert.AreEqual(Cell.Terrain.Land, target1.getTerrain());
            Assert.AreEqual(Cell.Terrain.Lake, target2.getTerrain());
            Assert.AreEqual(Cell.Terrain.Lake, target3.getTerrain());
            Assert.AreEqual(Cell.Terrain.Land, target4.getTerrain());
            Assert.AreEqual(Cell.Terrain.Lake, target5.getTerrain());
            Assert.AreEqual(Cell.Terrain.Land, target6.getTerrain());
            
        }

        [Test()]
        public void TestThatCellPieceSetsAndInitializesCorrectly()
        {
            Piece dummyPiece1 = mocks.Stub<Piece>();
            Piece dummyPiece2 = mocks.Stub<Piece>();

            Cell target1 = new Cell(dummyPiece1);
            Cell target2 = new Cell(dummyPiece2);
            Cell target3 = new Cell();
            Cell target4 = new Cell();

            target3.setPiece(dummyPiece1);
            target4.setPiece(dummyPiece2);

            Assert.AreSame(dummyPiece1, target1.getPiece());
            Assert.AreSame(dummyPiece2, target2.getPiece());
            Assert.AreSame(dummyPiece1, target3.getPiece());
            Assert.AreSame(dummyPiece2, target4.getPiece());

            Piece piece1 = new Piece(Piece.Team.red, Piece.Rank.lieutenant);
            Piece piece2 = new Piece(Piece.Team.blue, Piece.Rank.marshal);

            Cell target5 = new Cell(Cell.Terrain.Lake, piece1);
            Cell target6 = new Cell(Cell.Terrain.Land, piece2);

            Assert.AreSame(piece1, target5.getPiece());
            Assert.AreSame(piece2, target6.getPiece());
        }
    }
}