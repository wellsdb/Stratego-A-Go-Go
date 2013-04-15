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
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 0, 5);
            Assert.True(b.isMoveValid(0, 5, Board.Direction.N, 1));
        }
        [Test()]
        public void northRedOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 8, 5);
            Assert.True(b.isMoveValid(8, 5, Board.Direction.N, 1));
        }
        [Test()]
        public void northRedOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 7, 5);
            Assert.True(b.isMoveValid(7, 5, Board.Direction.N, 1));
        }
        [Test()]
        public void northRedOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 9, 5);
            Assert.False(b.isMoveValid(9, 5, Board.Direction.N, 1));
        }
        [Test()]
        public void southRedOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 5, 5);
            Assert.True(b.isMoveValid(5, 5, Board.Direction.S, 1));
        }
        [Test()]
        public void southRedOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 1, 5);
            Assert.True(b.isMoveValid(1, 5, Board.Direction.S, 1));
        }
        [Test()]
        public void southRedOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 2, 5);
            Assert.True(b.isMoveValid(2, 5, Board.Direction.S, 1));
        }
        [Test()]
        public void southRedOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 0, 5);
            Assert.False(b.isMoveValid(0, 5, Board.Direction.S, 1));
        }
        [Test()]
        public void eastRedOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 0, 5);
            Assert.True(b.isMoveValid(0, 5, Board.Direction.E, 1));
        }
        [Test()]
        public void eastRedOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 5, 8);
            Assert.True(b.isMoveValid(5, 8, Board.Direction.E, 1));
        }
        [Test()]
        public void eastRedOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 7, 5);
            Assert.True(b.isMoveValid(7, 5, Board.Direction.E, 1));
        }
        [Test()]
        public void eastRedOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 5, 9);
            Assert.False(b.isMoveValid(5, 9, Board.Direction.E, 1));
        }
        [Test()]
        public void westRedOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 5, 5);
            Assert.True(b.isMoveValid(5, 5, Board.Direction.W, 1));
        }
        [Test()]
        public void westRedOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 1, 5);
            Assert.True(b.isMoveValid(1, 5, Board.Direction.W, 1));
        }
        [Test()]
        public void westRedOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 2, 5);
            Assert.True(b.isMoveValid(2, 5, Board.Direction.W, 1));
        }
        [Test()]
        public void westRedOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 5, 0);
            Assert.False(b.isMoveValid(5, 0, Board.Direction.W, 1));
        }
        [Test()]
        public void northBlueOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 0, 5);
            Assert.True(b.isMoveValid(0, 5, Board.Direction.N, 1));
        }
        [Test()]
        public void northBlueOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 8, 5);
            Assert.True(b.isMoveValid(8, 5, Board.Direction.N, 1));
        }
        [Test()]
        public void northBlueOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 7, 5);
            Assert.True(b.isMoveValid(7, 5, Board.Direction.N, 1));
        }
        [Test()]
        public void northBlueOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 9, 5);
            Assert.False(b.isMoveValid(9, 5, Board.Direction.N, 1));
        }
        [Test()]
        public void southBlueOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 5, 5);
            Assert.True(b.isMoveValid(5, 5, Board.Direction.S, 1));
        }
        [Test()]
        public void southBlueOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 1, 5);
            Assert.True(b.isMoveValid(1, 5, Board.Direction.S, 1));
        }
        [Test()]
        public void southBlueOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 2, 5);
            Assert.True(b.isMoveValid(2, 5, Board.Direction.S, 1));
        }
        [Test()]
        public void southBlueOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 0, 5);
            Assert.False(b.isMoveValid(0, 5, Board.Direction.S, 1));
        }
        [Test()]
        public void eastBlueOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 0, 5);
            Assert.True(b.isMoveValid(0, 5, Board.Direction.E, 1));
        }
        [Test()]
        public void eastBlueOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 5, 8);
            Assert.True(b.isMoveValid(5, 8, Board.Direction.E, 1));
        }
        [Test()]
        public void eastBlueOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 7, 5);
            Assert.True(b.isMoveValid(7, 5, Board.Direction.E, 1));
        }
        [Test()]
        public void eastBlueOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 5, 9);
            Assert.False(b.isMoveValid(5, 9, Board.Direction.E, 1));
        }
        [Test()]
        public void westBlueOneOpenSpaceTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 5, 5);
            Assert.True(b.isMoveValid(5, 5, Board.Direction.W, 1));
        }
        [Test()]
        public void westBlueOneOpenSpaceToEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 5, 1);
            Assert.True(b.isMoveValid(5, 1, Board.Direction.S, 1));
        }
        [Test()]
        public void westBlueOneOpenSpaceOneAwayFromEdgeTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 2, 5);
            Assert.True(b.isMoveValid(2, 5, Board.Direction.W, 1));
        }
        [Test()]
        public void westBlueOneOpenSpaceOverEdgeFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 5, 0);
            Assert.False(b.isMoveValid(5, 0, Board.Direction.W, 1));
        }
        [Test()]
        public void northRedMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.N, 2));
        }
        [Test()]
        public void southRedMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 5, 4);
            Assert.False(b.isMoveValid(5, 4, Board.Direction.S, 2));
        }
        [Test()]
        public void eastRedMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 6, 4);
            Assert.False(b.isMoveValid(6, 4, Board.Direction.E, 2));
        }
        [Test()]
        public void westRedMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 6, 5);
            Assert.False(b.isMoveValid(6, 5, Board.Direction.W, 2));
        }
        [Test()]
        public void northBlueMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.N, 2));
        }
        [Test()]
        public void southBlueMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.S, 2));
        }
        [Test()]
        public void eastBlueMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 6, 4);
            Assert.False(b.isMoveValid(6, 4, Board.Direction.E, 2));
        }
        [Test()]
        public void westBlueMarshalMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 6, 5);
            Assert.False(b.isMoveValid(6, 5, Board.Direction.W, 2));
        }
        [Test()]
        public void northRedGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.general), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.N, 2));
        }
        [Test()]
        public void southRedGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.general), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.S, 2));
        }
        [Test()]
        public void eastRedGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.general), 6, 4);
            Assert.False(b.isMoveValid(6, 4, Board.Direction.E, 2));
        }
        [Test()]
        public void westRedGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.general), 6, 5);
            Assert.False(b.isMoveValid(6, 5, Board.Direction.W, 2));
        }
        [Test()]
        public void northBlueGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.general), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.N, 2));
        }
        [Test()]
        public void southBlueGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.general), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.S, 2));
        }
        [Test()]
        public void eastBlueGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.general), 6, 4);
            Assert.False(b.isMoveValid(6, 4, Board.Direction.E, 2));
        }
        [Test()]
        public void westBlueGeneralMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.general), 6, 5);
            Assert.False(b.isMoveValid(6, 5, Board.Direction.W, 2));
        }
        [Test()]
        public void northRedBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.N, 2));
        }
        [Test()]
        public void southRedBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.S, 2));
        }
        [Test()]
        public void eastRedBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), 6, 4);
            Assert.False(b.isMoveValid(6, 4, Board.Direction.E, 2));
        }
        [Test()]
        public void westRedBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), 6, 5);
            Assert.False(b.isMoveValid(6, 5, Board.Direction.W, 2));
        }
        [Test()]
        public void northBlueBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.N, 2));
        }
        [Test()]
        public void southBlueBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.S, 2));
        }
        [Test()]
        public void eastBlueBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), 6, 5);
            Assert.False(b.isMoveValid(6, 5, Board.Direction.E, 2));
        }
        [Test()]
        public void westBlueBombMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), 6, 5);
            Assert.False(b.isMoveValid(6, 5, Board.Direction.W, 2));
        }
        [Test()]
        public void northRedFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, 0), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.N, 2));
        }
        [Test()]
        public void southRedFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, 0), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.S, 2));
        }
        [Test()]
        public void eastRedFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, 0), 6, 4);
            Assert.False(b.isMoveValid(6, 4, Board.Direction.E, 2));
        }
        [Test()]
        public void westRedFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, 0), 6, 5);
            Assert.False(b.isMoveValid(6, 5, Board.Direction.W, 2));
        }
        [Test()]
        public void northBlueFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, 0), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.N, 2));
        }
        [Test()]
        public void southBlueFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, 0), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.S, 2));
        }
        [Test()]
        public void eastBlueFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, 0), 6, 4);
            Assert.False(b.isMoveValid(6, 4, Board.Direction.E, 2));
        }
        [Test()]
        public void westBlueFlagMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, 0), 6, 5);
            Assert.False(b.isMoveValid(6, 5, Board.Direction.W, 2));
        }

        [Test()]
        public void northRedSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.spy), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.N, 2));
        }
        [Test()]
        public void southRedSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.spy), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.S, 2));
        }
        [Test()]
        public void eastRedSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.spy), 6, 4);
            Assert.False(b.isMoveValid(6, 4, Board.Direction.E, 2));
        }
        [Test()]
        public void westRedSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.spy), 6, 5);
            Assert.False(b.isMoveValid(6, 5, Board.Direction.W, 2));
        }
        [Test()]
        public void northBlueSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.spy), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.N, 2));
        }
        [Test()]
        public void southBlueSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.spy), 5, 5);
            Assert.False(b.isMoveValid(5, 5, Board.Direction.S, 2));
        }
        [Test()]
        public void eastBlueSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.spy), 6, 4);
            Assert.False(b.isMoveValid(6, 4, Board.Direction.E, 2));
        }
        [Test()]
        public void westBlueSpyMobilityLimitFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.spy), 6, 5);
            Assert.False(b.isMoveValid(6, 5, Board.Direction.W, 2));
        }

        [Test()]
        public void northRedScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 5, 5);
            Assert.True(b.isMoveValid(5, 5, Board.Direction.N, 2));
        }
        [Test()]
        public void southRedScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 5, 5);
            Assert.True(b.isMoveValid(5, 5, Board.Direction.S, 2));
        }
        [Test()]
        public void eastRedScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 6, 4);
            Assert.True(b.isMoveValid(6, 4, Board.Direction.E, 2));
        }
        [Test()]
        public void westRedScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 6, 5);
            Assert.True(b.isMoveValid(6, 5, Board.Direction.W, 2));
        }
        [Test()]
        public void northBlueScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 5, 5);
            Assert.True(b.isMoveValid(5, 5, Board.Direction.N, 2));
        }
        [Test()]
        public void southBlueScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 5, 5);
            Assert.True(b.isMoveValid(5, 5, Board.Direction.S, 2));
        }
        [Test()]
        public void eastBlueScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 6, 5);
            Assert.True(b.isMoveValid(6, 5, Board.Direction.E, 2));
        }
        [Test()]
        public void westBlueScoutMobilityLimitTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 6, 5);
            Assert.True(b.isMoveValid(6, 5, Board.Direction.W, 2));
        }
        [Test()]
        public void westEdgeSouthGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 1, 0);
            Assert.True(p.Equals(b.getPiece(1, 0)));
        }
        [Test()]
        public void westEdgeNorthGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 8, 0);
            Assert.True(p.Equals(b.getPiece(8, 0)));
        }
        [Test()]
        public void southEdgeWestGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 0, 1);
            Assert.True(p.Equals(b.getPiece(0, 1)));
        }
        [Test()]
        public void southEdgeEastGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 0, 8);
            Assert.True(p.Equals(b.getPiece(0, 8)));
        }
        [Test()]
        public void northEdgeEastGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 9, 1);
            Assert.True(p.Equals(b.getPiece(9, 1)));
        }
        [Test()]
        public void northEdgeWestGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 9, 8);
            Assert.True(p.Equals(b.getPiece(9, 8)));
        }
        [Test()]
        public void eastEdgeSouthGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 1, 9);
            Assert.True(p.Equals(b.getPiece(1, 9)));
        }
        [Test()]
        public void eastEdgeNorthGetSpaceTrue()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 8, 9);
            Assert.True(p.Equals(b.getPiece(8, 9)));
        }
        [Test()]
        public void getSpaceFalse()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            Piece q = new Piece(Piece.Team.red, Piece.Rank.scout);
            b.placePiece(p, 5, 5);
            Assert.False(q.Equals(b.getPiece(5,5)));
        }
        [Test()]
        public void moveIntoLakeFalse()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 3, 6);
            Assert.False(b.isMoveValid(3, 6, Board.Direction.N, 1));
        }
        [Test()]
        public void moveScoutOverLakeFalse()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 3, 6);
            Assert.False(b.isMoveValid(3, 6, Board.Direction.N, 3));
        }
        [Test()]
        public void moveScoutWayOverLakeFalse()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 3, 6);
            Assert.False(b.isMoveValid(3, 6, Board.Direction.N, 5));
        }
        [Test()]
        public void moveScoutOverSameTeamPieceHigherRankedFalse()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 0, 5);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 0, 6);
            Assert.False(b.isMoveValid(0, 5, Board.Direction.E, 3));
        }
        [Test()]
        public void moveScoutOverSameTeamPieceLowerRankedFalse()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 0, 5);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.flag), 0, 6);
            Assert.False(b.isMoveValid(0, 5, Board.Direction.E, 3));
        }
        [Test()]
        public void moveScoutOverOppositeTeamPieceHigherRankedFalse()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 0, 5);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 0, 6);
            Assert.False(b.isMoveValid(0, 5, Board.Direction.E, 3));
        }
        [Test()]
        public void moveScoutOverOppositeTeamPieceLowerRankedFalse()
        {
            Board b = new Board();
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            b.placePiece(p, 0, 5);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.flag), 0, 6);
            Assert.False(b.isMoveValid(0, 5, Board.Direction.E, 3));
        }
        [Test()]
        public void victorySignalRedOnBlueTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 0, 5);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.flag), 0, 6);
            Assert.True(b.isVictory(0, 5, Board.Direction.E, 1));
        }
        [Test()]
        public void victorySignalBlueonRedTrue()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 0, 5);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.flag), 0, 6);
            Assert.True(b.isVictory(0, 5, Board.Direction.E, 1));
        }
        [Test()]
        public void victorySignalFalse()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 0, 4);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.flag), 0, 6);
            Assert.True(b.isVictory(0, 5, Board.Direction.E, 1));
        }

        [Test()]
        public void TestIsMoveValidOntoAllyCell()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 1, 3);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 1, 2);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 1, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 0, 3);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 2, 3);
            Assert.False(b.isMoveValid(1, 3, Board.Direction.N, 1));
            Assert.False(b.isMoveValid(1, 3, Board.Direction.S, 1));
            Assert.False(b.isMoveValid(1, 3, Board.Direction.E, 1));
            Assert.False(b.isMoveValid(1, 3, Board.Direction.W, 1));
        }

        [Test()]
        public void TestIsMoveValidOntoAllyCellByScout()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 2, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 0, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 4, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 2, 2);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 2, 6);
            Assert.False(b.isMoveValid(2, 4, Board.Direction.N, 2));
            Assert.False(b.isMoveValid(2, 4, Board.Direction.S, 2));
            Assert.False(b.isMoveValid(2, 4, Board.Direction.E, 2));
            Assert.False(b.isMoveValid(2, 4, Board.Direction.W, 2));
        }

        [Test()]
        public void TestIsMoveValidOntoEnemyCell()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 1, 3);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 1, 2);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 1, 4);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 0, 3);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 2, 3);
            Assert.True(b.isMoveValid(1, 3, Board.Direction.N, 1));
            Assert.True(b.isMoveValid(1, 3, Board.Direction.S, 1));
            Assert.True(b.isMoveValid(1, 3, Board.Direction.E, 1));
            Assert.True(b.isMoveValid(1, 3, Board.Direction.W, 1));
        }

        [Test()]
        public void TestIsMoveValidOntoEnemyCellByScout()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 2, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 0, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 4, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 2, 2);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 2, 6);
            Assert.True(b.isMoveValid(2, 4, Board.Direction.N, 2));
            Assert.True(b.isMoveValid(2, 4, Board.Direction.S, 2));
            Assert.True(b.isMoveValid(2, 4, Board.Direction.E, 2));
            Assert.True(b.isMoveValid(2, 4, Board.Direction.W, 2));
        }

        [Test()]
        public void TestThatEventReturnsGoodMove()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 2, 4);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 7, 5);

            Assert.AreEqual(Board.Event.GoodMove, b.moveEvent(2, 4, Board.Direction.N, 3));
            Assert.AreEqual(Board.Event.GoodMove, b.moveEvent(2, 4, Board.Direction.W, 1));
            Assert.AreEqual(Board.Event.GoodMove, b.moveEvent(7, 5, Board.Direction.S, 1));
            Assert.AreEqual(Board.Event.GoodMove, b.moveEvent(7, 5, Board.Direction.E, 1));
        }

        [Test()]
        public void TestThatEventReturnsBadMove()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 6, 6);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 6, 2);

            Assert.AreEqual(Board.Event.BadMove, b.moveEvent(6, 6, Board.Direction.W, 6));
            Assert.AreEqual(Board.Event.BadMove, b.moveEvent(6, 6, Board.Direction.N, 4));
            Assert.AreEqual(Board.Event.BadMove, b.moveEvent(6, 2, Board.Direction.S, 1));
            Assert.AreEqual(Board.Event.BadMove, b.moveEvent(6, 2, Board.Direction.E, 2));
        }


        [Test()]
        public void TestThatEventReturnsWin()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.colonel), 2, 4);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.major), 1,4 );
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.captain), 2, 3);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.lieutenant), 2, 5);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.sergeant), 3, 4);

            Assert.AreEqual(Board.Event.Win, b.moveEvent(2, 4, Board.Direction.S, 1));
            Assert.AreEqual(Board.Event.Win, b.moveEvent(2, 4, Board.Direction.W, 1));
            Assert.AreEqual(Board.Event.Win, b.moveEvent(2, 4, Board.Direction.N, 1));
            Assert.AreEqual(Board.Event.Win, b.moveEvent(2, 4, Board.Direction.E, 1));
        }

        [Test()]
        public void TestThatEventReturnsLoss()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.sergeant), 2, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.lieutenant), 1, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.captain), 3, 4);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.major), 2, 3);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.colonel), 2, 5);

            Assert.AreEqual(Board.Event.Loss, b.moveEvent(2, 4, Board.Direction.S, 1));
            Assert.AreEqual(Board.Event.Loss, b.moveEvent(2, 4, Board.Direction.W, 1));
            Assert.AreEqual(Board.Event.Loss, b.moveEvent(2, 4, Board.Direction.N, 1));
            Assert.AreEqual(Board.Event.Loss, b.moveEvent(2, 4, Board.Direction.E, 1));
        }

        [Test()]
        public void TestThatEventReturnsTie()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.sergeant), 2, 2);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.lieutenant), 7, 7);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.sergeant), 1, 2);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.lieutenant), 7, 8);

            Assert.AreEqual(Board.Event.Tie, b.moveEvent(2, 2, Board.Direction.S, 1));
            Assert.AreEqual(Board.Event.Tie, b.moveEvent(7, 8, Board.Direction.W, 1));
        }

        [Test()]
        public void TestThatSpyBeatsMarshal()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.spy), 1, 1);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 8, 8);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.spy), 8, 9);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.marshal), 0, 1);

            Assert.AreEqual(Board.Event.Win, b.moveEvent(1, 1, Board.Direction.S, 1));
            Assert.AreEqual(Board.Event.Loss, b.moveEvent(8, 8, Board.Direction.E, 1));
        }

        [Test()]
        public void TestThatBombBeatsAllButMiner()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 1, 1);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), 8, 8);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.scout), 8, 9);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), 0, 1);

            Assert.AreEqual(Board.Event.Loss, b.moveEvent(1, 1, Board.Direction.S, 1));
            Assert.AreEqual(Board.Event.Loss, b.moveEvent(8, 9, Board.Direction.W, 1));
        }

        [Test()]
        public void TestThatMinerBeatsBomb()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.miner), 1, 1);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.bomb), 8, 8);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.miner), 8, 9);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.bomb), 0, 1);

            Assert.AreEqual(Board.Event.Win, b.moveEvent(1, 1, Board.Direction.S, 1));
            Assert.AreEqual(Board.Event.Win, b.moveEvent(8, 9, Board.Direction.W, 1));
        }

        [Test()]
        public void TestThatEventReturnsFlag()
        {
            Board b = new Board();
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.flag), 1, 1);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.flag), 8, 1);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.flag), 1, 8);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.flag), 8, 8);


            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.scout), 1, 9);
            b.placePiece(new Piece(Piece.Team.blue, Piece.Rank.marshal), 8, 7);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.spy), 0, 1);
            b.placePiece(new Piece(Piece.Team.red, Piece.Rank.colonel), 9, 1);

            Assert.AreEqual(Board.Event.Flag, b.moveEvent(1, 9, Board.Direction.W, 1));
            Assert.AreEqual(Board.Event.Flag, b.moveEvent(8, 7, Board.Direction.E, 1));
            Assert.AreEqual(Board.Event.Flag, b.moveEvent(0, 1, Board.Direction.N, 1));
            Assert.AreEqual(Board.Event.Flag, b.moveEvent(9, 1, Board.Direction.S, 1));
        }

    }
}
