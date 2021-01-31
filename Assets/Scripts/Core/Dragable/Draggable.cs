using UnityEngine;
using UnityEngine.EventSystems;

namespace TrueColors.Core.Drag
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Transform placeholderParent = null;
        public Transform parentToReturn = null;

        public CanvasGroup canvasGroup;

        GameObject placeholder = null;

        bool usedCard = false;

        public void OnBeginDrag(PointerEventData eventData)
        {
            //Debug.Log("OnBeginDrag");
            placeholder = new GameObject();
            placeholder.transform.SetParent(transform.parent);

            parentToReturn = transform.parent;
            placeholderParent = parentToReturn;

            transform.SetParent(transform.parent.parent);

            AllowRaycast(false);
        }

        public void OnDrag(PointerEventData eventData)
        {
            //Debug.Log("Dragging");
            var mousePosition = Camera.main.ScreenToWorldPoint(eventData.position);
            mousePosition.z = 0;
            transform.position = mousePosition;

            if(placeholder.transform.parent != placeholderParent)
                placeholder.transform.SetParent(placeholderParent);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //Debug.Log("Ending drag");
            //transform.position = placeholder.transform.position;
            //transform.SetParent(placeholder.transform.parent);

            transform.SetParent(parentToReturn);
            transform.position = parentToReturn.position;

            Destroy(placeholder);

            AllowRaycast(true);
        }

        #region Support Methods
        void AllowRaycast(bool allow)
        {
            if(!usedCard)
            {
                if(canvasGroup != null)
                    canvasGroup.blocksRaycasts = allow;
            }
            else
                enabled = false;    
        }

        public void UsedCard()
        {
            usedCard = true;
        }
        #endregion
    }
}