using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Core.Turns
{
    public class BadRainbowTurn : MonoBehaviour, ITurn
    {
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
            Debug.Log($"GO BAD RAINBOWWWWW");
        }

        public void EndTurn()
        {
            throw new System.NotImplementedException();
        }
    }
}