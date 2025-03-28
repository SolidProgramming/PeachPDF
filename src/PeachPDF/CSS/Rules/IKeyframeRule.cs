﻿namespace PeachPDF.CSS
{
    public interface IKeyframeRule : IRule
    {
        string KeyText { get; set; }
        StyleDeclaration Style { get; }
        KeyframeSelector Key { get; set; }
    }
}