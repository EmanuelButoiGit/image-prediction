using System;
using System.IO;


namespace Image_Prediction
{
    class BitWriter : IDisposable
    {
        private FileStream stream;
        private byte buffer;
        private int contorBiti = 0;
        BinaryWriter binaryWriter;

        public BitWriter(string filename)
        {
            stream = new FileStream(filename, FileMode.OpenOrCreate);
            binaryWriter = new BinaryWriter(stream);
        }

        private bool IsBufferFull()
        {
            if(contorBiti == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public void WriteBit(int bit)
        {
            /*if (IsBufferFull())
            {
                stream.WriteByte(buffer);
                contorBiti = 0;
            }*/

            buffer = (byte)(buffer << 1);
            bit = bit & 0x01;
            buffer = (byte)(buffer | bit);
            contorBiti++;

            if (IsBufferFull())
            {
                
                    stream.WriteByte(buffer);
                    contorBiti = 0;
                
            }
        }

        public void WriteNBits(int biti, int NrDeBiti)
        {
            biti = biti << (32 - NrDeBiti);

            for(int i = 0; i < NrDeBiti; i++)
            {
                byte bit = (byte)((0x80000000 & biti) >> 31);
                WriteBit(bit);
                biti = biti << 1;
            }
        }

        private void CompleteazaBiti()
        {
            if(!IsBufferEmpty())
            {
                WriteNBits(0, 7);
            }
        }


        public void Dispose()
        {
            binaryWriter.Dispose();
        }
    }
}
