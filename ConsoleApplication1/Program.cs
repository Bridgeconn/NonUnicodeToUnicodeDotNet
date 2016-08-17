using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace NonUnicodetoUnicodeTool
{
    class Program
    {

        static void Main(string[] args)
        {

            // TEST FILE

            string sourceFilePath = @"H:\WA\Scripts\Marathi NU - U\sampleNU-MT.txt";
            string targetFilePath = @"H:\WA\Scripts\Marathi NU - U\outnewMT.txt";

            if (NonUnicodeToUnicodeUtility.ConvertNonUnicodeToUnicode(1251, sourceFilePath, targetFilePath))
            {
                Console.WriteLine("Conversion is successful!");
            }
            else
            {
                Console.WriteLine("Conversion is failed!");
            }
            

            /*
             * 
             * 
             * string infilename = @"H:\WA\Scripts\Marathi NU - U\out.rtf";
            string outfilename = @"H:\WA\Scripts\Marathi NU - U\outrtf.txt";

             Console.Read();
            // 1251
            Encoding cp1251 = Encoding.GetEncoding(1251);
            string filename = @"H:\WA\Scripts\Marathi NU - U\sampleNU.txt";


                  byte[] newtext = Encoding.Convert(Encoding.GetEncoding(1251), Encoding.UTF32, Encoding.Unicode.GetBytes(new StreamReader(filename).ReadLine()));
                  Console.WriteLine(.GetString(newtext));
                  Console.Read();
                 
                  //string infilename = @"H:\WA\Scripts\Marathi NU - U\First Principles Marathi Book.rtf";
                  //string outfilename = @"H:\WA\Scripts\Marathi NU - U\outlonglong.rtf";

            string infilename = @"H:\WA\Scripts\Marathi NU - U\out.rtf";
            string outfilename = @"H:\WA\Scripts\Marathi NU - U\outrtf.txt";

            string path = @"test.rtf";

            


            // load as charset 1251
           // string text = File.ReadAllText(infilename, Encoding.GetEncoding(1251));

            // save as Unicode
            //File.WriteAllText(outfilename, text, Encoding.Unicode);

            //byte[] bytes1251 = Encoding.GetEncoding(1251).GetBytes(File.ReadAllText(infilename));
            //String str = Encoding.UTF8.GetString(bytes1251);
            //System.IO.File.WriteAllText(outfilename, str, Encoding.Unicode);

            /*
                      string str = new StreamReader(filename).ReadLine();
                      Byte[] bytes = cp1251.GetBytes(str);
                      Console.Write("Encoded bytes: ");
                      foreach (byte byt in bytes)
                          Console.Write("{0:X2} ", byt);
                      Console.WriteLine("\n");

                      // Decode the string.
                      string str2 = cp1251.GetString(bytes);
                      Console.WriteLine("String round-tripped: {0}", str.Equals(str2));
                      if (!str.Equals(str2))
                      {
                          Console.WriteLine(str2);
                          foreach (var ch in str2)
                              Console.Write("{0} ", Convert.ToUInt16(ch).ToString("X4"));
                      }

                   
          */
            Console.Read();
        }
    }
}
