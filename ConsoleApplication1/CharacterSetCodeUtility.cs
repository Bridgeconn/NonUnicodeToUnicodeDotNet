using System.IO;

namespace NonUnicodetoUnicodeTool
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
                    // cdet.Confidence provides us the confidence factor
                    return cdet.Charset;
                }
                else
                {
                    return "Detection failed.";
                }
            }
        }
    }
}
