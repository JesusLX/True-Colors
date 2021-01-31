using System;
using TrueColors.Data;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;
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
        [SerializeField] CardDataModelWrapper testCard;

        CardDataModel cardData;
        
        [ContextMenu("TryPresent")]
        void TestPresent()
        {
            if(testCard != null)
                Present(testCard.Data);
        }
        
        public void Present(CardDataModel data)
        {
            cardData = data;
            if(data.color.Data.material != null)
                references.background.material = data.color.Data.material;
            
            references.background.color = data.color.Data.color;

            if(data.shape.Data.artwork == null)
            {
                references.icon.enabled = false;
            }
            else
                references.icon.enabled = true;
            
            
            references.icon.sprite = data.shape.Data.artwork != null ? data.shape.Data.artwork : null;
        }

        public CardDataModel GetCardData()
        {
            return cardData;
        }
    }
}