using System.Collections.Generic;
using System.Linq;
using TrueColors.Core.Cards;
using TrueColors.Core.Controller;
using TrueColors.Core.Drag;
using TrueColors.Data;
using TrueColors.View;
using UnityEngine;

namespace Assets.Scripts.Core.Controllers
{
    public class PlayerHandController : MonoBehaviour
    {
        [SerializeField] PlaysController playsController;
        [SerializeField] DeckDataModelWrapper deck;
        [SerializeField] int maxHandCards;

        List<CardDataModel> availableCards;
        List<CardDataModel> handCards;

        public GameObject playerCardPre;
        public Transform handParent;
        public CanvasGroup canvasGroup;

        public void Init()
        {
            LoadDeck();
            LoadHand();
        }

        void LoadDeck()
        {
            availableCards = new List<CardDataModel>();
            handCards = new List<CardDataModel>();
            foreach(var card in deck.Data.cards)
            {
                availableCards.Add(card.Data);
            }
        }

        public void LoadHand()
        {
            //Debug.Log($"Loading player hand - {availableCards.Count} || {maxHandCards}");
            for(var i = 0; i < availableCards.Count && i < maxHandCards; i++)
            {
                GetNextCard();
            }
        }

        public void GetNextCard()
        {
            //Debug.Log($"{availableCards.Count} > 0 && {handCards.Count} < {maxHandCards}");
            if(availableCards.Count > 0 && handCards.Count < maxHandCards)
            {
                //Debug.Log("Robando carta");
                var card = availableCards[0];
                availableCards.RemoveAt(0);
                handCards.Add(card);
                
                //Instanciarla
                var cardSpawn = Instantiate(playerCardPre,handParent);
                cardSpawn.GetComponent<CardView>()?.Present(card);
                cardSpawn.transform.SetParent(handParent);
                cardSpawn.GetComponent<Draggable>().canvasGroup = canvasGroup;
                
                if(card.color.Data.type == typeof(RainbowGoodColor))
                {
                    if(playsController.goodRainbowBlocked)
                    {
                        //Bloquear con candado y quitar draggable
                        cardSpawn.GetComponent<CardView>()?.ShowLock(true);
                        cardSpawn.GetComponent<Draggable>().enabled = false;
                    }
                    else
                    {
                        cardSpawn.GetComponent<CardView>()?.ShowLock(false);
                        cardSpawn.GetComponent<Draggable>().enabled = true;
                    }
                }
            }
                
        }

        public void RemoveHandCard(CardDataModel card)
        {
            //Debug.Log($"removing card - {card.color.Data.type}");
            //Debug.Log($"removing card - {card.shape.Data.type}");
            
            var index = handCards.IndexOf(handCards.First(c => 
                c.color.Data.type == card.color.Data.type
                && c.shape.Data.type == card.shape.Data.type));
            
            handCards.RemoveAt(index);
        }

        public ColorDataModel GetRandomHandColor()
        {
            var max = handCards.Count;

            if(max == 0)
            {
                return playsController.GetLastUsedCard().color.Data;
            }
            
            var index = Random.Range(0, max);
            return handCards[index].color.Data;
        }

        public ShapeDataModel GetRandomHandShape()
        {
            var max = handCards.Count;
            
            if(max == 0)
            {
                return playsController.GetLastUsedCard().shape.Data;
            }
            
            var index = Random.Range(0, max);
            
            return handCards[index].shape.Data;
        }

        public List<ColorDataModel> GetAllHandColor()
        {
            var colors = new List<ColorDataModel>();
            foreach(var color in handCards.Select(handCard => handCard.color.Data).Where(color => !colors.Contains(color)))
            {
                colors.Add(color);
            }

            return colors;
        }
        
        public List<ShapeDataModel> GetAllHandShapes()
        {
            var shapes = new List<ShapeDataModel>();
            foreach(var shape in handCards.Select(handCard => handCard.shape.Data).Where(shape => !shapes.Contains(shape)))
            {
                shapes.Add(shape);
            }

            return shapes;
        }

        public bool NoMoreCards()
        {
            return handCards.Count == 0;
        }
    }
}