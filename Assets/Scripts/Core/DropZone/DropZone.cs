using TrueColors.Core.Cards;
using TrueColors.Core.Controller;
using TrueColors.Core.Drag;
using TrueColors.Util;
using TrueColors.View;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace TrueColors.Core
{
    public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {

        public CardDataUnityEvent OnCardUsed;
        public UnityEvent OnActionDone;

        [SerializeField] PlaysController playsController;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(eventData.pointerDrag == null)
                return;

            var drag = eventData.pointerDrag.GetComponent<Draggable>();

            if(drag != null)
            {
                drag.placeholderParent = transform;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(eventData.pointerDrag == null)
                return;
            
            var drag = eventData.pointerDrag.GetComponent<Draggable>();

            if(drag != null && drag.placeholderParent == transform)
                drag.placeholderParent = drag.parentToReturn;
        }
        
        public void OnDrop(PointerEventData eventData)
        {
            var drag = eventData.pointerDrag.GetComponent<Draggable>();

            if(drag != null)
            {
                RotateDraggable(drag);
                drag.parentToReturn = transform;

                var usedCard = eventData.pointerDrag.GetComponent<CardView>().GetCardData();

                drag.UsedCard();
                
                //playsController.SetLastUsedCard(usedCard);
                
                if(usedCard!=null && usedCard.color.Data.type != typeof(RainbowBadColor))
                {
                    OnActionDone.Invoke();
                }
                
                if(usedCard!=null)
                    OnCardUsed.Invoke(usedCard);
                    
            }
        }
        
        #region Support Methods
        void RotateDraggable(Draggable drag)
        {
            var randomRotation = Random.Range(-15f, 15f);
            drag.transform.Rotate(new Vector3(0,0,randomRotation));
        }
        #endregion
    }
}