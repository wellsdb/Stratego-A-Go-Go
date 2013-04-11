using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Stratego
{
    public class Board
    {
        public int[,] board = new int[10,10];

        public Board()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((i == 2 | i == 3 | i == 6 | i == 7) & (j == 4 | j == 5))
                    {
                        board[i, j] = 20;
                    }
                    else
                    {
                        board[i, j] = 0;
                    }
                }
            }

        }



    }
}
