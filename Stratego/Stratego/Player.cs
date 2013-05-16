using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego
{
    public class Player
    {

        public static  readonly Int16 DEFAULT_PIECECOUNT = 40;
        public static readonly String DEFAULT_NAME = "Napoleon";

        private Int16 pieceCount;
        private String name;

        private Boolean hasFlag;
        private Boolean hasMoveable;


        public Player()
        {
            this.pieceCount = DEFAULT_PIECECOUNT;
            this.name = DEFAULT_NAME;
        }

        public Player(String name)
        {
            this.pieceCount = DEFAULT_PIECECOUNT;
            this.name = name;
            this.hasFlag = true;
            this.hasMoveable = true;
        }

        public Player(Int16 pieceCount, String name)
        {
            this.pieceCount = pieceCount;
            this.name = name;
            this.hasFlag = true;
            this.hasMoveable = true;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public Int16 getPieceCount()
        {
            return this.pieceCount;
        }

        public void addPiece()
        {
            this.pieceCount++;
        }

        public void removePiece()
        {
            this.pieceCount--;
        }

        public String getName()
        {
            return this.name;
        }

        public Boolean GetHasFlag()
        {
            return this.hasFlag;
        }

        public void SetHasFlag(Boolean hasFlag)
        {
            this.hasFlag = hasFlag;
        }
        
    }
}
