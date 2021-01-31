using UnityEngine;

namespace TrueColors.Data
{
    [CreateAssetMenu(fileName = "New Card", menuName = "TrueColors/Cards/Shape")]
    public class ShapeDataModelWrapper : ScriptableObject
    {
        [SerializeField] ShapeDataModel data;
        
        #region Accessors
        public ShapeDataModel Data => data;
        
        public void SetData(ShapeDataModel shape) => data = shape;
        #endregion
    }
}