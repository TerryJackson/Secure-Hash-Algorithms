using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureHashAlgorithms
{
    using Word32 = System.UInt32;
    using Word64 = System.UInt64;

    public class ShaUtil
    {

        #region Functions to convert between byte arrays and Word32 arrays, and Word64 arrays.

        public static bool ByteArraysEqual(byte[] B1, byte[] B2)
        {
            if ((B1 == null) && (B2 == null))
                return true;

            if ((B1 == null) || (B2 == null))
                return false;

            if (B1.Length != B2.Length)
                return false;

            for (int i = 0; i < B1.Length; i++)
            {
                if (B1[i] != B2[i])
                    return false;
            }

            return true;
        }


        public static byte[] StringToByteArray(string message)
        {
            char[] c = message.ToCharArray();
            int numberBytes = message.Length;
            byte[] b = new byte[numberBytes];

            for (int i = 0; i < numberBytes; i++)
            {
                b[i] = Convert.ToByte(c[i]);
            }

            return b;
        }

        // Returns an array of 4 bytes.
        public static byte[] Word32ToByteArray(Word32 x)
        {
            byte[] b = BitConverter.GetBytes(x);
            Array.Reverse(b);
            return b;
        }

        // Returns an array of 8 bytes.
        public static byte[] Word64ToByteArray(Word64 x)
        {
            byte[] b = BitConverter.GetBytes(x);
            Array.Reverse(b);
            return b;
        }

        public static byte[] Word32ArrayToByteArray(Word32[] words)
        {
            List<byte> b = new List<byte>();

            for (int i = 0; i < words.Length; i++)
            {
                b.AddRange(Word32ToByteArray(words[i]));
            }

            return b.ToArray();
        }


        public static byte[] Word32ArrayToByteArray(Word32[] words, int startIndex, int numberWords)
        {
            // This overload is useful in Sha224 
            // assume 0 <= startIndex < words.Length and startIndex + numberWords <= words.Length

            List<byte> b = new List<byte>();

            for (int i = startIndex; i < startIndex + numberWords; i++)
            {
                b.AddRange(Word32ToByteArray(words[i]));
            }

            return b.ToArray();
        }



        public static byte[] Word64ArrayToByteArray(Word64[] words)
        {
            List<byte> b = new List<byte>();

            for (int i = 0; i < words.Length; i++)
            {
                b.AddRange(Word64ToByteArray(words[i]));
            }

            return b.ToArray();
        }

        public static Word32 ByteArrayToWord32(byte[] B, int startIndex)
        {
            // We assume: 0 <= startIndex < B. Length, and startIndex + 4 <= B.Length

            Word32 c = 256;
            Word32 output = 0;

            for (int i = startIndex; i < startIndex + 4; i++)
            {
                output = output * c + (Word32)B[i];
            }

            return output;
        }


        public static Word64 ByteArrayToWord64(byte[] B, int startIndex)
        {
            // We assume: 0 <= startIndex < B. Length, and startIndex + 8 <= B.Length

            Word64 c = 256;
            Word64 output = 0;

            for (int i = startIndex; i < startIndex + 8; i++)
            {
                output = output * c + B[i];
            }

            return output;
        }


        public static Word32[] ByteArrayToWord32Array(byte[] B)
        {
            // We assume B is not null, is not empty and number elements is divisible by 4

            int numberBytes = B.Length;
            int n = numberBytes / 4; // 4 bytes for each Word32
            Word32[] wordArray = new Word32[n];

            for (int i = 0; i < n; i++)
            {
                wordArray[i] = ByteArrayToWord32(B, 4 * i);
            }

            return wordArray;
        }


        public static Word64[] ByteArrayToWord64Array(byte[] B)
        {
            // We assume B is not null, is not empty and number elements is divisible by 8
            int numberWords = B.Length / 8; // 8 bytes for each Word32
            Word64[] wordArray = new Word64[numberWords];

            for (int i = 0; i < numberWords; i++)
            {
                wordArray[i] = ByteArrayToWord64(B, 8 * i);
            }

            return wordArray;
        }

        #endregion


        #region To string methods

        public static string ByteToBinaryString(byte b)
        {
            string binaryString = Convert.ToString(b, 2).PadLeft(8, '0');
            return binaryString.Substring(0, 4) + "_" + binaryString.Substring(4, 4);
        }


        public static string ByteArrayToBinaryString(byte[] x)
        {
            string binaryString = "";

            for (int i = 0; i < x.Length; i++)
            {
                binaryString += ByteToBinaryString(x[i]);

                if (i < x.Length - 1)
                {
                    binaryString += "  ";
                }
            }

            return binaryString;
        }


        public static string ByteToHexString(byte b)
        {
            return Convert.ToString(b, 16).PadLeft(2, '0');
        }

        public static string ByteArrayToHexString(byte[] a)
        {
            string hexString = "";

            for (int i = 0; i < a.Length; i++)
            {
                hexString += ByteToHexString(a[i]);
            }

            return hexString;
        }


        public static string Word32ToBinaryString(Word32 x)
        {
            return ByteArrayToBinaryString(Word32ToByteArray(x));
        }


        public static string Word32ToHexString(Word32 x)
        {
            return ByteArrayToHexString(Word32ToByteArray(x));
        }

        public static string Word64ToHexString(Word64 x)
        {
            return ByteArrayToHexString(Word64ToByteArray(x));
        }

        public static string ByteArrayToString(byte[] X)
        {
            if (X == null)
            {
                Console.WriteLine("ERROR: The byte array is null");
                return null;
            }

            string s = "";

            for (int i = 0; i < X.Length; i++)
            {
                s += (char)X[i];
            }

            return s;
        }


        /*
        static string ToHexString(uint n)
        {
            // using a C# built in feature:
            // return n.ToString("x");
            // return n.ToString()
            // or from scratch:
            char[] b = new char[8];

            for (int i = 0; i < 8; i++)
            {
                long m = (n & (0xf << (4 * i))) >> (4 * i);
                int j = 8 - i - 1;

            }
            //return new string(b);

            return "";
        }
        */

        #endregion

    }
}
