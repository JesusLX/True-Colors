using TrueColors.Core.Cards;
using TrueColors.Core.Turn;
using TrueColors.Data;
using UnityEngine;
using UnityEngine.Events;

namespace TrueColors.Core.Controller
{
    public class PlaysController : MonoBehaviour
    {
        DropZone dropZone;
        
        CardDataModel lastUsedCard;

        UnityEvent OnBadRainbowUsed;

        [SerializeField] TurnBehaviour turnBehaviour;

        public void Start()
        {
            InitListeners();
        }

        void InitListeners()
        {
            OnBadRainbowUsed = new UnityEvent();
            
            //dropZone.OnCardUsed.AddListener(UseCard);
        }

        public CardDataModel GetLastUsedCard()
        {
            return lastUsedCard;
        }

        public void UseCard(CardDataModel cardData)
        {
            Debug.Log($"PLAYS CONTROLLER USING CARD - {cardData.color.Data.type.ToString()}");
            ThrowGamefeel(cardData);
            
            lastUsedCard = cardData;

            if(cardData.color.Data.type == typeof(RainbowBadColor))
            {
                Debug.Log("wow bad card");
                OnBadRainbowUsed.Invoke();
                turnBehaviour.TurnController.LaunchRainbowTurn();
            }
            
            //puede que aqui ponga el endturn
        }

        bool IsPlayEffective(CardDataModel cardData)
        {
            if(lastUsedCard == null)
                return true;

            return cardData.ToCard().IsMatch(lastUsedCard.ToCard());
        }

        void ThrowGamefeel(CardDataModel cardData)
        {
            var goodPlay = IsPlayEffective(cardData);

            if(goodPlay)
            {
                //Se lanzan efectos positivos
                VFXDirector.Instance.Play("SoftWave", Vector3.zero, cardData.color.Data.color);
                VFXDirector.Instance.PlayEternal("SimbolPS", Vector3.zero, cardData.color.Data.color, cardData.shape.Data.artwork);
                VFXDirector.Instance.PlayEternal("FloatingLightPS", Vector3.zero, cardData.color.Data.color, null);
                AudioManager.Instance.Play(Keys.Music.GOOD_CHOICE);
            }
            else
            {
                //Se lanzan efectos negativos
                ShakeController.Instance.Shake();
                AudioManager.Instance.Play(Keys.Music.BAD_CHOICE);
            }
        }

        public void SetLastUsedCard(CardDataModel card)
        {
            lastUsedCard = card;
        }
    }
}