﻿#region PDFsharp - A .NET library for processing PDF
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

namespace PeachPDF.PdfSharpCore.Pdf.Internal
{
    class PdfDiagnostics
    {
        public static bool TraceCompressedObjects
        {
            get { return _traceCompressedObjects; }
            set { _traceCompressedObjects = value; }
        }
        static bool _traceCompressedObjects = true;

        public static bool TraceXrefStreams
        {
            get { return _traceXrefStreams && TraceCompressedObjects; }
            set { _traceXrefStreams = value; }
        }
        static bool _traceXrefStreams = true;

        public static bool TraceObjectStreams
        {
            get { return _traceObjectStreams && TraceCompressedObjects; }
            set { _traceObjectStreams = value; }
        }
        static bool _traceObjectStreams = true;
    }
}
