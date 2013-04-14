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
    class PieceTests
    {
        [Test()]
        public void testRedMarshalPieceEqualsTrue()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.marshal);
            Piece q = new Piece(Piece.Team.red, Piece.Rank.marshal);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testRedGeneralPieceEqualsTrue()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.general);
            Piece q = new Piece(Piece.Team.red, Piece.Rank.general);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testRedScoutPieceEqualsTrue()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece q = new Piece(Piece.Team.red, Piece.Rank.scout);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testRedSpyPieceEqualsTrue()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.spy);
            Piece q = new Piece(Piece.Team.red, Piece.Rank.spy);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testRedBombPieceEqualsTrue()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.bomb);
            Piece q = new Piece(Piece.Team.red, Piece.Rank.bomb);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testRedFlagPieceEqualsTrue()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.flag);
            Piece q = new Piece(Piece.Team.red, Piece.Rank.flag);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testBlueMarshalPieceEqualsTrue()
        {
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.marshal);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.marshal);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testBlueGeneralPieceEqualsTrue()
        {
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.general);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.general);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testBlueScoutPieceEqualsTrue()
        {
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.scout);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testBlueSpyPieceEqualsTrue()
        {
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.spy);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.spy);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testBlueBombPieceEqualsTrue()
        {
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.bomb);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.bomb);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testBlueFlagPieceEqualsTrue()
        {
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.flag);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.flag);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testMarshalsEqualsNotSameTeam()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.marshal);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.marshal);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testGeneralsEqualsNotSameTeam()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.general);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.general);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testScoutEqualsNotSameTeam()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.scout);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testSpiesEqualsNotSameTeam()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.spy);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.spy);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testBombsEqualsNotSameTeam()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.bomb);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.bomb);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testFlagsEqualsNotSameTeam()
        {
            Piece p = new Piece(Piece.Team.red, 0);
            Piece q = new Piece(Piece.Team.blue, 0);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testRedBombMarshalEqualsFalse()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.bomb);
            Piece q = new Piece(Piece.Team.red, Piece.Rank.marshal);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testRedMarshalGeneralEqualsFalse()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.marshal);
            Piece q = new Piece(Piece.Team.red, Piece.Rank.general);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testRedGeneralColonelEqualsFalse()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.general);
            Piece q = new Piece(Piece.Team.red, Piece.Rank.colonel);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testRedScoutSpyEqualsFalse()
        {
            Piece p = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece q = new Piece(Piece.Team.red, Piece.Rank.spy);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testRedSpyFlagEqualsFalse()
        {
            Piece p = new Piece(Piece.Team.red, 0);
            Piece q = new Piece(Piece.Team.red, Piece.Rank.spy);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testBlueBombMarshalEqualsFalse()
        {
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.bomb);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.marshal);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testBlueMarshalGeneralEqualsFalse()
        {
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.marshal);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.general);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testBlueGeneralColonelEqualsFalse()
        {
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.general);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.colonel);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testBlueScoutSpyEqualsFalse()
        {
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.scout);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.spy);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testBlueSpyFlagEqualsFalse()
        {
            Piece p = new Piece(Piece.Team.blue, 0);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.spy);
            Assert.False(p.Equals(q));
        }
    }
}