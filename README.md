# NonUnicodeToUnicodeDotNet

# The issue!
Text documents that were created long ago were stored in font dependent glyph codes hence those fonts are known as legacy fonts. These texts are no longer compliant with the modern fonts as there is a unified character encoding standard named as UNICODE that they are compliant with. Hence, there is a great need for the conversion of NON-UNICODE text documents to UNICODE standards.

# Legacy Font:
The Texts were stored in font dependent glyph codes hence those fonts are known as legacy fonts. The glyph coding schemes for these fonts is typically different for every legacy font.

# Legacy Font to Unicode Conversion:
Each Legacy Font’s glyph codes need to be converted to UNICODE in order to be able to use them with modern fonts and carry out various other operations on them.

# Approach:
SIL's conversion platform has been used.

# Prerequisite: .NET Platform

Linux: http://www.mono-project.com/docs/getting-started/install/linux/

Mac: http://www.mono-project.com/docs/getting-started/install/mac/

# Integrated development environment

Visual Studio Community Edition: https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx


# Installation of the conversion tool

- Console application's directory needs to be copied on the target machine.

# Tool usage steps

- Console application's directory has the NU2U.exe that could be executed on the console application with the below arguments:


