using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stratego;

namespace GUI
{
    interface FrontEnd
    {

        void Start();

        void Update();

        void UpdateBoard(Stratego.Board board);

        void UpdatePlayer(Stratego.Piece.Team team);

        

    }
}
