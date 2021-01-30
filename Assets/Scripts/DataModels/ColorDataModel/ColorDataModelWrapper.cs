using UnityEngine;

namespace TrueColors.Data
{
    [CreateAssetMenu(fileName = "New Card", menuName = "TrueColors/Cards/Color")]
    public class ColorDataModelWrapper : ScriptableObject
    {
        [SerializeField] ColorDataModel data;
        
        #region Accessors
        public ColorDataModel Data => data;
        #endregion
    }
}