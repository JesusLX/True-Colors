using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Core.Turns
{
    public class BadRainbowTurn : MonoBehaviour, ITurn
    {
        [SerializeField]
        FadeOutController fadeOutController;
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
            StartCoroutine(DelaySlap());
        }

        public void EndTurn()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator DelaySlap() {
            yield return new WaitForSeconds(1f);
            AudioManager.Instance.Pause(Keys.Music.FIRST_ACT);
            fadeOutController?.PlaySlap();
            yield return new WaitForSeconds(2);
        // CAMBIO ESCENE
        }
    }
}