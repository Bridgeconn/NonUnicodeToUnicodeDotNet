using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}

/*
    TEST CASE: NEED TO MOVE!!
    
    // FOR TEST: Create a file that contains the Greek work ψυχή (psyche) when interpreted by using 
    code page 737 ((DOS) Greek). You can also create the file by using Character Map 
    to paste the characters into Microsoft Word and then "Save As" by using the DOS
    (Greek) encoding. (Word will actually create a six-byte file by appending "\r\n" at the end.)
    System.IO.File.WriteAllBytes(nonUnicodeTxtFilePath, new byte[] { 0xAF, 0xAC, 0xAE, 0x9E });
    
    The word 'red' in Marathi
    System.IO.File.WriteAllBytes(nonUnicodeTxtFilePath, new byte[] { 0x72, 0x65, 0x64 });

    // Show that the text content is still intact in Unicode string
    // (Add a reference to System.Windows.Forms.dll)
    //System.Windows.Forms.MessageBox.Show(unicodeValues);

    // Same content "ψυχή" is stored as UTF-8
     */
