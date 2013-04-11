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
            b.placePiece(new Piece((int)Piece.team.red, 10), 5, 8);
            Assert.True(b.isMoveValid(5, 8, (int)Board.dir.E, 1));
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
            b.placePiece(new Piece((int)Piece.team.red, 10), 5, 9);
            Assert.False(b.isMoveValid(5, 9, (int)Board.dir.E, 1));
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
            b.placePiece(new Piece((int)Piece.team.red, 10), 5, 0);
            Assert.False(b.isMoveValid(5, 0, (int)Board.dir.W, 1));
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
            Assert.False(b.isMoveValid(9, 5, (int)Board.dir.N, 1));
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
            b.placePiece(new Piece((int)Piece.team.blue, 10), 5, 8);
            Assert.True(b.isMoveValid(5, 8, (int)Board.dir.E, 1));
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
            b.placePiece(new Piece((int)Piece.team.blue, 10), 5, 9);
            Assert.False(b.isMoveValid(5, 9, (int)Board.dir.E, 1));
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
            b.placePiece(new Piece((int)Piece.team.blue, 10), 5, 1);
            Assert.True(b.isMoveValid(5, 1, (int)Board.dir.S, 1));
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
            b.placePiece(new Piece((int)Piece.team.blue, 10), 5, 0);
            Assert.False(b.isMoveValid(5, 0, (int)Board.dir.W, 1));
        }
        [Test()]
        public void northRedMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.N, 2));
        }
        [Test()]
        public void southRedMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 5, 4);
            Assert.False(b.isMoveValid(5, 4, (int)Board.dir.S, 2));
        }
        [Test()]
        public void eastRedMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 6, 4);
            Assert.False(b.isMoveValid(6, 4, (int)Board.dir.E, 2));
        }
        [Test()]
        public void westRedMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 6, 5);
            Assert.False(b.isMoveValid(6, 5, (int)Board.dir.W, 2));
        }
        [Test()]
        public void northBlueMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.N, 2));
        }
        [Test()]
        public void southBlueMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.S, 2));
        }
        [Test()]
        public void eastBlueMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 6, 4);
            Assert.False(b.isMoveValid(6, 4, (int)Board.dir.E, 2));
        }
        [Test()]
        public void westBlueMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 6, 5);
            Assert.False(b.isMoveValid(6, 5, (int)Board.dir.W, 2));
        }
        [Test()]
        public void northRedGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 9), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.N, 2));
        }
        [Test()]
        public void southRedGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 9), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.S, 2));
        }
        [Test()]
        public void eastRedGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 9), 6, 4);
            Assert.False(b.isMoveValid(6, 4, (int)Board.dir.E, 2));
        }
        [Test()]
        public void westRedGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 9), 6, 5);
            Assert.False(b.isMoveValid(6, 5, (int)Board.dir.W, 2));
        }
        [Test()]
        public void northBlueGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 9), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.N, 2));
        }
        [Test()]
        public void southBlueGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 9), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.S, 2));
        }
        [Test()]
        public void eastBlueGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 9), 6, 4);
            Assert.False(b.isMoveValid(6, 4, (int)Board.dir.E, 2));
        }
        [Test()]
        public void westBlueGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 9), 6, 5);
            Assert.False(b.isMoveValid(6, 5, (int)Board.dir.W, 2));
        }
        [Test()]
        public void northRedBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 11), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.N, 2));
        }
        [Test()]
        public void southRedBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 11), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.S, 2));
        }
        [Test()]
        public void eastRedBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 11), 6, 4);
            Assert.False(b.isMoveValid(6, 4, (int)Board.dir.E, 2));
        }
        [Test()]
        public void westRedBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 11), 6, 5);
            Assert.False(b.isMoveValid(6, 5, (int)Board.dir.W, 2));
        }
        [Test()]
        public void northBlueBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 11), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.N, 2));
        }
        [Test()]
        public void southBlueBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 11), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.S, 2));
        }
        [Test()]
        public void eastBlueBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 11), 6, 5);
            Assert.False(b.isMoveValid(6, 5, (int)Board.dir.E, 2));
        }
        [Test()]
        public void westBlueBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 11), 6, 5);
            Assert.False(b.isMoveValid(6, 5, (int)Board.dir.W, 2));
        }
        [Test()]
        public void northRedFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 0), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.N, 2));
        }
        [Test()]
        public void southRedFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 0), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.S, 2));
        }
        [Test()]
        public void eastRedFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 0), 6, 4);
            Assert.False(b.isMoveValid(6, 4, (int)Board.dir.E, 2));
        }
        [Test()]
        public void westRedFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 0), 6, 5);
            Assert.False(b.isMoveValid(6, 5, (int)Board.dir.W, 2));
        }
        [Test()]
        public void northBlueFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 0), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.N, 2));
        }
        [Test()]
        public void southBlueFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 0), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.S, 2));
        }
        [Test()]
        public void eastBlueFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 0), 6, 4);
            Assert.False(b.isMoveValid(6, 4, (int)Board.dir.E, 2));
        }
        [Test()]
        public void westBlueFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 0), 6, 5);
            Assert.False(b.isMoveValid(6, 5, (int)Board.dir.W, 2));
        }

        [Test()]
        public void northRedSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 1), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.N, 2));
        }
        [Test()]
        public void southRedSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 1), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.S, 2));
        }
        [Test()]
        public void eastRedSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 1), 6, 4);
            Assert.False(b.isMoveValid(6, 4, (int)Board.dir.E, 2));
        }
        [Test()]
        public void westRedSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 1), 6, 5);
            Assert.False(b.isMoveValid(6, 5, (int)Board.dir.W, 2));
        }
        [Test()]
        public void northBlueSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 1), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.N, 2));
        }
        [Test()]
        public void southBlueSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 1), 5, 5);
            Assert.False(b.isMoveValid(5, 5, (int)Board.dir.S, 2));
        }
        [Test()]
        public void eastBlueSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 1), 6, 4);
            Assert.False(b.isMoveValid(6, 4, (int)Board.dir.E, 2));
        }
        [Test()]
        public void westBlueSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 1), 6, 5);
            Assert.False(b.isMoveValid(6, 5, (int)Board.dir.W, 2));
        }

        [Test()]
        public void northRedScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 2), 5, 5);
            Assert.True(b.isMoveValid(5, 5, (int)Board.dir.N, 2));
        }
        [Test()]
        public void southRedScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 2), 5, 5);
            Assert.True(b.isMoveValid(5, 5, (int)Board.dir.S, 2));
        }
        [Test()]
        public void eastRedScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 2), 6, 4);
            Assert.True(b.isMoveValid(6, 4, (int)Board.dir.E, 2));
        }
        [Test()]
        public void westRedScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 2), 6, 5);
            Assert.True(b.isMoveValid(6, 5, (int)Board.dir.W, 2));
        }
        [Test()]
        public void northBlueScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 2), 5, 5);
            Assert.True(b.isMoveValid(5, 5, (int)Board.dir.N, 2));
        }
        [Test()]
        public void southBlueScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 2), 5, 5);
            Assert.True(b.isMoveValid(5, 5, (int)Board.dir.S, 2));
        }
        [Test()]
        public void eastBlueScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 2), 6, 5);
            Assert.True(b.isMoveValid(6, 5, (int)Board.dir.E, 2));
        }
        [Test()]
        public void westBlueScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 2), 6, 5);
            Assert.True(b.isMoveValid(6, 5, (int)Board.dir.W, 2));
        }
        [Test()]
        public void westEdgeSouthGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 1, 0);
            Assert.True(p.Equals(b.getSpace(1, 0)));
        }
        [Test()]
        public void westEdgeNorthGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 8, 0);
            Assert.True(p.Equals(b.getSpace(8, 0)));
        }
        [Test()]
        public void southEdgeWestGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 0, 1);
            Assert.True(p.Equals(b.getSpace(0, 1)));
        }
        [Test()]
        public void southEdgeEastGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 0, 8);
            Assert.True(p.Equals(b.getSpace(0, 8)));
        }
        [Test()]
        public void northEdgeEastGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 9, 1);
            Assert.True(p.Equals(b.getSpace(9, 1)));
        }
        [Test()]
        public void northEdgeWestGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 9, 8);
            Assert.True(p.Equals(b.getSpace(9, 8)));
        }
        [Test()]
        public void eastEdgeSouthGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 1, 9);
            Assert.True(p.Equals(b.getSpace(1, 9)));
        }
        [Test()]
        public void eastEdgeNorthGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 8, 9);
            Assert.True(p.Equals(b.getSpace(8, 9)));
        }
        [Test()]
        public void getSpaceFalse()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            Piece q = new Piece((int)Piece.team.red, 2);
            b.placePiece(p, 5, 5);
            Assert.False(q.Equals(b.getSpace(5,5)));
        }
        [Test()]
        public void moveIntoLakeFalse()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 3, 6);
            Assert.False(b.isMoveValid(3, 6, (int)Board.dir.N, 1));
        }
        [Test()]
        public void moveScoutOverLakeFalse()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 3, 6);
            Assert.False(b.isMoveValid(3, 6, (int)Board.dir.N, 3));
        }
        [Test()]
        public void moveScoutWayOverLakeFalse()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 3, 6);
            Assert.False(b.isMoveValid(3, 6, (int)Board.dir.N, 5));
        }
        [Test()]
        public void moveScoutOverSameTeamPieceHigherRankedFalse()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 0, 5);
            b.placePiece(new Piece((int)Piece.team.blue, 10), 0, 6);
            Assert.False(b.isMoveValid(0, 5, (int)Board.dir.E, 3));
        }
        [Test()]
        public void moveScoutOverSameTeamPieceLowerRankedFalse()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 0, 5);
            b.placePiece(new Piece((int)Piece.team.blue, 0), 0, 6);
            Assert.False(b.isMoveValid(0, 5, (int)Board.dir.E, 3));
        }
        [Test()]
        public void moveScoutOverOppositeTeamPieceHigherRankedFalse()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 0, 5);
            b.placePiece(new Piece((int)Piece.team.red, 10), 0, 6);
            Assert.False(b.isMoveValid(0, 5, (int)Board.dir.E, 3));
        }
        [Test()]
        public void moveScoutOverOppositeTeamPieceLowerRankedFalse()
        {
            Board b = new Board();
            Piece p = new Piece((int)Piece.team.blue, 2);
            b.placePiece(p, 0, 5);
            b.placePiece(new Piece((int)Piece.team.red, 0), 0, 6);
            Assert.False(b.isMoveValid(0, 5, (int)Board.dir.E, 3));
        }
        [Test()]
        public void victorySignalRedOnBlueTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 0, 5);
            b.placePiece(new Piece((int)Piece.team.blue, 0), 0, 6);
            Assert.True(b.isVictory(0, 5, (int)Board.dir.E, 1));
        }
        [Test()]
        public void victorySignalBlueonRedTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.blue, 10), 0, 5);
            b.placePiece(new Piece((int)Piece.team.red, 0), 0, 6);
            Assert.True(b.isVictory(0, 5, (int)Board.dir.E, 1));
        }
        [Test()]
        public void victorySignalFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece((int)Piece.team.red, 10), 0, 4);
            b.placePiece(new Piece((int)Piece.team.blue, 0), 0, 6);
            Assert.True(b.isVictory(0, 5, (int)Board.dir.E, 1));
        }
    }
}
