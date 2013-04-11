using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Stratego;

namespace StrategoTesting
{
    [TestFixture()]
    class M2Test
    {
        [Test()]
        public void forwardOpenSpace()
        {
            Board b = new Board();
            b.placePiece(new Piece(0, 10), 0, 5);
            Assert.True(b.isMoveValid(0, 5, 0, 6));
        }
        [Test]
        public void scoutOpenSpaceForward()
        {
            Board b = new Board();
            b.placePiece(new Piece(0, 2), 0, 5);
            Assert.True(b.isMoveValid(0, 5, 0, 8));
        }
        [Test]
        public void scoutOpenSpaceSideways()
        {
            Board b = new Board();
            b.placePiece(new Piece(0, 2), 0, 5);
            Assert.True(b.isMoveValid(0, 5, 5, 5));
        }
        [Test]
        public void scoutOpenSpaceDiagonal()
        {
            Board b = new Board();
            b.placePiece(new Piece(0, 2), 0, 5);
            Assert.False(b.isMoveValid(0, 5, 5, 8));
        }
        [Test]
        public void forwardLake()
        {
            Board b = new Board();
            b.placePiece(new Piece(2, 10), 0, 5);
            b.placePiece(new Piece(0, 10), 0, 4);
            Assert.False(b.isMoveValid(0, 4, 0, 5));
        }
        [Test]
        public void movefromEmptySpace()
        {
            Board b = new Board();
            Assert.False(b.isMoveValid(0, 4, 0, 5));
        }
        [Test]
        public void testgetSpace()
        {
            Board b = new Board();
            b.placePiece(new Piece(2, 10), 0, 5);
            Assert.True(b.getSpace(0, 5).Equals(new Piece(2, 10)));
        }
        [Test]
        public void testNonScoutMovementLimit()
        {
            Board b = new Board();
            b.placePiece(new Piece(0, 10), 0, 5);
            Assert.False(b.isMoveValid(0, 5, 0, 8));
        }
        [Test]
        public void testPieceEqualsFalse()
        {
            Piece p = new Piece(0, 10);
            Piece q = new Piece(1, 10);
            Assert.False(p.Equals(q));
        }
    }
}
