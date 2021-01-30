using System;
using UnityEngine;

namespace TrueColors.Data
{
    [CreateAssetMenu(fileName = "New Card", menuName = "TrueColors/Cards/Card")]
    public class CardDataModelWrapper : ScriptableObject
    {
        [SerializeField] CardDataModel data;
        
        #region Accessors
        public CardDataModel Data => data;
        #endregion
    }
}