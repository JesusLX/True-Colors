using UnityEngine;
using UnityEngine.EventSystems;

namespace TrueColors.Core.Drag
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Starting drag");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Dragging");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("Ending drag");
        }
    }
}