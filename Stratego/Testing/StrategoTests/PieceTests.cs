using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Stratego;

namespace Testing.StrategoTests
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
            Piece p = new Piece(Piece.Team.red, Piece.Rank.flag);
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
            Piece p = new Piece(Piece.Team.blue, Piece.Rank.flag);
            Piece q = new Piece(Piece.Team.blue, Piece.Rank.spy);
            Assert.False(p.Equals(q));
        }

        [Test()]
        public void testBattleAggressorHigherRank()
        {
            Piece agg1 = new Piece(Piece.Team.blue, Piece.Rank.miner);
            Piece agg2 = new Piece(Piece.Team.blue, Piece.Rank.sergeant);
            Piece agg3 = new Piece(Piece.Team.blue, Piece.Rank.lieutenant);
            Piece agg4 = new Piece(Piece.Team.blue, Piece.Rank.captain);
            Piece agg5 = new Piece(Piece.Team.blue, Piece.Rank.major);
            Piece agg6 = new Piece(Piece.Team.blue, Piece.Rank.colonel);
            Piece agg7 = new Piece(Piece.Team.blue, Piece.Rank.general);
            Piece agg8 = new Piece(Piece.Team.blue, Piece.Rank.marshal);

            Piece def1 = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece def2 = new Piece(Piece.Team.red, Piece.Rank.miner);
            Piece def3 = new Piece(Piece.Team.red, Piece.Rank.sergeant);
            Piece def4 = new Piece(Piece.Team.red, Piece.Rank.lieutenant);
            Piece def5 = new Piece(Piece.Team.red, Piece.Rank.captain);
            Piece def6 = new Piece(Piece.Team.red, Piece.Rank.major);
            Piece def7 = new Piece(Piece.Team.red, Piece.Rank.colonel);
            Piece def8 = new Piece(Piece.Team.red, Piece.Rank.general);

            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg1, def1, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg2, def2, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg3, def3, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg4, def4, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg5, def5, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg6, def6, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg7, def7, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg8, def8, Board.BattleMode.Normal));

            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg1, def1, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg2, def2, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg3, def3, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg4, def4, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg5, def5, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg6, def6, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg7, def7, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg8, def8, Board.BattleMode.Reverse));

        }

        [Test()]
        public void testBattleDefenderHigherRank()
        {
            Piece def1 = new Piece(Piece.Team.blue, Piece.Rank.miner);
            Piece def2 = new Piece(Piece.Team.blue, Piece.Rank.sergeant);
            Piece def3 = new Piece(Piece.Team.blue, Piece.Rank.lieutenant);
            Piece def4 = new Piece(Piece.Team.blue, Piece.Rank.captain);
            Piece def5 = new Piece(Piece.Team.blue, Piece.Rank.major);
            Piece def6 = new Piece(Piece.Team.blue, Piece.Rank.colonel);
            Piece def7 = new Piece(Piece.Team.blue, Piece.Rank.general);
            Piece def8 = new Piece(Piece.Team.blue, Piece.Rank.marshal);

            Piece agg1 = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece agg2 = new Piece(Piece.Team.red, Piece.Rank.miner);
            Piece agg3 = new Piece(Piece.Team.red, Piece.Rank.sergeant);
            Piece agg4 = new Piece(Piece.Team.red, Piece.Rank.lieutenant);
            Piece agg5 = new Piece(Piece.Team.red, Piece.Rank.captain);
            Piece agg6 = new Piece(Piece.Team.red, Piece.Rank.major);
            Piece agg7 = new Piece(Piece.Team.red, Piece.Rank.colonel);
            Piece agg8 = new Piece(Piece.Team.red, Piece.Rank.general);

            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg1, def1, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg2, def2, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg3, def3, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg4, def4, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg5, def5, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg6, def6, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg7, def7, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(agg8, def8, Board.BattleMode.Normal));

            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg1, def1, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg2, def2, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg3, def3, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg4, def4, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg5, def5, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg6, def6, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg7, def7, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg8, def8, Board.BattleMode.Reverse));
        }

        [Test()]
        public void testBattleSameRank()
        {
            Piece agg0 = new Piece(Piece.Team.red, Piece.Rank.spy);
            Piece agg1 = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece agg2 = new Piece(Piece.Team.red, Piece.Rank.miner);
            Piece agg3 = new Piece(Piece.Team.red, Piece.Rank.sergeant);
            Piece agg4 = new Piece(Piece.Team.red, Piece.Rank.lieutenant);
            Piece agg5 = new Piece(Piece.Team.red, Piece.Rank.captain);
            Piece agg6 = new Piece(Piece.Team.red, Piece.Rank.major);
            Piece agg7 = new Piece(Piece.Team.red, Piece.Rank.colonel);
            Piece agg8 = new Piece(Piece.Team.red, Piece.Rank.general);
            Piece agg9 = new Piece(Piece.Team.red, Piece.Rank.marshal);

            Assert.AreEqual(Piece.Combat.tie, Piece.Battle(agg0, agg0, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.tie, Piece.Battle(agg1, agg1, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.tie, Piece.Battle(agg2, agg2, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.tie, Piece.Battle(agg3, agg3, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.tie, Piece.Battle(agg4, agg4, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.tie, Piece.Battle(agg5, agg5, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.tie, Piece.Battle(agg6, agg6, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.tie, Piece.Battle(agg7, agg7, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.tie, Piece.Battle(agg8, agg8, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.tie, Piece.Battle(agg9, agg9, Board.BattleMode.Reverse));
        }

        [Test()]
        public void testBattleSpyVsRegularRanks()
        {
            Piece blueSpy = new Piece(Piece.Team.blue, Piece.Rank.spy);
            Piece redSpy = new Piece(Piece.Team.red, Piece.Rank.spy);

            Piece def1 = new Piece(Piece.Team.blue, Piece.Rank.miner);
            Piece def2 = new Piece(Piece.Team.blue, Piece.Rank.sergeant);
            Piece def3 = new Piece(Piece.Team.blue, Piece.Rank.lieutenant);

            Piece agg1 = new Piece(Piece.Team.red, Piece.Rank.captain);
            Piece agg2 = new Piece(Piece.Team.red, Piece.Rank.major);
            Piece agg3 = new Piece(Piece.Team.red, Piece.Rank.colonel);

            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueSpy, def1, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueSpy, def2, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueSpy, def3, Board.BattleMode.Normal));

            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg1, redSpy, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg2, redSpy, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(agg3, redSpy, Board.BattleMode.Normal));
        }

        [Test()]
        public void testBattleSpyVsMarshal()
        {
            Piece blueSpy = new Piece(Piece.Team.blue, Piece.Rank.spy);
            Piece redSpy = new Piece(Piece.Team.red, Piece.Rank.spy);
            Piece blueMarshal = new Piece(Piece.Team.blue, Piece.Rank.marshal);
            Piece redMarshal = new Piece(Piece.Team.red, Piece.Rank.marshal);

            Assert.AreEqual(Piece.Combat.win, Piece.Battle(blueSpy, redMarshal, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueMarshal, redSpy, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(redSpy, blueMarshal, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(redMarshal, blueSpy, Board.BattleMode.Normal));
        }

        [Test()]
        public void testBattleBombsVsRegularRanks()
        {
            Piece blueBomb = new Piece(Piece.Team.blue, Piece.Rank.bomb);
            Piece redBomb = new Piece(Piece.Team.red, Piece.Rank.bomb);

            Piece redAgg0 = new Piece(Piece.Team.red, Piece.Rank.spy);
            Piece redAgg1 = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece redAgg3 = new Piece(Piece.Team.red, Piece.Rank.sergeant);
            Piece redAgg4 = new Piece(Piece.Team.red, Piece.Rank.lieutenant);
            Piece redAgg5 = new Piece(Piece.Team.red, Piece.Rank.captain);
            Piece redAgg6 = new Piece(Piece.Team.red, Piece.Rank.major);
            Piece redAgg7 = new Piece(Piece.Team.red, Piece.Rank.colonel);
            Piece redAgg8 = new Piece(Piece.Team.red, Piece.Rank.general);
            Piece redAgg9 = new Piece(Piece.Team.red, Piece.Rank.marshal);

            Piece blueAgg0 = new Piece(Piece.Team.blue, Piece.Rank.spy);
            Piece blueAgg1 = new Piece(Piece.Team.blue, Piece.Rank.scout);
            Piece blueAgg3 = new Piece(Piece.Team.blue, Piece.Rank.sergeant);
            Piece blueAgg4 = new Piece(Piece.Team.blue, Piece.Rank.lieutenant);
            Piece blueAgg5 = new Piece(Piece.Team.blue, Piece.Rank.captain);
            Piece blueAgg6 = new Piece(Piece.Team.blue, Piece.Rank.major);
            Piece blueAgg7 = new Piece(Piece.Team.blue, Piece.Rank.colonel);
            Piece blueAgg8 = new Piece(Piece.Team.blue, Piece.Rank.general);
            Piece blueAgg9 = new Piece(Piece.Team.blue, Piece.Rank.marshal);

            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(redAgg0, blueBomb, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(redAgg1, blueBomb, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(redAgg3, blueBomb, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(redAgg4, blueBomb, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(redAgg5, blueBomb, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(redAgg6, blueBomb, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(redAgg7, blueBomb, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(redAgg8, blueBomb, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(redAgg9, blueBomb, Board.BattleMode.Normal));

            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueAgg0, redBomb, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueAgg1, redBomb, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueAgg3, redBomb, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueAgg4, redBomb, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueAgg5, redBomb, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueAgg6, redBomb, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueAgg7, redBomb, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueAgg8, redBomb, Board.BattleMode.Reverse));
            Assert.AreEqual(Piece.Combat.loss, Piece.Battle(blueAgg9, redBomb, Board.BattleMode.Reverse));
        }

        [Test()]
        public void testBattleBombsVsMiners()
        {
            Piece blueBomb = new Piece(Piece.Team.blue, Piece.Rank.bomb);
            Piece redBomb = new Piece(Piece.Team.red, Piece.Rank.bomb);

            Piece blueMiner = new Piece(Piece.Team.blue, Piece.Rank.miner);
            Piece redMiner = new Piece(Piece.Team.red, Piece.Rank.miner);

            Assert.AreEqual(Piece.Combat.win, Piece.Battle(blueMiner, redBomb, Board.BattleMode.Normal));
            Assert.AreEqual(Piece.Combat.win, Piece.Battle(redMiner, blueBomb, Board.BattleMode.Reverse));
        }

        [Test()]
        public void testToString()
        {
            Piece redFlag = new Piece(Piece.Team.red, Piece.Rank.flag);
            Piece redSpy = new Piece(Piece.Team.red, Piece.Rank.spy);
            Piece redScout = new Piece(Piece.Team.red, Piece.Rank.scout);
            Piece redMiner = new Piece(Piece.Team.red, Piece.Rank.miner);
            Piece redSergeant = new Piece(Piece.Team.red, Piece.Rank.sergeant);
            Piece redLieutenant = new Piece(Piece.Team.red, Piece.Rank.lieutenant);

            Piece blueCaptain = new Piece(Piece.Team.blue, Piece.Rank.captain);
            Piece blueMajor = new Piece(Piece.Team.blue, Piece.Rank.major);
            Piece blueColonel = new Piece(Piece.Team.blue, Piece.Rank.colonel);
            Piece blueGeneral = new Piece(Piece.Team.blue, Piece.Rank.general);
            Piece blueMarshal = new Piece(Piece.Team.blue, Piece.Rank.marshal);
            Piece blueBomb = new Piece(Piece.Team.blue, Piece.Rank.bomb);

            //Piece nullPiece = null;
            //Assert.AreEqual("||", nullPiece.toString());

            Assert.AreEqual("RF", redFlag.toString());
            Assert.AreEqual("RS", redSpy.toString());
            Assert.AreEqual("R1", redScout.toString());
            Assert.AreEqual("R2", redMiner.toString());
            Assert.AreEqual("R3", redSergeant.toString());
            Assert.AreEqual("R4", redLieutenant.toString());
            Assert.AreEqual("B5", blueCaptain.toString());
            Assert.AreEqual("B6", blueMajor.toString());
            Assert.AreEqual("B7", blueColonel.toString());
            Assert.AreEqual("B8", blueGeneral.toString());
            Assert.AreEqual("B9", blueMarshal.toString());
            Assert.AreEqual("BB", blueBomb.toString());
        }

    }
}