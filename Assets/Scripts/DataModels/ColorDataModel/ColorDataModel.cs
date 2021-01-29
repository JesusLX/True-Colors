using System;
using TrueColors.Converters;
using TrueColors.Core.Cards;
using TrueColors.Util;
using UnityEngine;

namespace TrueColors.Data
{
    [Serializable]
    public class ColorDataModel
    {
        public Gradient color;
        [ClassImplements(typeof(ICardColor))] public ClassTypeReference type;
        
        readonly  IConverter<ColorDataModel, ICardColor> converter = new ColorDataModelConverter();
        
        #region Converter
        public ICardColor ToCardColor() => converter.Convert(this);
        #endregion
    }
}