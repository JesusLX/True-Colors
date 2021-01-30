using System;
using TrueColors.Data;
using UnityEngine;
using UnityEngine.UI;

namespace TrueColors.View
{
    [Serializable]
    public class SelfReferences
    {
        public GameObject cardFront;
        public GameObject cardReverse;

        [Header("Card Front")] 
        public Image background;
        public Image icon;
    }
    
    public class CardView : MonoBehaviour
    {
        [SerializeField] SelfReferences references = new SelfReferences();
        public CardDataModelWrapper testCard;
        
        [ContextMenu("TryPresent")]
        void TestPresent()
        {
            if(testCard != null)
                Present(testCard.Data);
        }
        
        public void Present(CardDataModel data)
        {
            references.background.color = data.color.Data.color;
            references.icon.sprite = data.shape.Data.artwork;
        }
    }
}