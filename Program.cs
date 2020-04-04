using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHA
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello World!";

            Console.WriteLine("Sha1");
            Console.WriteLine(Sha.Sha1(s) + "\n");

            Console.WriteLine("Sha224");
            Console.WriteLine(Sha.Sha224(s) + "\n");

            Console.WriteLine("Sha256");
            Console.WriteLine(Sha.Sha256(s) + "\n");

            Console.WriteLine("Sha384");
            Console.WriteLine(Sha.Sha384(s) + "\n");

            Console.WriteLine("Sha512");
            Console.WriteLine(Sha.Sha512(s) + "\n");

            Console.WriteLine("Sha512_224");
            Console.WriteLine(Sha.Sha512_224(s) + "\n");

            Console.WriteLine("Sha512_256");
            Console.WriteLine(Sha.Sha512_256(s) + "\n");
        }
    }
}
