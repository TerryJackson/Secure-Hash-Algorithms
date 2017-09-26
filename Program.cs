using System;
using SecureHashAlgorithms;
using BlockChain;

class Program
{
    static void Main(string[] args)
    {
        
        //Block b = new BlockChain.Block(1, 0, "abc", null, null);
        //Console.WriteLine("Is block signed? " + b.IsBlockSigned());

        //b.Mine();
        //Console.WriteLine("Is block signed? " + b.IsBlockSigned());
        //Console.WriteLine("Hash:" + b.HashToHexString());
        //Console.WriteLine("Nonce:" + b.GetNonce());
        //byte[] hash = Sha.Sha256(b.GetBlockBytes());
        //b.SetHash(hash);
       

        string message = "abc";
        Console.WriteLine("Input message:");
        Console.WriteLine(message);
        Console.WriteLine();

        // Sha1
        Console.WriteLine("Sha1");
        Console.WriteLine(Sha.Sha1HexString(message));
        Console.WriteLine();

        // Sha224
        Console.WriteLine("Sha224");
        Console.WriteLine(Sha.Sha224HexString(message));
        Console.WriteLine();

        // Sha256
        Console.WriteLine("Sha256");
        Console.WriteLine(Sha.Sha256HexString(message));
        Console.WriteLine();

        // Sha384
        Console.WriteLine("Sha384");
        Console.WriteLine(Sha.Sha384HexString(message));
        Console.WriteLine();

        // Sha512
        Console.WriteLine("Sha512");
        Console.WriteLine(Sha.Sha512HexString(message));
        Console.WriteLine();

        // Sha512_224
        Console.WriteLine("Sha512_224");
        Console.WriteLine(Sha.Sha512_224HexString(message));
        Console.WriteLine();

        // Sha512_256
        Console.WriteLine("Sha512_256"); 
        Console.WriteLine(Sha.Sha512_256HexString(message));
        Console.WriteLine();


        Console.ReadKey();
        //---------------------------------------------------------

        // Three ways to represent the same byte. Base 16, base 2, base 10.
        //byte a = 0x80;
        //byte b = Convert.ToByte("10000000", 2);
        //byte c = 128;

        //Console.WriteLine(a);
        //Console.WriteLine(b);
        //Console.WriteLine(c);

        //---------------------------------------------------------

        //B = new byte[] {0x61, 0x62, 0x63, 0x80 };
        //UInt32[] x = Converter.ByteArrayToUInt32Array(B);

        //Console.WriteLine(x[0]);
        //---------------------------------------------------------

        //byte[] b = Converter.StringToByteArray("abc");

        //---------------------------------------------------------

        //uint uintValue1 = 3000000000;
        //Console.WriteLine(uintValue1);

        //uint uintValue2 = 0xB2D05E00;
        //Console.WriteLine(uintValue2);

        //uint uintValue3 = 0b1011_0010_1101_0000_0101_1110_0000_0000;
        //Console.WriteLine(uintValue3);
        // The example displays the following output:
        //          3000000000
        //          3000000000
        //          3000000000

        //Console.WriteLine(10 & 14);

        //uint n = 3000000000;
        //Console.WriteLine(ToBinaryString(n & (15 << 8)));

        //Console.WriteLine(n.ToString("X"));
        //Console.WriteLine(ToHexString(n));

        //uint m = 45;
        //Console.WriteLine(~m);

        //---------------------------------------------------------

        ////Console.WriteLine(Sha256.Maj(1779033703, 3144134277, 1013904242));
        //Console.WriteLine(Sha256.Ch(1359893119, 2600822924 , 528734635));

        //int p = 307;
        //double x = Math.Pow(p, 1d / 3);
        //x = x - Math.Floor(x);
        //x = x * Math.Pow(2, 32);
        //uint result = (uint)x;
        //Console.WriteLine(result);


        //Console.WriteLine(Sha256.Sigma0(Sha256.H0));

        // shows mistake on video where it gives 1f86c98c but really is 1f85c98c
        //Console.WriteLine(Sha256.Ch(Sha256.H4, Sha256.H5, Sha256.H6));

        //Console.WriteLine(Sha256.Sigma1(Sha256.H4));


        //string input = "Hello world";
        //string s = StringToHex(input);
        //s = HexToString(s);
        //Console.WriteLine(s);
    }

}


    

    

    



