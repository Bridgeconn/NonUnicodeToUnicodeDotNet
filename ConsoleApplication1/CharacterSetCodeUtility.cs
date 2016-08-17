using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    // Helps to get the CharacterSetCode
    public static class CharacterSetCodeUtility
    {
        public static string GetCharacterSetCode(string filePath)
        {
            using (FileStream fs = File.OpenRead(filePath))
            {
                Ude.CharsetDetector cdet = new Ude.CharsetDetector();
                cdet.Feed(fs);
                cdet.DataEnd();
                if (cdet.Charset != null)
                {
                    //Console.WriteLine("Charset: {0}, confidence: {1}", cdet.Charset, cdet.Confidence);
                    return cdet.Charset;
                }
                else
                {
                    //Console.WriteLine("Detection failed.");

                }
            }

            return string.Empty;
        }
    }
}
