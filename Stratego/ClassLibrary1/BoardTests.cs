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
    class BoardTests
    {
        [Test()]
        public void northRedOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 0, 5);
            Assert.True(b.isMoveValid(0, 5, (int)Board.dir.N, 1));
        }
        [Test()]
        public void northRedOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 8, 5);
            Assert.True(b.isMoveValid(8, 5, (int)Board.dir.N, 1));
        }
        [Test()]
        public void northRedOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 7, 5);
            Assert.True(b.isMoveValid(7, 5, (int)Board.dir.N, 1));
        }
        [Test()]
        public void northRedOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 9, 5);
            Assert.False(b.isMoveValid(9, 5, (int)Board.dir.N, 1));
        }

        [Test()]
        public void southRedOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 5, 5);
            Assert.True(b.isMoveValid(5, 5, (int)Board.dir.S, 1));
        }
        [Test()]
        public void southRedOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 1, 5);
            Assert.True(b.isMoveValid(1, 5, (int)Board.dir.S, 1));
        }
        [Test()]
        public void southRedOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 2, 5);
            Assert.True(b.isMoveValid(2, 5, (int)Board.dir.S, 1));
        }
        [Test()]
        public void southRedOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 0, 5);
            Assert.False(b.isMoveValid(0, 5, (int)Board.dir.S, 1));
        }

        [Test()]
        public void eastRedOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 0, 5);
            Assert.True(b.isMoveValid(0, 5, (int)Board.dir.E, 1));
        }
        [Test()]
        public void eastRedOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 8, 5);
            Assert.True(b.isMoveValid(8, 5, (int)Board.dir.E, 1));
        }
        [Test()]
        public void eastRedOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 7, 5);
            Assert.True(b.isMoveValid(7, 5, (int)Board.dir.E, 1));
        }
        [Test()]
        public void eastRedOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 9, 5);
            Assert.False(b.isMoveValid(9, 5, (int)Board.dir.E, 1));
        }

        [Test()]
        public void westRedOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 5, 5);
            Assert.True(b.isMoveValid(5, 5, (int)Board.dir.W, 1));
        }
        [Test()]
        public void westRedOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 1, 5);
            Assert.True(b.isMoveValid(1, 5, (int)Board.dir.W, 1));
        }
        [Test()]
        public void westRedOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 2, 5);
            Assert.True(b.isMoveValid(2, 5, (int)Board.dir.W, 1));
        }
        [Test()]
        public void westRedOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 0, 5);
            Assert.False(b.isMoveValid(0, 5, (int)Board.dir.W, 1));
        }

        [Test()]
        public void northBlueOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 0, 5);
            Assert.True(b.isMoveValid(0, 5, (int)Board.dir.N, 1));
        }
        [Test()]
        public void northBlueOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 8, 5);
            Assert.True(b.isMoveValid(8, 5, (int)Board.dir.N, 1));
        }
        [Test()]
        public void northBlueOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 7, 5);
            Assert.True(b.isMoveValid(7, 5, (int)Board.dir.N, 1));
        }
        [Test()]
        public void northBlueOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 9, 5);
            Assert.False(b.isMoveValid(9, 5, (int)Board.dir.S, 1));
        }

        [Test()]
        public void southBlueOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 5, 5);
            Assert.True(b.isMoveValid(5, 5, (int)Board.dir.S, 1));
        }
        [Test()]
        public void southBlueOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 1, 5);
            Assert.True(b.isMoveValid(1, 5, (int)Board.dir.S, 1));
        }
        [Test()]
        public void southBlueOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 2, 5);
            Assert.True(b.isMoveValid(2, 5, (int)Board.dir.S, 1));
        }
        [Test()]
        public void southBlueOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 0, 5);
            Assert.False(b.isMoveValid(0, 5, (int)Board.dir.S, 1));
        }

        [Test()]
        public void eastBlueOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 0, 5);
            Assert.True(b.isMoveValid(0, 5, (int)Board.dir.E, 1));
        }
        [Test()]
        public void eastBlueOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 8, 5);
            Assert.True(b.isMoveValid(8, 5, (int)Board.dir.E, 1));
        }
        [Test()]
        public void eastBlueOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 7, 5);
            Assert.True(b.isMoveValid(7, 5, (int)Board.dir.E, 1));
        }
        [Test()]
        public void eastBlueOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 9, 5);
            Assert.False(b.isMoveValid(9, 5, (int)Board.dir.E, 1));
        }

        [Test()]
        public void westBlueOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 5, 5);
            Assert.True(b.isMoveValid(5, 5, (int)Board.dir.W, 1));
        }
        [Test()]
        public void westBlueOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 1, 5);
            Assert.True(b.isMoveValid(1, 5, (int)Board.dir.S, 1));
        }
        [Test()]
        public void westBlueOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 2, 5);
            Assert.True(b.isMoveValid(2, 5, (int)Board.dir.W, 1));
        }
        [Test()]
        public void westBlueOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 0, 5);
            Assert.False(b.isMoveValid(0, 5, (int)Board.dir.W, 1));
        }

        //    [Test()]
        //    public void scoutMultipleOpenSpaceForwardTrue()
        //    {
        //        Board b = new Board();
        //        b.placePiece(new Piece(0, 2), 0, 5);
        //        Assert.True(b.isMoveValid(0, 5,0,3));
        //    }
        //    [Test()]
        //    public void nonScoutOpenMultipleSpaceForwardFalse()
        //    {
        //        Board b = new Board();
        //        b.placePiece(new Piece(0, 4), 0, 5);
        //        Assert.False(b.isMoveValid(0, 5, 0, 8));
        //    }
        //    [Test()]
        //    public void scoutOpenSpaceSidewaysTrue()
        //    {
        //        Board b = new Board();
        //        b.placePiece(new Piece(0, 2), 0, 5);
        //        Assert.True(b.isMoveValid(0, 5, 5, 5));
        //    }
        //    [Test()]
        //    public void scoutOpenSpaceDiagonalFalse()
        //    {
        //        Board b = new Board();
        //        b.placePiece(new Piece(0, 2), 0, 5);
        //        Assert.False(b.isMoveValid(0, 5, 5, 8));
        //    }
        //    [Test()]
        //    public void nonScoutOpenSpaceDiagonalFalse()
        //    {
        //        Board b = new Board();
        //        b.placePiece(new Piece(0, 2), 0, 5);
        //        Assert.False(b.isMoveValid(0, 5, 5, 8));
        //    }
        //    [Test()]
        //    public void forwardLake()
        //    {
        //        Board b = new Board();
        //        b.placePiece(new Piece(2, 10), 0, 5);
        //        b.placePiece(new Piece(0, 10), 0, 4);
        //        Assert.False(b.isMoveValid(0, 4, 0, 5));
        //    }
        //    [Test()]
        //    public void movefromEmptySpace()
        //    {
        //        Board b = new Board();
        //        Assert.False(b.isMoveValid(0, 4, 0, 5));
        //    }
        //    [Test()]
        //    public void testgetSpace()
        //    {
        //        Board b = new Board();
        //        b.placePiece(new Piece(2, 10), 0, 5);
        //        Assert.True(b.getSpace(0, 5).Equals(new Piece(2, 10)));
        //    }
        //    [Test()]
        //    public void testNonScoutMovementLimit()
        //    {
        //        Board b = new Board();
        //        b.placePiece(new Piece(0, 10), 0, 5);
        //        Assert.False(b.isMoveValid(0, 5, 0, 8));
        //    }
        //    [Test()]
        //    public void testPieceEqualsFalse()
        //    {
        //        Piece p = new Piece(0, 10);
        //        Piece q = new Piece(1, 10);
        //        Assert.False(p.Equals(q));
        //    }
    }
}
