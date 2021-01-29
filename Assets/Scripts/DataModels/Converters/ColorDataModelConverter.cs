using System;
using TrueColors.Core.Cards;
using TrueColors.Data;
using TrueColors.Util;

namespace TrueColors.Converters
{
    public class ColorDataModelConverter : IConverter<ColorDataModel, ICardColor>
    {
        public ICardColor Convert(ColorDataModel source)
        {
            return Activator.CreateInstance(source.type) as ICardColor;
        }
    }
}