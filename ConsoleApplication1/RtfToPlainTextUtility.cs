using System;

namespace NonUnicodetoUnicodeTool
{
    public static class RtfToPlainTextUtility
    {
        public static bool ConvertRtfToPlainText(string rtfFilePath, string txtFilePath)
        {
            bool isSuccesfull;
            try
            {
                //Create the RichTextBox. (Requires a reference to System.Windows.Forms.dll.)
                System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();

                // Get the contents of the RTF file. Note that when it is
                // stored in the string, it is encoded as UTF-16.
                string s = System.IO.File.ReadAllText(rtfFilePath);

                // Display the RTF text.
                //System.Windows.Forms.MessageBox.Show(s);

                // Convert the RTF to plain text.
                rtBox.Rtf = s;
                string plainText = rtBox.Text;

                // Display plain text output in MessageBox because console
                // cannot display Greek letters.
                //System.Windows.Forms.MessageBox.Show(plainText);

                // Output plain text to file, encoded as UTF-8.
                System.IO.File.WriteAllText(txtFilePath, plainText);

                isSuccesfull = true;
            }
            catch (Exception exception)
            {
                isSuccesfull = false;
            }

            return isSuccesfull;
        }
    }
}
