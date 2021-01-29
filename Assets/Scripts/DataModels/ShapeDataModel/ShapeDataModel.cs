using System;
using TrueColors.Converters;
using TrueColors.Core.Cards;
using TrueColors.Util;
using UnityEngine;

namespace TrueColors.Data
{
    [Serializable]
    public class ShapeDataModel
    {
        public Sprite artwork;
        [ClassImplements(typeof(ICardShape))] public ClassTypeReference type;
        
        readonly  IConverter<ShapeDataModel, ICardShape> converter = new ShapeDataModelConverter();
        
        #region Converter
        public ICardShape ToCardShape() => converter.Convert(this);
        #endregion
    }
}