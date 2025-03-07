﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable UnusedMember.Global

namespace PeachPDF.CSS
{
    public static class TextEncoding
    {
        public static HashSet<string> AvailableEncodings = new(from encoding in Encoding.GetEncodings()
            select encoding.Name);

        public static readonly Encoding Utf8 = new UTF8Encoding(false);
        public static readonly Encoding Utf16Be = new UnicodeEncoding(true, false);
        public static readonly Encoding Utf16Le = new UnicodeEncoding(false, false);
        public static readonly Encoding Utf32Le = GetEncoding("UTF-32LE");
        public static readonly Encoding Utf32Be = GetEncoding("UTF-32BE");
        public static readonly Encoding Gb18030 = GetEncoding("GB18030");
        public static readonly Encoding Big5 = GetEncoding("big5");
        public static readonly Encoding Windows874 = GetEncoding("windows-874");
        public static readonly Encoding Windows1250 = GetEncoding("windows-1250");
        public static readonly Encoding Windows1251 = GetEncoding("windows-1251");
        public static readonly Encoding Windows1252 = GetEncoding("windows-1252");
        public static readonly Encoding Windows1253 = GetEncoding("windows-1253");
        public static readonly Encoding Windows1254 = GetEncoding("windows-1254");
        public static readonly Encoding Windows1255 = GetEncoding("windows-1255");
        public static readonly Encoding Windows1256 = GetEncoding("windows-1256");
        public static readonly Encoding Windows1257 = GetEncoding("windows-1257");
        public static readonly Encoding Windows1258 = GetEncoding("windows-1258");
        public static readonly Encoding Latin2 = GetEncoding("iso-8859-2");
        public static readonly Encoding Latin3 = GetEncoding("iso-8859-3");
        public static readonly Encoding Latin4 = GetEncoding("iso-8859-4");
        public static readonly Encoding Latin5 = GetEncoding("iso-8859-5");
        public static readonly Encoding Latin13 = GetEncoding("iso-8859-13");
        public static readonly Encoding UsAscii = GetEncoding("us-ascii");
        public static readonly Encoding Korean = GetEncoding("ks_c_5601-1987");
        private static readonly Dictionary<string, Encoding> Encodings = CreateEncodings();

        public static bool IsUnicode(this Encoding encoding)
        {
            return encoding == Utf16Be || encoding == Utf16Le;
        }

        public static bool IsSupported(string charset)
        {
            return Encodings.ContainsKey(charset);
        }

        public static Encoding Resolve(string charset)
        {
            if (charset != null && Encodings.TryGetValue(charset, out var encoding)) return encoding;

            return Utf8;
        }

        private static Encoding GetEncoding(string name)
        {
            try
            {
                if (AvailableEncodings.Contains(name)) return Encoding.GetEncoding(name);
            }
            catch
            {
            }


            // Catch all since WP8 does throw a different exception than W*.
            return Utf8;
        }

        private static Dictionary<string, Encoding> CreateEncodings()
        {
            var encodings = new Dictionary<string, Encoding>(StringComparer.OrdinalIgnoreCase)
            {
                {"unicode-1-1-utf-8", Utf8},
                {"utf-8", Utf8},
                {"utf8", Utf8},
                {"utf-16be", Utf16Be},
                {"utf-16", Utf16Le},
                {"utf-16le", Utf16Le},
                {"dos-874", Windows874},
                {"iso-8859-11", Windows874},
                {"iso8859-11", Windows874},
                {"iso885911", Windows874},
                {"tis-620", Windows874},
                {"windows-874", Windows874},
                {"cp1250", Windows1250},
                {"windows-1250", Windows1250},
                {"x-cp1250", Windows1250},
                {"cp1251", Windows1251},
                {"windows-1251", Windows1251},
                {"x-cp1251", Windows1251},
                {"x-user-defined", Windows1252},
                {"ansi_x3.4-1968", Windows1252},
                {"ascii", Windows1252},
                {"cp1252", Windows1252},
                {"cp819", Windows1252},
                {"csisolatin1", Windows1252},
                {"ibm819", Windows1252},
                {"iso-8859-1", Windows1252},
                {"iso-ir-100", Windows1252},
                {"iso8859-1", Windows1252},
                {"iso88591", Windows1252},
                {"iso_8859-1", Windows1252},
                {"iso_8859-1:1987", Windows1252},
                {"l1", Windows1252},
                {"latin1", Windows1252},
                {"us-ascii", Windows1252},
                {"windows-1252", Windows1252},
                {"x-cp1252", Windows1252},
                {"cp1253", Windows1253},
                {"windows-1253", Windows1253},
                {"x-cp1253", Windows1253},
                {"cp1254", Windows1254},
                {"csisolatin5", Windows1254},
                {"iso-8859-9", Windows1254},
                {"iso-ir-148", Windows1254},
                {"iso8859-9", Windows1254},
                {"iso88599", Windows1254},
                {"iso_8859-9", Windows1254},
                {"iso_8859-9:1989", Windows1254},
                {"l5", Windows1254},
                {"latin5", Windows1254},
                {"windows-1254", Windows1254},
                {"x-cp1254", Windows1254},
                {"cp1255", Windows1255},
                {"windows-1255", Windows1255},
                {"x-cp1255", Windows1255},
                {"cp1256", Windows1256},
                {"windows-1256", Windows1256},
                {"x-cp1256", Windows1256},
                {"cp1257", Windows1257},
                {"windows-1257", Windows1257},
                {"x-cp1257", Windows1257},
                {"cp1258", Windows1258},
                {"windows-1258", Windows1258},
                {"x-cp1258", Windows1258}
            };

            var macintosh = GetEncoding("macintosh");
            encodings.Add("csmacintosh", macintosh);
            encodings.Add("mac", macintosh);
            encodings.Add("macintosh", macintosh);
            encodings.Add("x-mac-roman", macintosh);

            var maccyrillic = GetEncoding("x-mac-cyrillic");

            encodings.Add("x-mac-cyrillic", maccyrillic);
            encodings.Add("x-mac-ukrainian", maccyrillic);

            var i866 = GetEncoding("cp866");
            encodings.Add("866", i866);
            encodings.Add("cp866", i866);
            encodings.Add("csibm866", i866);
            encodings.Add("ibm866", i866);

            encodings.Add("csisolatin2", Latin2);
            encodings.Add("iso-8859-2", Latin2);
            encodings.Add("iso-ir-101", Latin2);
            encodings.Add("iso8859-2", Latin2);
            encodings.Add("iso88592", Latin2);
            encodings.Add("iso_8859-2", Latin2);
            encodings.Add("iso_8859-2:1987", Latin2);
            encodings.Add("l2", Latin2);
            encodings.Add("latin2", Latin2);

            encodings.Add("csisolatin3", Latin3);
            encodings.Add("iso-8859-3", Latin3);
            encodings.Add("iso-ir-109", Latin3);
            encodings.Add("iso8859-3", Latin3);
            encodings.Add("iso88593", Latin3);
            encodings.Add("iso_8859-3", Latin3);
            encodings.Add("iso_8859-3:1988", Latin3);
            encodings.Add("l3", Latin3);
            encodings.Add("latin3", Latin3);

            encodings.Add("csisolatin4", Latin4);
            encodings.Add("iso-8859-4", Latin4);
            encodings.Add("iso-ir-110", Latin4);
            encodings.Add("iso8859-4", Latin4);
            encodings.Add("iso88594", Latin4);
            encodings.Add("iso_8859-4", Latin4);
            encodings.Add("iso_8859-4:1988", Latin4);
            encodings.Add("l4", Latin4);
            encodings.Add("latin4", Latin4);

            encodings.Add("csisolatincyrillic", Latin5);
            encodings.Add("cyrillic", Latin5);
            encodings.Add("iso-8859-5", Latin5);
            encodings.Add("iso-ir-144", Latin5);
            encodings.Add("iso8859-5", Latin5);
            encodings.Add("iso88595", Latin5);
            encodings.Add("iso_8859-5", Latin5);
            encodings.Add("iso_8859-5:1988", Latin5);

            var latin6 = GetEncoding("iso-8859-6");
            encodings.Add("arabic", latin6);
            encodings.Add("asmo-708", latin6);
            encodings.Add("csiso88596e", latin6);
            encodings.Add("csiso88596i", latin6);
            encodings.Add("csisolatinarabic", latin6);
            encodings.Add("ecma-114", latin6);
            encodings.Add("iso-8859-6", latin6);
            encodings.Add("iso-8859-6-e", latin6);
            encodings.Add("iso-8859-6-i", latin6);
            encodings.Add("iso-ir-127", latin6);
            encodings.Add("iso8859-6", latin6);
            encodings.Add("iso88596", latin6);
            encodings.Add("iso_8859-6", latin6);
            encodings.Add("iso_8859-6:1987", latin6);

            var latin7 = GetEncoding("iso-8859-7");
            encodings.Add("csisolatingreek", latin7);
            encodings.Add("ecma-118", latin7);
            encodings.Add("elot_928", latin7);
            encodings.Add("greek", latin7);
            encodings.Add("greek8", latin7);
            encodings.Add("iso-8859-7", latin7);
            encodings.Add("iso-ir-126", latin7);
            encodings.Add("iso8859-7", latin7);
            encodings.Add("iso88597", latin7);
            encodings.Add("iso_8859-7", latin7);
            encodings.Add("iso_8859-7:1987", latin7);
            encodings.Add("sun_eu_greek", latin7);

            var latin8 = GetEncoding("iso-8859-8");
            encodings.Add("csiso88598e", latin8);
            encodings.Add("csisolatinhebrew", latin8);
            encodings.Add("hebrew", latin8);
            encodings.Add("iso-8859-8", latin8);
            encodings.Add("iso-8859-8-e", latin8);
            encodings.Add("iso-ir-138", latin8);
            encodings.Add("iso8859-8", latin8);
            encodings.Add("iso88598", latin8);
            encodings.Add("iso_8859-8", latin8);
            encodings.Add("iso_8859-8:1988", latin8);
            encodings.Add("visual", latin8);

            var latini = GetEncoding("iso-8859-8-i");
            encodings.Add("csiso88598i", latini);
            encodings.Add("iso-8859-8-i", latini);
            encodings.Add("logical", latini);

            var latin13 = GetEncoding("iso-8859-13");
            encodings.Add("iso-8859-13", latin13);
            encodings.Add("iso8859-13", latin13);
            encodings.Add("iso885913", latin13);

            var latin15 = GetEncoding("iso-8859-15");
            encodings.Add("csisolatin9", latin15);
            encodings.Add("iso-8859-15", latin15);
            encodings.Add("iso8859-15", latin15);
            encodings.Add("iso885915", latin15);
            encodings.Add("iso_8859-15", latin15);
            encodings.Add("l9", latin15);

            var kr = GetEncoding("koi8-r");
            encodings.Add("cskoi8r", kr);
            encodings.Add("koi", kr);
            encodings.Add("koi8", kr);
            encodings.Add("koi8-r", kr);
            encodings.Add("koi8_r", kr);
            encodings.Add("koi8-u", GetEncoding("koi8-u"));

            var chinese = GetEncoding("x-cp20936");
            encodings.Add("chinese", chinese);
            encodings.Add("csgb2312", chinese);
            encodings.Add("csiso58gb231280", chinese);
            encodings.Add("gb2312", chinese);
            encodings.Add("gb_2312", chinese);
            encodings.Add("gb_2312-80", chinese);
            encodings.Add("gbk", chinese);
            encodings.Add("iso-ir-58", chinese);
            encodings.Add("x-gbk", chinese);
            encodings.Add("hz-gb-2312", GetEncoding("hz-gb-2312"));
            encodings.Add("gb18030", Gb18030);

            encodings.Add("big5", Big5);
            encodings.Add("big5-hkscs", Big5);
            encodings.Add("cn-big5", Big5);
            encodings.Add("csbig5", Big5);
            encodings.Add("x-x-big5", Big5);

            var isojp = GetEncoding("iso-2022-jp");
            encodings.Add("csiso2022jp", isojp);
            encodings.Add("iso-2022-jp", isojp);

            var isokr = GetEncoding("iso-2022-kr");
            encodings.Add("csiso2022kr", isokr);
            encodings.Add("iso-2022-kr", isokr);

            var isocn = GetEncoding("iso-2022-cn");
            encodings.Add("iso-2022-cn", isocn);
            encodings.Add("iso-2022-cn-ext", isocn);
            encodings.Add("shift_jis", GetEncoding("shift_jis"));

            var eucjp = GetEncoding("euc-jp");
            encodings.Add("euc-jp", eucjp);

            return encodings;
        }
    }
}