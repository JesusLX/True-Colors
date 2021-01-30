using System;

namespace TrueColors.Data
{
    [Serializable]
    public class CardDataModel
    {
        public ShapeDataModelWrapper shape;
        public ColorDataModelWrapper color;
        
        #region Converter
        //TODO: hacer converter
        #endregion
    }
}
