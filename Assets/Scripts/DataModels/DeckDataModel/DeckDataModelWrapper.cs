using UnityEngine;

namespace TrueColors.Data
{
    [CreateAssetMenu(fileName = "New Deck", menuName = "TrueColors/Cards/Deck")]
    public class DeckDataModelWrapper : ScriptableObject
    {
        [SerializeField] DeckDataModel data;
        
        #region Accessors
        public DeckDataModel Data => data;
        #endregion
    }
}