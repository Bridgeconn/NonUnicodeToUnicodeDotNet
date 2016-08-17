using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonUnicodetoUnicodeTool
{
    public static class TtfFontFileInformationUtility
    {
        // STILL WORKING ON IT
        /*
            // TTF File information.
           var families = Fonts.GetFontFamilies(@"C:\WINDOWS\Fonts\mangal.TTF");
           foreach (FontFamily family in families)
           {
               var typefaces = family.GetTypefaces();
               foreach (Typeface typeface in typefaces)
               {
                   GlyphTypeface glyph;
                   typeface.TryGetGlyphTypeface(out glyph);
                   IDictionary<int, ushort> characterMap = glyph.CharacterToGlyphMap;

                   foreach (KeyValuePair<int, ushort> kvp in characterMap)
                   {
                       Console.WriteLine(String.Format("{0}:{1}", kvp.Key, kvp.Value));
                   }

               }
           }
           */

        /*
         *    GlyphTypeface ttf = new GlyphTypeface(new Uri(@"H:\WA\Scripts\Marathi NU - U\DV_ME_Shree0708.ttf"));

                      Console.WriteLine(ttf.Symbol); //True for unicode and false for non-unicode

                      //Console.WriteLine(ttf.Weight.ToString()); //=Bold or Normal

                      GlyphTypeface ttf2 = new GlyphTypeface(new Uri(@"H:\WA\Scripts\Marathi NU - U\MANGAL\MANGAL.ttf"));

                      Console.WriteLine(ttf2.Symbol); //True for unicode and false for non-unicode
                      */
    }
}
