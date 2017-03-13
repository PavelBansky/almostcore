using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var hash = MD5.Create();  
            byte[] data = hash.ComputerHas(Encoding.UTF8.GetBytes("hello world"));
            
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i].ToString("x2"));
            }            
        }
    }
}
