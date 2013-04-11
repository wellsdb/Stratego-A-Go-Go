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
            Piece p = new Piece((int)Piece.team.red, 10);
            Piece q = new Piece((int)Piece.team.red, 10);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testRedGeneralPieceEqualsTrue()
        {
            Piece p = new Piece((int)Piece.team.red, 9);
            Piece q = new Piece((int)Piece.team.red, 9);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testRedScoutPieceEqualsTrue()
        {
            Piece p = new Piece((int)Piece.team.red, 2);
            Piece q = new Piece((int)Piece.team.red, 2);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testRedSpyPieceEqualsTrue()
        {
            Piece p = new Piece((int)Piece.team.red, 1);
            Piece q = new Piece((int)Piece.team.red, 1);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testRedBombPieceEqualsTrue()
        {
            Piece p = new Piece((int)Piece.team.red, 11);
            Piece q = new Piece((int)Piece.team.red, 11);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testRedFlagPieceEqualsTrue()
        {
            Piece p = new Piece((int)Piece.team.red, 10);
            Piece q = new Piece((int)Piece.team.red, 10);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testBlueMarshalPieceEqualsTrue()
        {
            Piece p = new Piece((int)Piece.team.blue, 10);
            Piece q = new Piece((int)Piece.team.blue, 10);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testBlueGeneralPieceEqualsTrue()
        {
            Piece p = new Piece((int)Piece.team.blue, 9);
            Piece q = new Piece((int)Piece.team.blue, 9);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testBlueScoutPieceEqualsTrue()
        {
            Piece p = new Piece((int)Piece.team.blue, 2);
            Piece q = new Piece((int)Piece.team.blue, 2);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testBlueSpyPieceEqualsTrue()
        {
            Piece p = new Piece((int)Piece.team.blue, 1);
            Piece q = new Piece((int)Piece.team.blue, 1);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testBlueBombPieceEqualsTrue()
        {
            Piece p = new Piece((int)Piece.team.blue, 11);
            Piece q = new Piece((int)Piece.team.blue, 11);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testBlueFlagPieceEqualsTrue()
        {
            Piece p = new Piece((int)Piece.team.blue, 10);
            Piece q = new Piece((int)Piece.team.blue, 10);
            Assert.True(p.Equals(q));
        }
        [Test()]
        public void testMarshalsEqualsNotSameTeam()
        {
            Piece p = new Piece((int)Piece.team.red, 10);
            Piece q = new Piece((int)Piece.team.blue, 10);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testGeneralsEqualsNotSameTeam()
        {
            Piece p = new Piece((int)Piece.team.red, 9);
            Piece q = new Piece((int)Piece.team.blue, 9);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testScoutEqualsNotSameTeam()
        {
            Piece p = new Piece((int)Piece.team.red, 2);
            Piece q = new Piece((int)Piece.team.blue, 2);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testSpiesEqualsNotSameTeam()
        {
            Piece p = new Piece((int)Piece.team.red, 1);
            Piece q = new Piece((int)Piece.team.blue, 1);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testBombsEqualsNotSameTeam()
        {
            Piece p = new Piece((int)Piece.team.red, 11);
            Piece q = new Piece((int)Piece.team.blue, 11);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testFlagsEqualsNotSameTeam()
        {
            Piece p = new Piece((int)Piece.team.red, 0);
            Piece q = new Piece((int)Piece.team.blue, 0);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testRedBombMarshalEqualsFalse()
        {
            Piece p = new Piece((int)Piece.team.red, 11);
            Piece q = new Piece((int)Piece.team.red, 10);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testRedMarshalGeneralEqualsFalse()
        {
            Piece p = new Piece((int)Piece.team.red, 10);
            Piece q = new Piece((int)Piece.team.red, 9);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testRedGeneralColonelEqualsFalse()
        {
            Piece p = new Piece((int)Piece.team.red, 9);
            Piece q = new Piece((int)Piece.team.red, 8);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testRedScoutSpyEqualsFalse()
        {
            Piece p = new Piece((int)Piece.team.red, 2);
            Piece q = new Piece((int)Piece.team.red, 1);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testRedSpyFlagEqualsFalse()
        {
            Piece p = new Piece((int)Piece.team.red, 0);
            Piece q = new Piece((int)Piece.team.red, 1);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testBlueBombMarshalEqualsFalse()
        {
            Piece p = new Piece((int)Piece.team.blue, 11);
            Piece q = new Piece((int)Piece.team.blue, 10);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testBlueMarshalGeneralEqualsFalse()
        {
            Piece p = new Piece((int)Piece.team.blue, 10);
            Piece q = new Piece((int)Piece.team.blue, 9);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testBlueGeneralColonelEqualsFalse()
        {
            Piece p = new Piece((int)Piece.team.blue, 9);
            Piece q = new Piece((int)Piece.team.blue, 8);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testBlueScoutSpyEqualsFalse()
        {
            Piece p = new Piece((int)Piece.team.blue, 2);
            Piece q = new Piece((int)Piece.team.blue, 1);
            Assert.False(p.Equals(q));
        }
        [Test()]
        public void testBlueSpyFlagEqualsFalse()
        {
            Piece p = new Piece((int)Piece.team.blue, 0);
            Piece q = new Piece((int)Piece.team.blue, 1);
            Assert.False(p.Equals(q));
        }
    }
}