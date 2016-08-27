using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace NonUnicodetoUnicodeTool
{
    public static class TtfFontFileInformationUtility
    {
        public static void GetFontInformation(string fontFilePath)
        {
            // STILL WORKING ON IT

            // TTF File information.
            var families = Fonts.GetFontFamilies(fontFilePath);
            foreach (FontFamily family in families)
            {
                var typefaces = family.GetTypefaces();
                foreach (Typeface typeface in typefaces)
                {
                    GlyphTypeface glyph;
                    typeface.TryGetGlyphTypeface(out glyph);

                    // Check if the font conforms to Unicode
                    bool isUnicode = glyph.Symbol; 

                    IDictionary<int, ushort> characterMap = glyph.CharacterToGlyphMap;
                    foreach (KeyValuePair<int, ushort> kvp in characterMap)
                    {
                        Console.WriteLine(String.Format("{0}:{1}", kvp.Key, kvp.Value));
                    }

                }
            }
        }
    }
}
