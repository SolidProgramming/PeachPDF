#region PDFsharp - A .NET library for processing PDF
//
// Authors:
//   Stefan Lange
//
// Copyright (c) 2005-2016 empira Software GmbH, Cologne Area (Germany)
//
// http://www.PeachPDF.PdfSharpCore.com
// http://sourceforge.net/projects/pdfsharp
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using System.Diagnostics;
using System.IO;

namespace PeachPDF.PdfSharpCore.Fonts.OpenType
{
    /// <summary>
    /// Represents a writer for True Type font files. 
    /// </summary>
    internal class OpenTypeFontWriter : FontWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenTypeFontWriter"/> class.
        /// </summary>
        public OpenTypeFontWriter(Stream stream)
            : base(stream)
        { }

        /// <summary>
        /// Writes a table name.
        /// </summary>
        public void WriteTag(string tag)
        {
            Debug.Assert(tag.Length == 4);
            WriteByte((byte)(tag[0]));
            WriteByte((byte)(tag[1]));
            WriteByte((byte)(tag[2]));
            WriteByte((byte)(tag[3]));
        }
    }
}
