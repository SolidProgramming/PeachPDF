﻿namespace PeachPDF.CSS
{
    public interface IMarginRule : IRule
    {
        string Name { get; }
        StyleDeclaration Style { get; }
    }
}