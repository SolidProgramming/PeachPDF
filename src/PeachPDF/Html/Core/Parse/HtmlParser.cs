﻿// "Therefore those skilled at the unorthodox
// are infinite as heaven and earth,
// inexhaustible as the great rivers.
// When they come to an end,
// they begin again,
// like the days and months;
// they die and are reborn,
// like the four seasons."
// 
// - Sun Tsu,
// "The Art of War"

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MimeKit.Text;
using PeachPDF.Html.Core.Dom;
using PeachPDF.Html.Core.Utils;
using HtmlUtils = PeachPDF.Html.Core.Utils.HtmlUtils;

namespace PeachPDF.Html.Core.Parse
{
    /// <summary>
    /// 
    /// </summary>
    internal static class HtmlParser
    {
        /// <summary>
        /// Parses the source html to css boxes tree structure.
        /// </summary>
        /// <param name="source">the html source to parse</param>
        /// <param name="root">the root box (null for document root)</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CssBox ParseDocument(string source, CssBox? root = null)
        {
            root ??= CssBox.CreateBlock();
            var curBox = root;

            using var sourceReader = new StringReader(source);
            var tokenizer = new HtmlTokenizer(sourceReader);

            while (tokenizer.ReadNextToken(out var token))
            {
                switch (token.Kind)
                {
                    case HtmlTokenKind.Tag:
                    {
                        var tag = (HtmlTagToken)token;
                        ParseHtmlTag(tag, ref curBox);
                        break;
                    }
                    case HtmlTokenKind.Data:
                    {
                        var text = (HtmlDataToken)token;

                        if (curBox.HtmlTag?.Name is HtmlConstants.NoScript)
                        {
                            curBox = ParseDocument(text.Data, curBox.ParentBox);
                        }
                        else
                        {
                            AddTextBox(text, ref curBox);
                        }

                        break;

                    }
                    case HtmlTokenKind.CData:
                    case HtmlTokenKind.Comment:
                    case HtmlTokenKind.DocType:
                    case HtmlTokenKind.ScriptData:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return root;
        }


        #region Private methods

        /// <summary>
        /// Add html text anon box to the current box, this box will have the rendered text<br/>
        /// Adding box also for text that contains only whitespaces because we don't know yet if
        /// the box is preformatted. At later stage they will be removed if not relevant.
        /// </summary>
        /// <param name="token">the html token to parse</param>
        /// <param name="curBox">the current box in html tree parsing</param>
        private static void AddTextBox(HtmlDataToken token, ref CssBox curBox)
        {
            var text = token.Data;

            if (text == null) return;

            var box = CssBox.CreateBox(curBox);
            box.Text = text;
        }


        /// <summary>
        /// Parse the html part, the part from prev parsing index to the beginning of the next html tag.<br/>
        /// </summary>
        /// <param name="token">the html tag token</param>
        /// <param name="curBox">the current box in html tree parsing</param>
        /// <returns>the end of the parsed part, the new start index</returns>
        private static void ParseHtmlTag(HtmlTagToken token, ref CssBox curBox)
        {
            if (ParseHtmlTag(token, out var tagName, out var tagAttributes))
            {
                if (!HtmlUtils.IsSingleTag(tagName) && curBox.ParentBox != null)
                {
                    // need to find the parent tag to go one level up
                    curBox = DomUtils.FindParent(curBox.ParentBox, tagName, curBox);
                }
            }
            else if (!string.IsNullOrEmpty(tagName))
            {
                // Close <p> tags per https://html.spec.whatwg.org/dev/grouping-content.html#the-p-element
                if (curBox.HtmlTag?.Name is "p")
                {
                    if (HtmlUtils.ShouldTagCloseParagraph(tagName))
                    {
                        curBox = DomUtils.FindParent(curBox.ParentBox, tagName, curBox);
                    }
                }

                var isSingle = HtmlUtils.IsSingleTag(tagName) || token.IsEmptyElement;
                var tag = new HtmlTag(tagName, isSingle, tagAttributes);

                if (isSingle)
                {
                    // the current box is not changed
                    CssBox.CreateBox(tag, curBox);
                }
                else
                {
                    // go one level down, make the new box the current box
                    curBox = CssBox.CreateBox(tag, curBox);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        private static bool ParseHtmlTag(HtmlTagToken token, out string name, out Dictionary<string, string> attributes)
        {
            var isClosing = token.IsEndTag;

            name = token.Name.ToLowerInvariant();

            attributes = null;

            if (!isClosing)
            {
                attributes = token.Attributes
                    .GroupBy(x => x.Name)
                    .ToDictionary(x => x.Key, x => x.First().Value);
            }

            return isClosing;
        }

        #endregion
    }
}