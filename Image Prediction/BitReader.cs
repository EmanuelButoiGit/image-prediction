using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Prediction
{
    class BitReader
    {
        private FileStream stream;
        private byte buffer;
        private int contorBiti = 0;
        private BinaryReader binaryReader;

        public BitReader(string fileName)
        {
            this.stream = new FileStream(fileName, FileMode.OpenOrCreate);
            this.binaryReader = new BinaryReader(stream);
        }

        private bool IsBufferEmpty()
        {
            if (contorBiti == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private byte ReadBit()
        {
            byte result = 0;

            if (IsBufferEmpty())
            {
                buffer = binaryReader.ReadByte();
                contorBiti = 8;
            }

            result = (byte)(0x80 & buffer);
            result = (byte)(result >> 7);
            buffer = (byte)(buffer << 1);
            contorBiti--;

            return result;
        }

        public int ReadNBits(int NrDeBiti)
        {
            int result = 0;

            for (int i = 0; i < NrDeBiti; i++)
            {
                result = (int)result << 1;
                result = (int)result | ReadBit();
            }

            return result;
        }
    }
}
