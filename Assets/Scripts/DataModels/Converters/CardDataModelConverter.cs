using TrueColors.Core.Cards;
using TrueColors.Data;
using TrueColors.Util;

namespace TrueColors.Converters
{
    public class CardDataModelConverter : IConverter<CardDataModel, Card>
    {
        public Card Convert(CardDataModel source)
        {
            var shape = source.shape.Data.ToCardShape();
            var color = source.color.Data.ToCardColor();
            
            return new Card(shape, color);
        }
    }
}