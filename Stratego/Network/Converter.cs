using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stratego;

namespace Network
{
    public class Converter
    {
        ASCIIEncoding encoder = new ASCIIEncoding();
        public Converter()
        { }

        public Byte[] StringToByte(String data)
        {
            return encoder.GetBytes(data);
        }

        public String ByteToString(Byte[] data)
        {
            return encoder.GetString(data);
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
