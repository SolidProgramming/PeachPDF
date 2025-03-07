﻿namespace PeachPDF.CSS
{
    internal sealed class FlexFlowProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = Converters.FlexFlowConverter;

        internal FlexFlowProperty()
            : base(PropertyNames.FlexFlow)
        { }

        internal override IValueConverter Converter => StyleConverter;
    }
}
