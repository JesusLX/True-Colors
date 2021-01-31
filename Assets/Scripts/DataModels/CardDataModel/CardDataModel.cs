using System;
using TrueColors.Converters;
using TrueColors.Core.Cards;
using TrueColors.Util;

namespace TrueColors.Data
{
    [Serializable]
    public class CardDataModel
    {
        public ShapeDataModelWrapper shape;
        public ColorDataModelWrapper color;
        
        readonly  IConverter<CardDataModel, ICard> converter = new CardDataModelConverter(); 
        
        #region Converter
        public ICard ToCard() => converter.Convert(this);
        #endregion
    }
}
