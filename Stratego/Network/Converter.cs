using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public static class NetworkConverter
    {
        static private readonly ASCIIEncoding encoder = new ASCIIEncoding();

        public static Byte[] StringToByte(String data)
        {
            return encoder.GetBytes(data);
        }

        public static String ByteToString(Byte[] data)
        {
            return encoder.GetString(data).Trim();
        }

        //Returns a string representation of a given move
        //TODO: test and complete MoveToString
        public static String MoveToString(Int16 oldV, Int16 oldH, Int16 newV, Int16 newH)
        {
            return oldV + "," + oldH + "," + newV + "," + newH + ",";
        }

        //Converts a string representation of a move into an array of values
        //TODO: test and complete StringToMove
        public static Int16[] StringToMove(String move)
        {
            String[] tempArray = move.Split(',');
            short[] moveArray = { Convert.ToInt16(tempArray[0]), Convert.ToInt16(tempArray[1]), Convert.ToInt16(tempArray[2]), Convert.ToInt16(tempArray[3]) };

            //String[] temp = move.ToArray<String>();
            //short[] moveArray = { (short)temp[0], (short)temp[2], (short)temp[4], (short)temp[6] };
            //Console.WriteLine("Move from string: " + moveArray[0] + "," + moveArray[1] + "," +moveArray[2] + "," +moveArray[3]);
            return moveArray;
        }

        //public Byte[] BoardToByte(String board)
        //{
        //    return null;
        //}

        //public String ByteToBoard(Byte[] data)
        //{
        //    return null;
        //}
    }
}
