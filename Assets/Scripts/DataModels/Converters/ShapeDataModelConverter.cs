using System;
using TrueColors.Core.Cards;
using TrueColors.Data;
using TrueColors.Util;

namespace TrueColors.Converters
{
    public class ShapeDataModelConverter : IConverter<ShapeDataModel, ICardShape>
    {
        public ICardShape Convert(ShapeDataModel source)
        {
            return Activator.CreateInstance(source.type) as ICardShape;
        }
    }
}