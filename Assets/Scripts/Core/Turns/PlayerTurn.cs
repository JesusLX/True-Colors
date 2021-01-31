using Assets.Scripts.Core.Controllers;
using TrueColors.Core;
using TrueColors.Core.Controller;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Core.Turns
{
    public class PlayerTurn : MonoBehaviour, ITurn
    {
        [SerializeField] CanvasGroup cardCanvasGroup;
        [SerializeField] PlayerHandController playerHandController;
        [SerializeField] DropZone dropZone;
        [SerializeField] TurnController turnController;
        [SerializeField] PlaysController playsController;

        public bool badRainbow = false;

        void Start()
        {
            //dropZone.OnActionDone.AddListener(EndTurn);
        }
        
        public bool JustOnce
        {
            get { return justOnce; }
        }
        
        public UnityEvent OnTurnFinished
        {
            get { return onTurnFinished; }
        }
        
        [SerializeField] bool justOnce;

        UnityEvent onTurnFinished = new UnityEvent();

        public void StartTurn()
        {
            //Debug.Log("Bienvenido jugador");
            if(cardCanvasGroup)
                cardCanvasGroup.blocksRaycasts = true;
            
            playerHandController.GetNextCard();
        }

        public void EndTurn()
        {
            if(cardCanvasGroup)
                cardCanvasGroup.blocksRaycasts = false;
            
            //playerHandController.RemoveHandCard(playsController.GetLastUsedCard());
            OnTurnFinished.Invoke();
        }
    }
}