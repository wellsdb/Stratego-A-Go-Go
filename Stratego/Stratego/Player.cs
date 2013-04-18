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

        public Player()
        {
            this.pieceCount = DEFAULT_PIECECOUNT;
            this.name = DEFAULT_NAME;
        }

        public Player(String name)
        {
            this.pieceCount = DEFAULT_PIECECOUNT;
            this.name = name;
        }

        public Player(Int16 pieceCount, String name)
        {
            this.pieceCount = pieceCount;
            this.name = name;
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
        
    }
}
